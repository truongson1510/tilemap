using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LiveManager : MonoBehaviour
{
    public static LiveManager instance;

    [SerializeField] Text liveText;
    [SerializeField] int liveCount;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        liveText.text=liveCount.ToString();
    }

    private void Update()
    {
        if (liveCount <= 0)
        {
            liveCount = 0;
            liveText.text = liveCount.ToString();

            FoodManager.Instance.TurnOffButtons();
            FoodManager.Instance.TurnOff();

            VideoManager.Instance.SetLevelActive(false);
            VideoManager.Instance.PlayGameoverVideo(() => { GameManager.Instance.LoadScene(SceneAutoLoader.SceneIndexes.Main); });

            gameObject.SetActive(false);
        }
    }

    public void DecreaseLive()
    {
        liveCount--;
        liveText.text=liveCount.ToString();
    }
}
