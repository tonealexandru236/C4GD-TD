using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    private float speed = 1f;
    public GameObject pause;
    public TMP_Text speedup;

    private void Start()
    {
        speedup.SetText("x1");
        Time.timeScale = speed;
    }

    public void game_pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = speed;
            pause.SetActive(false);
        }
        else 
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }

    }

    public void game_speed()
    {
        if (speed == 1) { speed = 2; speedup.SetText("x2"); }
        else { speed = 1; speedup.SetText("x1"); }
        Time.timeScale = speed;
    }
}
