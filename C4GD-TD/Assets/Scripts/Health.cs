using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Health : MonoBehaviour
{
    public int hp;
    public int money_reward;

    public Sprite die_1;
    public Sprite die_2;

    public Sprite act_1;

    private void Start()
    {
        if(act_1 != null)
        gameObject.GetComponent<SpriteRenderer>().sprite = act_1;
    }

    void Update()
    {
        if(hp <= 0 && hp >= -100)
        {
            gameObject.GetComponent<SplineAnimate>().Pause();

            hp = -200;

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
        yield return new WaitForSeconds(0.15f);

        if (die_2 != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = die_2;
            yield return new WaitForSeconds(0.15f);
        }

        gameObject.GetComponent<SplineAnimate>().Play();
        Destroy(gameObject);
    }
}
