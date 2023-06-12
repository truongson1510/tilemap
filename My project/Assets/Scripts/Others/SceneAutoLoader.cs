
using UniRx;
using TMPro;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneAutoLoader : MonoBehaviour
{
    #region Enums

    [Serializable]
    public enum SceneIndexes
    {
        Preload = 0,
        Main    = 1,
        Level1  = 2,
        Level2  = 3
    }

    #endregion

    #region Inspector Variables

    [SerializeField] private TextMeshProUGUI    textLoading;
    [SerializeField] private TextMeshProUGUI    textPercentage;
    [SerializeField] private Image              loadingBar;
    [SerializeField] private AnimationCurve     loadingCurve;
    [SerializeField] private float              loadingDuration;

    #endregion

    #region Member Variables

    private bool isLoaded = false;

    #endregion

    #region Unity Methods

    private void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(0.15f)).Take(1).Subscribe(_ =>
        {
            //verify if the scene is already open to avoid opening a scene twice
            if (SceneManager.sceneCount > 0)
            {
                for (int i = 0; i < SceneManager.sceneCount; ++i)
                {
                    Scene scene = SceneManager.GetSceneAt(i);
                    if (scene.name == SceneIndexes.Main.ToString())
                    {
                        isLoaded = true;
                    }
                }
            }
            Loading();
        });
    }

    private void OnDestroy()
    {
        DOTween.Clear();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Start animating text and filler while performing background loading
    /// </summary>
    private void Loading()
    {
        var sceneName = SceneIndexes.Main.ToString();

        if (isLoaded)
            SceneManager.UnloadSceneAsync(sceneName);

        if (!isLoaded)
        {
            //Loading the scene in background
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            //We set it to true to avoid loading the scene twice
            isLoaded = true;

            ProgressLoadingBar();
            StartCoroutine(AnimateLoadingText());
            StartCoroutine(ActiveAfterLoad(async));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator AnimateLoadingText()
    {
        string[] loadingTextArray = { "Loading", "Loading.", "Loading..", "Loading..." };
        int index = 0;

        while (true)
        {
            textLoading.text = loadingTextArray[index];
            index = (index + 1) % loadingTextArray.Length;
            yield return new WaitForSeconds(0.5f);
        }
    }

    /// <summary>
    /// Changing loading percentages and loading bar accordingly
    /// </summary>
    private void ProgressLoadingBar()
    {
        int percentage = 0;
        float fillAmount = loadingBar.fillAmount;

        DOTween.To(() => fillAmount, x => fillAmount = x, 0.99f, loadingDuration)
            .SetEase(loadingCurve)
            .SetUpdate(true)
            .OnUpdate(() =>
            {
                loadingBar.fillAmount = fillAmount;
                percentage = (int)(fillAmount * 100);
                textPercentage.text = $"{percentage}%";
            })
            .OnComplete(() =>
            {

            });
    }

    /// <summary>
    /// Load scene in background and active with given conditions
    /// </summary>
    /// <param name="async"></param>
    /// <returns></returns>
    private IEnumerator ActiveAfterLoad(AsyncOperation async)
    {
        float loadTime = 0;
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            // Check if the load has finished and loading bar has finished
            if (async.progress >= 0.9f && loadTime > loadingDuration)
                async.allowSceneActivation = true;

            loadTime += Time.deltaTime;

            yield return null;
        }
    }

    #endregion
}