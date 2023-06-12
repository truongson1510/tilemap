using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : Singleton<VideoManager>
{
    #region Inspector Variables

    [SerializeField] private VideoPlayer endingVideo;
    [SerializeField] private VideoPlayer gameoverVideo;
    [SerializeField] private VideoPlayer openingVideo;

    [Space]

    [SerializeField] private GameObject level;

    #endregion

    #region Member Variables

    private Action onEndingCompleteAction;
    private Action onGameoverCompleteAction;
    private Action onOpeningCompleteAction;

    #endregion

    #region Properties
    #endregion

    #region Unity Methods

    private void Awake()
    {
        endingVideo.loopPointReached    += OnEndingFinish;
        gameoverVideo.loopPointReached  += OnGameOverFinish;
        openingVideo.loopPointReached   += OnOpeningFinish;

        PlayOpeningVideo(() => 
        {
            SetLevelActive(true);
            openingVideo.gameObject.SetActive(false);
        });
    }

    #endregion

    #region Public Methods

    public void SetLevelActive(bool state)
    {
        if (level != null) { level.SetActive(state); }
    }

    public void PlayEndingrVideo(Action onCompleteAction = null)
    {
        endingVideo.Play();
        AudioManager.Instance.PlayOneShot(Sound.win);
        onEndingCompleteAction = onCompleteAction;
    }

    public void PlayGameoverVideo(Action onCompleteAction = null)
    {
        gameoverVideo.Play();
        AudioManager.Instance.PlayOneShot(Sound.lose);
        onGameoverCompleteAction = onCompleteAction;
    }

    public void PlayOpeningVideo(Action onCompleteAction = null)
    {
        openingVideo.Play();
        AudioManager.Instance.PlayOneShot(Sound.open);
        onOpeningCompleteAction = onCompleteAction;
    }

    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods

    private void OnEndingFinish(VideoPlayer source)
    {
        onEndingCompleteAction?.Invoke();
    }

    private void OnGameOverFinish(VideoPlayer source)
    {
        onGameoverCompleteAction?.Invoke();
    }

    private void OnOpeningFinish(VideoPlayer source)
    {
        onOpeningCompleteAction?.Invoke();
    }

    #endregion
}
