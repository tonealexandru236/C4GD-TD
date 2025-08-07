using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicToggle : MonoBehaviour

{
    private static GlobalMusicToggle instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            // Apply saved mute setting
            bool isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
            audioSource.mute = isMuted;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;

            // Save the mute state
            PlayerPrefs.SetInt("MusicMuted", audioSource.mute ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
