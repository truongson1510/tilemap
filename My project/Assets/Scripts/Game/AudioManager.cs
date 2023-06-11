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

    [Header(" Character -----------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private List<AudioClip> sound_dispose;
    [ShowIf("settings")]
    [SerializeField] private List<AudioClip> sound_help;
    [ShowIf("settings")]
    [SerializeField] private List<AudioClip> sound_hit;
    [ShowIf("settings")]
    [SerializeField] private List<AudioClip> sound_yell;

    [Header(" Elements -----------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_blackHole;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_explode;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_rope;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_spike;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_spikeBall;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_wood;

    [Header(" Others --------------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_gravity_down;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_gravity_up;

    [Header(" UI ------------------------------------------------")]

    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_button_click;
    [ShowIf("settings")]
    [SerializeField] private AudioClip sound_camera_shot;

    [Header(" Win/Lose ------------------------------------------")]

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
            case Sound.dispose:
                audio = sound_dispose[Random.Range(0, sound_dispose.Count)];
                break;
            case Sound.help:
                audio = sound_help[Random.Range(0, sound_help.Count)];
                break;
            case Sound.hit:
                audio = sound_hit[Random.Range(0, sound_hit.Count)];
                break;
            case Sound.yell:
                audio = sound_yell[Random.Range(0, sound_yell.Count)];
                break;

            case Sound.blackHole:
                audio = sound_blackHole;
                break;
            case Sound.explode:
                audio = sound_explode;
                break;
            case Sound.rope:
                audio = sound_rope;
                break;
            case Sound.spike:
                audio = sound_spike;
                break;
            case Sound.spikeBall:
                audio = sound_spikeBall;
                break;
            case Sound.wood:
                audio = sound_wood;
                break;


            case Sound.gravity_down:
                audio = sound_gravity_down;
                break;
            case Sound.gravity_up:
                audio = sound_gravity_up;
                break;

            case Sound.button_click:
                audio = sound_button_click;
                break;
            case Sound.camera_shot:
                audio = sound_camera_shot;
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
