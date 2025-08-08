using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;
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
    public int max_health;

    public GameObject upgrade_screen;

    public AudioSource music;

    private void Start()
    {
        instance = this;
        
        if(SceneManager.GetActiveScene().name == "Battle1") max_health = 140;
        else if(SceneManager.GetActiveScene().name == "Battle2") max_health = 80;
        else if(SceneManager.GetActiveScene().name == "Battle3") max_health = 60;
        player_health = max_health;

        balance = 320; /// starting is 320
        speedup.SetText("x1");
        Time.timeScale = speed * 1.25f;
    }

    public void cant_place_tower()
    {
        cant_place.GetComponent<Animator>().Play("cant_place", 0, 0);
    }

    public void not_enough_money()
    {
        not_enough.GetComponent<Animator>().Play("cant_place", 0, 0);
    }

    public Image boss_health_bar;

    public void game_pause()
    {
        if (Time.timeScale == 0)
        {
            music.UnPause();
            Time.timeScale = speed * 1.25f;
            pause.SetActive(false);
        }
        else 
        {
            music.Pause();
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
            //range.transform.parent.GetComponent<Tower>().is_upg_open = true;
            if(range != null && range.GetComponent<Animator>() != null)
                range.GetComponent<Animator>().Play("range_dis");
        }
    }

    public void game_speed()
    {
        if (speed == 1) { speed = 2; speedup.SetText("x2"); }
        else if (speed == 2) { speed = 4; speedup.SetText("x4"); }
        else if (speed == 4) { speed = 8; speedup.SetText("x8"); }
        else if (speed == 8) { speed = 1; speedup.SetText("x1"); }
        Time.timeScale = speed * 1.25f;
    }

    private void Update()
    {
        money.SetText(balance + " $");
        hpbar.fillAmount = (float)player_health / max_health;
        hpbar_txt.SetText(player_health.ToString());

        if (player_health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void spawn_on_destroy(GameObject[] spawns, int[] amt, float progress, SplineAnimate path)
    {
        for (int i = 0; i < spawns.Count(); i++)
        {
            for (int j = 0; j < amt[i]; j++)
            {
                GameObject ist = Instantiate(spawns[i]);

                //Destroy(ist.GetComponent<SplineAnimate>());
                //ist.AddComponent<SplineAnimate>();

                SplineAnimate sa = ist.GetComponent<SplineAnimate>();
                //sa.Duration = 23;

                float progress_randomizer = Random.Range(-0.05f, 0.05f);

                sa.Container = path.Container;
                //sa.Restart(false);

                StartCoroutine(do_spline(sa, progress + progress_randomizer));

                /*
                sa.Play();
                
                sa.NormalizedTime = progress + progress_randomizer;
                ist.GetComponent<SplineAnimate>().NormalizedTime = sa.NormalizedTime;*/
                //sa.PlayOnAwake = false;


                //yield return null;


                Debug.Log(progress + progress_randomizer);
                MainButtons.instance.enemies.Add(ist);
                //yield return new WaitForSeconds(0.05f);
            }
        }
    }

    IEnumerator do_spline(SplineAnimate sp, float time)
    {
        sp.Play();
        yield return null;

        sp.NormalizedTime = time;
        //ist.GetComponent<SplineAnimate>().NormalizedTime = sa.NormalizedTime;
    }

    public Image upg_tower;
    public TMP_Text upg_name;
    public TMP_Text upg_level;
    public TMP_Text upg_upg;
    public TMP_Text upg_money;

    public TMP_Text upg_description;
    public TMP_Text upg_refund;

    public Button upgrade_but;
    public GameObject actual_tower;
        
    private float money_upg;

    public void Upgrade_screen(Sprite tower, string name, float level, string upg, float money, GameObject tower_obj, string description)
    {
        if(level == 5) upgrade_but.gameObject.SetActive(false);
        else upgrade_but.gameObject.SetActive(true);

        upg_tower.sprite = tower;
        upg_name.SetText(name);
        upg_level.SetText("Level " + level.ToString());
        upg_upg.SetText(upg);
        upg_refund.SetText("+" + tower_obj.GetComponent<Tower>().refund_price.ToString() + "$");

        upg_description.SetText(description);

        upg_money.SetText(money.ToString() + " $");
        actual_tower = tower_obj;

        money_upg = money;
    }

    public void Sell()
    {
        upgrade_screen.GetComponent<Animator>().Play("upgrades_right", 0, 0);
        balance += actual_tower.GetComponent<Tower>().refund_price;
        Destroy(actual_tower);
        dis_all_ranges();
    }

    public void Do_Upgrade()
    {
        if (balance >= money_upg)
        {
            balance -= (int)money_upg; actual_tower.GetComponent<Tower>().refund_price += (int)money_upg / 2;
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
                    actual_tower.GetComponent<Shoot>().firerate -= 0.3f;
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<Shoot>().amt += 2;
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
                    actual_tower.GetComponent<Shoot>().range += 2f;
                    actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x * 1.68f, actual_tower.transform.GetChild(0).localScale.y * 1.68f, actual_tower.transform.GetChild(0).localScale.z * 1.68f);
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<Shoot>().amt += 3;
                }
            }
            else if (actual_tower.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "can")
            {
                if (upg_level.text == "Level 1")
                {
                    actual_tower.GetComponent<Shoot>().range += 0.5f;
                    actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x * 1.105f, actual_tower.transform.GetChild(0).localScale.y * 1.105f, actual_tower.transform.GetChild(0).localScale.z * 1.105f);

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
            else if (actual_tower.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "coc")
            {
                if (upg_level.text == "Level 1")
                {
                    actual_tower.GetComponent<CoconutFarm>().money += 2;

                }
                else if (upg_level.text == "Level 2")
                {
                    actual_tower.GetComponent<CoconutFarm>().cooldown -= 1;
                }
                else if (upg_level.text == "Level 3")
                {
                    actual_tower.GetComponent<CoconutFarm>().money += 3;
                }
                else if (upg_level.text == "Level 4")
                {
                    actual_tower.GetComponent<CoconutFarm>().cooldown -= 0.5f;
                    coconut_bonus += 30;
                }
            }

            actual_tower.GetComponent<Tower>().level++;
            actual_tower.transform.localScale = new Vector3(actual_tower.transform.localScale.x * 1.075f, actual_tower.transform.localScale.y * 1.075f, actual_tower.transform.localScale.z * 1.075f);
            actual_tower.transform.GetChild(0).localScale = new Vector3(actual_tower.transform.GetChild(0).localScale.x / 1.075f, actual_tower.transform.GetChild(0).localScale.y / 1.075f, actual_tower.transform.GetChild(0).localScale.z / 1.075f);
            StartCoroutine(actual_tower.GetComponent<Tower>().show_update());
        }
        else
            not_enough_money();
    }

    public float coconut_bonus = 0;
}
