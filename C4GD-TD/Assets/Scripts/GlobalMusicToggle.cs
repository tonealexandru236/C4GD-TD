using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicToggle : MonoBehaviour

{
    private AudioSource audioSource;

    void Awake()
    {
        // Make sure only one music source exists in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            if (source != GetComponent<AudioSource>() && source.isPlaying)
            {
                source.Stop(); // Stop other audio sources
            }
        }

        audioSource = GetComponent<AudioSource>();

        // Apply saved mute setting
        bool isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        audioSource.mute = isMuted;

        audioSource.Play();
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