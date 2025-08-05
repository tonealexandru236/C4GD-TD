using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainButtons : MonoBehaviour
{
    private float speed = 1f;
    public GameObject pause;
    public TMP_Text speedup;

    public TMP_Text cant_place;
    public TMP_Text not_enough;
    public TMP_Text money;

    static public MainButtons instance;
    
    public int balance;

    private void Start()
    {
        instance = this;

        balance = 200;
        speedup.SetText("x1");
        Time.timeScale = speed;
    }

    public void cant_place_tower()
    {
        cant_place.GetComponent<Animator>().Play("cant_place", 0, 0);
    }

    public void not_enough_money()
    {
        not_enough.GetComponent<Animator>().Play("cant_place", 0, 0);
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
        else if (speed == 2) { speed = 3; speedup.SetText("x3"); }
        else if (speed == 3) { speed = 1; speedup.SetText("x1"); }
        Time.timeScale = speed;
    }

    private void Update()
    {
        money.SetText(balance + " $");
    }
}
