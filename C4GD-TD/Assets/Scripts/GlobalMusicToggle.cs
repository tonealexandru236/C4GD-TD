using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalMusicToggle : MonoBehaviour
{
    private AudioSource audioSource;
    public TMP_Text On;

    void Awake()
    {
        // Make sure only one music source exists in the scene
        /*
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            if (source != GetComponent<AudioSource>() && source.isPlaying)
            {
                source.Stop(); // Stop other audio sources
            }
        }
        */

        audioSource = GetComponent<AudioSource>();

        if (On != null)
        {
            if (audioSource.mute == true) On.SetText("Music Off");
            else On.SetText("Music On");
        }

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

            if (On != null)
            {
                if (audioSource.mute == true) On.SetText("Music Off");
                else On.SetText("Music On");
            }

            // Save the mute state
            PlayerPrefs.SetInt("MusicMuted", audioSource.mute ? 1 : 0);

            PlayerPrefs.Save();
        }
    }
}