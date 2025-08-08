using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp;
    public int money_reward;

    public Sprite die_1;
    public Sprite die_2;

    public Sprite act_1;

    private Image boss_health;
    private bool is_boss;
    private int maxhp;

    private void Start()
    {
        is_boss = false;

        if(gameObject.name.Substring(0, 3) != "Bos")
        {
            StartCoroutine(destroy_enemy());
            
        }
        else
        {
            boss_health = MainButtons.instance.boss_health_bar;
            Debug.Log(MainButtons.instance.boss_health_bar);
            boss_health.gameObject.transform.parent.GetComponent<Animator>().Play("bhp_up", 0, 0);
            is_boss = true;
            maxhp = hp;
        }

        if (act_1 != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = act_1;
    }

    IEnumerator destroy_enemy()
    {
        yield return new WaitForSeconds(28f);
        MainButtons.instance.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    void Update()
    {
        if (is_boss) boss_health.fillAmount = (float)hp / (float)maxhp;

        if (hp <= 0 && hp >= -100)
        {
            gameObject.GetComponent<SplineAnimate>().Pause();

            hp = -200;

            if (is_boss) boss_health.transform.parent.GetComponent<Animator>().Play("bhp_down", 0, 0);

            StartCoroutine(die_animation());
            
            MainButtons.instance.balance += money_reward;
            MainButtons.instance.enemies.Remove(gameObject);
        }

        if(gameObject.GetComponent<SplineAnimate>().NormalizedTime == 1 && hp > 0)
        {
            MainButtons.instance.player_health = Mathf.Max(0, MainButtons.instance.player_health - hp);
            hp = -200;

            MainButtons.instance.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator die_animation()
    {
        Destroy(gameObject.GetComponent<Animator>());
        gameObject.GetComponent<SpriteRenderer>().sprite = die_1;
        yield return new WaitForSeconds(0.2f);

        if (die_2 != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = die_2;
            yield return new WaitForSeconds(0.2f);
        }

        gameObject.GetComponent<SplineAnimate>().Play();
        Destroy(gameObject);
    }
}
