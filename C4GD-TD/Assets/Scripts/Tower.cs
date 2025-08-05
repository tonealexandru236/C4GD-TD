using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int price;

    private void Start()
    {
        StartCoroutine(end_check());
    }

    private bool check = false;
    IEnumerator end_check()
    {
        yield return new WaitForSeconds(0.04f);
        check = true;
        MainButtons.instance.balance -= price;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower") && check == false)
        {
            MainButtons.instance.cant_place_tower();
            Destroy(gameObject);
        }
    }
}
