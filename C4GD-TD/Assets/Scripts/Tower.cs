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
    public int refund_price;

    private float firerate;
    private float range;

    public GameObject upgrade_screen;

    private void Start()
    {
        refund_price = price / 2;

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

        string actual_name = "", actual_upg = "Max Level", actual_description = "";
        float actual_cost = 0;

        if (GetComponent<SpriteRenderer>().sprite.name.Substring(0,3) == "car")
        {
            actual_name = "Carrot Archer"; actual_description = "Your most basic attacker. Single target, good damage, good range.";
            if (level == 1) { actual_upg = "Increase Range by 1"; actual_cost = 80; }
            else if (level == 2) { actual_upg = "Shoots two carrots at the same time"; actual_cost = 240; }
            else if (level == 3) { actual_upg = "Decrease attack speed by 0.2s"; actual_cost = 260; }
            else if (level == 4) { actual_upg = "Shoots three carrots at the same time"; actual_cost = 280; }
        }
        else if (GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "app")
        {
            actual_name = "Apple Cannon"; actual_description = "Low fire rate but with highly explosive apples. Deals AOE.";
            if (level == 1) { actual_upg = "Increase Range by 1.5"; actual_cost = 200; }
            else if (level == 2) { actual_upg = "Decrease attack speed by 0.4s"; actual_cost = 160; }
            else if (level == 3) { actual_upg = "Increases splash"; actual_cost = 300; }
            else if (level == 4) { actual_upg = "Shoots two apples at the same time"; actual_cost = 340; }
        }
        else if (GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "ban")
        {
            actual_name = "Banana Shooter"; actual_description = "Costly with high damage and range. Perfect for your average boss.";
            if (level == 1) { actual_upg = "Decrease attack speed by 0.3s"; actual_cost = 140; }
            else if (level == 2) { actual_upg = "Shoots 3 bananas at once"; actual_cost = 380; }
            else if (level == 3) { actual_upg = "Increase Range by 3"; actual_cost = 420; }
            else if (level == 4) { actual_upg = "Shoots 5 bananas at once"; actual_cost = 580; }
        }
        else if (GetComponent<SpriteRenderer>().sprite.name.Substring(0, 3) == "can")
        {
            actual_name = "Candy Piercer"; actual_description = "Short range with deadly projectiles. Master the art of the cane to make them pierce.";
            if (level == 1) { actual_upg = "Increase Range by 0.5"; actual_cost = 100; }
            else if (level == 2) { actual_upg = "Attacks now pierce through 1 enemy"; actual_cost = 280; }
            else if (level == 3) { actual_upg = "Decrease attack speed by 0.1s"; actual_cost = 240; }
            else if (level == 4) { actual_upg = "Shoots 2 canes at once"; actual_cost = 320; }
        }

        MainButtons.instance.Upgrade_screen(GetComponent<SpriteRenderer>().sprite, actual_name, level, actual_upg, actual_cost, gameObject, actual_description);
        upgrade_screen.GetComponent<Animator>().Play("upgrade_left", 0, 0);
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0) && gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color.a != 0)
        //    gameObject.transform.GetChild(0).GetComponent<Animator>().Play("range_dis");
    }
}
