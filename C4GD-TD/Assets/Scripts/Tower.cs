using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    private int level;
    public int price;

    private float firerate;
    private float range;

    public GameObject upgrade_screen;

    private void Start()
    {
        level = 1; //is_upg_open = false;
        firerate = GetComponent<Shoot>().firerate;
        range = GetComponent<Shoot>().range;

        upgrade_screen = GameObject.Find("Canvas").transform.Find("Upgrades").gameObject;

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

    //public bool is_upg_open;

    private void OnMouseDown()
    {
        MainButtons.instance.dis_all_ranges();

        if (gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a == 0)
            StartCoroutine(show_update());

        gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_app");   
    }

    IEnumerator show_update()
    {
        //is_upg_open = true;

        yield return new WaitForSeconds(0.1f);
        MainButtons.instance.Upgrade_screen(GetComponent<SpriteRenderer>().sprite, gameObject.name, level, "+ upgrade +", 300);
        upgrade_screen.GetComponent<Animator>().Play("upgrade_left", 0, 0);
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0) && gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a != 0)
        //    gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_dis");
    }
}
