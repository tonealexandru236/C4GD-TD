using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutFarm : MonoBehaviour
{
    public float cooldown;
    public int money;

    void Start()
    {
        StartCoroutine(produce_money());
    }


    IEnumerator produce_money()
    {
        yield return new WaitForSeconds(cooldown * 1.5f);
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            MainButtons.instance.balance += money;
        }
    }
}
