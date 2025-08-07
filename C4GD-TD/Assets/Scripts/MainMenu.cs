using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // <-- Required for Button

public class MainMenu : MonoBehaviour
{
    public Button startButton; // <-- Changed from MainButtons to Button

    public Button settingsButton;

    public Button HTPButton;

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void settingsButtonPressed()
    {
        SceneManager.LoadScene("SettingsScreen");
    }


    public void HTPButtonPressed()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    void Start()
    {
        if (startButton != null) startButton.onClick.AddListener(StartButtonPressed);
        if(settingsButton != null) settingsButton.onClick.AddListener(settingsButtonPressed);
        if (HTPButton != null) HTPButton.onClick.AddListener(HTPButtonPressed);
    }
}