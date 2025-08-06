using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Health : MonoBehaviour
{
    public int hp;
    public int money_reward;

    void Start()
    {
        
    }

    void Update()
    {
        if(hp <= 0 && hp >= -100)
        {
            gameObject.GetComponent<SplineAnimate>().Pause();

            hp = -200;
            gameObject.GetComponent<Animator>().Play("pop1");
            MainButtons.instance.balance += money_reward;

            MainButtons.instance.enemies.Remove(gameObject);
            Destroy(gameObject, 0.2f);
        }

        if(gameObject.GetComponent<SplineAnimate>().NormalizedTime == 1 && hp > 0)
        {
            MainButtons.instance.player_health = Mathf.Max(0, MainButtons.instance.player_health - hp);
            hp = -200;

            MainButtons.instance.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
