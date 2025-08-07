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

    public GameObject upgrade_screen;

    private void Start()
    {
        instance = this;

        player_health = 80;
        balance = 5200; /// starting is 320
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
        upgrade_screen.GetComponent<Animator>().Play("upgrades_right", 0, 0);

        foreach (GameObject range in ranges)
        {
            //range.transform.parent.GetComponent<Tower>().is_upg_open = true;
            range.GetComponent<Animator>().Play("range_dis");
        }
    }

    public void game_speed()
    {
        if (speed == 1) { speed = 2; speedup.SetText("x2"); }
        else if (speed == 2) { speed = 4; speedup.SetText("x4"); }
        else if (speed == 4) { speed = 1; speedup.SetText("x1"); }
        //else if (speed == 5) { speed = 1; speedup.SetText("x1"); }
        Time.timeScale = speed;
    }

    private void Update()
    {
        money.SetText(balance + " $");
        hpbar.fillAmount = (float)player_health / 80;
        hpbar_txt.SetText(player_health.ToString());

        if (player_health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public Image upg_tower;
    public TMP_Text upg_name;
    public TMP_Text upg_level;
    public TMP_Text upg_upg;
    public TMP_Text upg_money;

    public Button upgrade_but;
    public GameObject actual_tower;
        
    private float money_upg;

    public void Upgrade_screen(Sprite tower, string name, float level, string upg, float money, GameObject tower_obj)
    {
        if(level == 5) upgrade_but.gameObject.SetActive(false);
        else upgrade_but.gameObject.SetActive(true);

        upg_tower.sprite = tower;
        upg_name.SetText(name);
        upg_level.SetText("Level " + level.ToString());
        upg_upg.SetText(upg);
        upg_money.SetText(money.ToString() + " $");
        actual_tower = tower_obj;

        money_upg = money;
    }

    public void Do_Upgrade()
    {
        if (balance >= money_upg)
        {
            balance -= (int)money_upg;
            if (actual_tower.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "car")
            {
                if (upg_level.text == "Level 1")
                {
                    actual_tower.GetComponent<Shoot>().range += 0.5f;
                    actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x * 1.105f, actual_tower.transform.GetChild(0).localScale.y * 1.105f, actual_tower.transform.GetChild(0).localScale.z * 1.105f);
                }
                else if (upg_level.text == "Level 2")
                {
                    actual_tower.GetComponent<Shoot>().amt += 1;
                }
                else if (upg_level.text == "Level 3")
                {
                    actual_tower.GetComponent<Shoot>().firerate -= 0.2f;
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<Shoot>().amt += 1;
                }
            }
            else if (actual_tower.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "app")
            {
                if (upg_level.text == "Level 1")
                {
                    actual_tower.GetComponent<Shoot>().range += 0.75f;
                    actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x * 1.16f, actual_tower.transform.GetChild(0).localScale.y * 1.16f, actual_tower.transform.GetChild(0).localScale.z * 1.16f);
                }
                else if (upg_level.text == "Level 2")
                {
                    actual_tower.GetComponent<Shoot>().firerate -= 0.4f;
                }
                else if (upg_level.text == "Level 3")
                {
                    actual_tower.GetComponent<Shoot>().proj_size_multiplier = 1.8f;
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<Shoot>().amt += 1;
                }
            }
            else if (actual_tower.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "ban")
            {
                if (upg_level.text == "Level 1")
                {
                    actual_tower.GetComponent<Shoot>().firerate -= 0.3f;

                }
                else if (upg_level.text == "Level 2")
                {
                    actual_tower.GetComponent<Shoot>().amt += 2;

                }
                else if (upg_level.text == "Level 3")
                {
                    actual_tower.GetComponent<Shoot>().range += 1.5f;
                    actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x * 1.35f, actual_tower.transform.GetChild(0).localScale.y * 1.35f, actual_tower.transform.GetChild(0).localScale.z * 1.35f);
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<Shoot>().amt += 2;
                }
            }
            else if (actual_tower.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "can")
            {
                if (upg_level.text == "Level 1")
                {
                    actual_tower.GetComponent<Shoot>().range += 0.25f;
                    actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x * 1.053f, actual_tower.transform.GetChild(0).localScale.y * 1.053f, actual_tower.transform.GetChild(0).localScale.z * 1.053f);

                }
                else if (upg_level.text == "Level 2")
                {
                    actual_tower.GetComponent<Shoot>().pierce = 2;

                }
                else if (upg_level.text == "Level 3")
                {
                    actual_tower.GetComponent<Shoot>().firerate -= 0.1f;
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<Shoot>().amt += 1;
                }
            }

            actual_tower.GetComponent<Tower>().level++;
            actual_tower.transform.localScale = new Vector3(actual_tower.transform.localScale.x * 1.06f, actual_tower.transform.localScale.y * 1.06f, actual_tower.transform.localScale.z * 1.06f);
            actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x / 1.06f, actual_tower.transform.GetChild(0).localScale.y / 1.06f, actual_tower.transform.GetChild(0).localScale.z / 1.06f);
            StartCoroutine(actual_tower.GetComponent<Tower>().show_update());
        }
        else
            not_enough_money();
    }
}
