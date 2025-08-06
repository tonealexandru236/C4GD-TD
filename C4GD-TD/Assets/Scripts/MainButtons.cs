using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

        MainButtons.instance.enemies.Add(GameObject.Find("Enemy1"));

        balance = 300;
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
        else if (speed == 3) { speed = 1; speedup.SetText("x1"); }
        Time.timeScale = speed;
    }

    private void Update()
    {
        money.SetText(balance + " $");

        /*if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.CompareTag("Tower") && hit.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a != 1)
                    gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_app");
               //else

            }
        }*/
    }
}
