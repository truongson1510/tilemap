using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AudioManager : Singleton<AudioManager>
{
    #region Inspector Variables

    [Space]

    [SerializeField] private AudioSource background;

    [SerializeField] private bool settings;

    [Header(" Game ---------------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_done_cooking;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_running_low;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_fail_to_server;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_wrong_ingredient;

    [Header(" UI ------------------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_button_click;

    [Header(" Win/Lose ------------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_open;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_lose;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_win;

    #endregion

    #region Member Variables

    [HideInInspector] public AudioClip audio;
    private List<AudioSource> audioSources = new();

    #endregion

    #region Properties
    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (background != null)
        {
            background.ignoreListenerPause = true;
        }
    }

    #endregion

    #region Public Methods

    public void PlayOneShot(Sound soundType, bool ignoreTimeScale = true, float volume = 0.9f)
    {
        switch (soundType)
        {
            case Sound.doneCooking:
                audio = sound_done_cooking;
                break;
            case Sound.timeLow:
                audio = sound_running_low;
                break;
            case Sound.failToServe:
                audio = sound_fail_to_server;
                break;
            case Sound.wrongIngredient:
                audio = sound_wrong_ingredient;
                break;

            case Sound.button:
                audio = sound_button_click;
                break;

            case Sound.open:
                audio = sound_open;
                break;
            case Sound.lose:
                audio = sound_lose;
                break;
            case Sound.win:
                audio = sound_win;
                break;
        }

        if (audio != null)
        {
            // Create a new AudioSource component
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();

            // Ignore timescale
            background.ignoreListenerPause = ignoreTimeScale;

            // Set the clip to play
            newAudioSource.clip = audio;

            // Set the value
            newAudioSource.volume = volume;

            // Play the new sound
            newAudioSource.Play();

            // Add the AudioSource to the list
            audioSources.Add(newAudioSource);

            // Destroy the AudioSource when the sound finishes playing
            StartCoroutine(DestroyAudioSourceWhenFinished(newAudioSource));
        }
    }

    public void PlayBackgroundMusic(bool state)
    {
        if (state)
        {
            background.Pause();
        }
        else
        {
            background.UnPause();
        }
    }

    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    private IEnumerator DestroyAudioSourceWhenFinished(AudioSource audioSource)
    {
        // Wait until the sound finishes playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Remove the AudioSource from the list
        audioSources.Remove(audioSource);

        // Destroy the AudioSource component
        Destroy(audioSource);
    }

    #endregion
}
