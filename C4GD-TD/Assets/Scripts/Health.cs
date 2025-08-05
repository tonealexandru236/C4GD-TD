using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public int money_reward;

    void Start()
    {
        
    }

    void Update()
    {
        if(hp == 0)
        {
            hp--;
            gameObject.GetComponent<Animator>().Play("pop1");
            MainButtons.instance.balance += money_reward;

            MainButtons.instance.enemies.Remove(gameObject);
            Destroy(gameObject, 0.2f);
        }
    }
}
