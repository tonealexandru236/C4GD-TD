using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private void OnMouseDown()
    {
        MainButtons.instance.dis_all_ranges();
        gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_app");
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0) && gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a != 0)
        //    gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_dis");
    }
}
