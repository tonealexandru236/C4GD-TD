using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int level;
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
        if (gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a == 1)
            MainButtons.instance.dis_all_ranges();

        if (gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a == 0)
            StartCoroutine(show_update());

        gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_app");
    }

    public IEnumerator show_update()
    {
        //is_upg_open = true;

        yield return new WaitForSeconds(0.1f);

        string actual_name = "", actual_upg = "Max Level";
        float actual_cost = 0;

        if (GetComponent<SpriteRenderer>().sprite.name.Substring(0,3) == "car")
        {
            actual_name = "Carrot Archer";
            if (level == 1) { actual_upg = "Increase Range by 1"; actual_cost = 200; }
            else if (level == 2) { actual_upg = "Shoots two carrots at the same time"; actual_cost = 300; }
            else if (level == 3) { actual_upg = "Decrease attack speed by 0.2s"; actual_cost = 300; }
            else if (level == 4) { actual_upg = "Shoots three carrots at the same time"; actual_cost = 500; }
        }

        MainButtons.instance.Upgrade_screen(GetComponent<SpriteRenderer>().sprite, actual_name, level, actual_upg, actual_cost, gameObject);
        upgrade_screen.GetComponent<Animator>().Play("upgrade_left", 0, 0);
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0) && gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a != 0)
        //    gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_dis");
    }
}
