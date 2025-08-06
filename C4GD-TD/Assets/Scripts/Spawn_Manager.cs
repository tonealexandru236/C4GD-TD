using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public GameObject boss1;

    public SplineContainer path;

    public TMP_Text waves_text;

    private int wave = 0;
    private GameObject ist;

    public void Start()
    {
        waves_text.SetText("");

        StartCoroutine(start_game());
        
    }

    IEnumerator start_game()
    {
        yield return new WaitForSeconds(5f);
        waves_text.SetText("Wave 1 / 4");
        StartCoroutine(wave1());
    }

    IEnumerator wave1()
    {
        //StartCoroutine(spawn_bloons(boss1, 1f, 1));
        StartCoroutine(spawn_bloons(enemy4, 1.2f, 8)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy4, 1f, 12)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.9f, 20)); yield return new WaitForSeconds(21f);
        StartCoroutine(spawn_bloons(enemy4, 0.8f, 14));

        while(MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 20;
        waves_text.SetText("Wave 2 / 4");
        StartCoroutine(wave2());
    }

    IEnumerator wave2()
    {
        StartCoroutine(spawn_bloons(enemy4, 0.62f, 18)); yield return new WaitForSeconds(16f);
        StartCoroutine(spawn_bloons(enemy2, 1.2f, 5)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 0.9f, 7)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 10)); StartCoroutine(spawn_bloons(enemy4, 2.5f, 6)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 0.7f, 8)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy2, 0.7f, 8)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy2, 0.8f, 14)); StartCoroutine(spawn_bloons(enemy4, 2f, 8)); yield return new WaitForSeconds(24f);
        StartCoroutine(spawn_bloons(enemy2, 0.65f, 20));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 30;
        waves_text.SetText("Wave 3 / 4");
        StartCoroutine(wave3());
    }

    IEnumerator wave3()
    {
        StartCoroutine(spawn_bloons(enemy4, 1f, 50)); yield return new WaitForSeconds(3f);
        StartCoroutine(spawn_bloons(enemy2, 0.52f, 20)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 0.52f, 20)); StartCoroutine(spawn_bloons(enemy4, 1f, 10)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 0.42f, 28)); yield return new WaitForSeconds(16f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 8)); StartCoroutine(spawn_bloons(enemy4, 0.2f, 35)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy2, 0.55f, 46)); yield return new WaitForSeconds(28f);
        StartCoroutine(spawn_bloons(enemy2, 0.5f, 34)); StartCoroutine(spawn_bloons(enemy4, 0.2f, 50));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 45;
        waves_text.SetText("Wave 4 / 4");
        StartCoroutine(wave4());
    }

    IEnumerator wave4()
    {
        StartCoroutine(spawn_bloons(enemy3, 0.8f, 8)); yield return new WaitForSeconds(8f);
        StartCoroutine(spawn_bloons(enemy3, 0.82f, 12)); StartCoroutine(spawn_bloons(enemy4, 0.5f, 14)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy2, 0.5f, 20)); StartCoroutine(spawn_bloons(enemy3, 1f, 10)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 2.5f, 10)); StartCoroutine(spawn_bloons(enemy4, 3f, 8)); yield return new WaitForSeconds(2f); StartCoroutine(spawn_bloons(enemy3, 0.6f, 15)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy2, 0.2f, 40)); StartCoroutine(spawn_bloons(enemy3, 0.5f, 3)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy3, 0.52f, 8)); yield return new WaitForSeconds(5f);
        StartCoroutine(spawn_bloons(enemy3, 0.5f, 8)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy4, 0.1f, 400)); yield return new WaitForSeconds(5f); StartCoroutine(spawn_bloons(enemy2, 0.4f, 50)); yield return new WaitForSeconds(5f);
        StartCoroutine(spawn_bloons(enemy3, 0.5f, 42));

        StartCoroutine(spawn_bloons(boss1, 1f, 1));


        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 65;
        waves_text.SetText("DONE");

        //StartCoroutine(wave4());
    }

    IEnumerator spawn_bloons(GameObject type, float cd, int amt)
    {
        for(int i=0; i<amt; i++)
        {
            Debug.Log("KOK");
            ist = Instantiate(type); ist.GetComponent<SplineAnimate>().Container = path; MainButtons.instance.enemies.Add(ist);
            if (type == boss1) ist.GetComponent<Animator>().Play("black_hole_idle");

            yield return new WaitForSeconds(cd);
        }
    }

    private void Update()
    {
        Debug.Log(MainButtons.instance.enemies.Count);
    }
}
