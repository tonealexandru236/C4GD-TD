using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    private float speed = 1f;
    public GameObject pause;
    public TMP_Text speedup;

    public TMP_Text cant_place;
    public TMP_Text not_enough;
    public TMP_Text money;

    public Image hpbar;
    public TMP_Text hpbar_txt;

    static public MainButtons instance;
    
    public int balance;
    public int player_health;

    private void Start()
    {
        instance = this;

        player_health = 80;
        balance = 310;
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

    public List<GameObject> ranges;
    public List<GameObject> enemies;

    public void dis_all_ranges()
    {
        foreach (GameObject range in ranges)
        {
            range.GetComponent<Animator>().Play("range_dis");
        }
    }

    public void game_speed()
    {
        if (speed == 1) { speed = 2; speedup.SetText("x2"); }
        else if (speed == 2) { speed = 3; speedup.SetText("x3"); }
        else if (speed == 3) { speed = 5; speedup.SetText("x5"); }
        else if (speed == 5) { speed = 1; speedup.SetText("x1"); }
        Time.timeScale = speed;
    }

    private void Update()
    {
        money.SetText(balance + " $");
        hpbar.fillAmount = (float)player_health / 80;
        hpbar_txt.SetText(player_health.ToString());

        if (player_health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
