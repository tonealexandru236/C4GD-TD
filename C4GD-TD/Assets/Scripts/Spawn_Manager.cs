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
        yield return new WaitForSeconds(5f); cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave1());
    }

    private float max_level = 5;
    private float cur_level = 0;

    IEnumerator wave1()
    {
        //StartCoroutine(spawn_bloons(boss1, 1f, 1)); yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy4, 1.2f, 8)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy4, 1f, 12)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.9f, 18)); yield return new WaitForSeconds(21f);
        StartCoroutine(spawn_bloons(enemy4, 0.85f, 14)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy4, 0.7f, 8));

        while(MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 25; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave2());
    }

    IEnumerator wave2()
    {
        StartCoroutine(spawn_bloons(enemy4, 0.62f, 18)); yield return new WaitForSeconds(18f);
        StartCoroutine(spawn_bloons(enemy2, 1.2f, 5)); yield return new WaitForSeconds(16f);
        StartCoroutine(spawn_bloons(enemy2, 0.9f, 7)); yield return new WaitForSeconds(16f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 10)); StartCoroutine(spawn_bloons(enemy4, 2.5f, 6)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 0.7f, 8)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy2, 0.7f, 8)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy2, 0.8f, 12)); StartCoroutine(spawn_bloons(enemy4, 2f, 8)); yield return new WaitForSeconds(25f);
        StartCoroutine(spawn_bloons(enemy2, 0.7f, 12));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 35; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave3());
    }

    IEnumerator wave3()
    {
        StartCoroutine(spawn_bloons(enemy4, 1f, 40)); yield return new WaitForSeconds(3f);
        StartCoroutine(spawn_bloons(enemy2, 0.6f, 16)); yield return new WaitForSeconds(18f);
        StartCoroutine(spawn_bloons(enemy2, 0.55f, 18)); yield return new WaitForSeconds(18f);
        StartCoroutine(spawn_bloons(enemy2, 0.5f, 22)); yield return new WaitForSeconds(18f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 8)); StartCoroutine(spawn_bloons(enemy4, 0.2f, 35)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy2, 0.6f, 26)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 0.5f, 24)); StartCoroutine(spawn_bloons(enemy4, 0.2f, 50));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 50; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave4());
    }

    IEnumerator wave4()
    {
        StartCoroutine(spawn_bloons(enemy3, 1f, 6)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy3, 0.85f, 10)); StartCoroutine(spawn_bloons(enemy4, 0.5f, 14)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy2, 0.5f, 16)); StartCoroutine(spawn_bloons(enemy3, 1f, 8)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy2, 2.5f, 10)); StartCoroutine(spawn_bloons(enemy4, 3f, 8)); yield return new WaitForSeconds(2f); StartCoroutine(spawn_bloons(enemy3, 1f, 12)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy2, 0.5f, 16)); StartCoroutine(spawn_bloons(enemy3, 0.5f, 3)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy3, 0.6f, 7)); yield return new WaitForSeconds(5f);
        StartCoroutine(spawn_bloons(enemy3, 0.6f, 7)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy4, 0.3f, 80)); yield return new WaitForSeconds(2f); StartCoroutine(spawn_bloons(enemy2, 0.8f, 30)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy3, 0.75f, 16));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 70; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave5());
    }

    IEnumerator wave5()
    {
        ///32 seconds
        StartCoroutine(spawn_bloons(enemy4, 0.35f, 60)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy2, 0.65f, 30)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy3, 1.25f, 15)); yield return new WaitForSeconds(2f);

        StartCoroutine(spawn_bloons(enemy2, 0.3f, 10)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy3, 0.3f, 10)); yield return new WaitForSeconds(1f);

        StartCoroutine(spawn_bloons(enemy2, 0.3f, 10)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy3, 0.3f, 10)); yield return new WaitForSeconds(1f);

        StartCoroutine(spawn_bloons(enemy4, 1.5f, 10)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy2, 2f, 10)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy3, 1f, 15)); yield return new WaitForSeconds(25f);

        /// 18 seconds
        
        StartCoroutine(spawn_bloons(enemy4, 0.3f, 60)); 
        StartCoroutine(spawn_bloons(enemy2, 0.6f, 30));
        StartCoroutine(spawn_bloons(enemy3, 1.2f, 15)); yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy2, 0.3f, 50)); yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 0.8f, 10));
        StartCoroutine(spawn_bloons(enemy3, 0.3f, 20)); yield return new WaitForSeconds(10f);


        StartCoroutine(spawn_bloons(boss1, 1f, 1));


        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 120; //cur_level++;
        //waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        waves_text.SetText("DONE");
        //StartCoroutine(wave5());
    }

    IEnumerator spawn_bloons(GameObject type, float cd, int amt)
    {
        for(int i=0; i<amt; i++)
        {
            //Debug.Log("KOK");
            ist = Instantiate(type); ist.GetComponent<SplineAnimate>().Container = path; MainButtons.instance.enemies.Add(ist);
            if (type == boss1) ist.GetComponent<Animator>().Play("black_hole_idle");

            yield return new WaitForSeconds(cd);
        }
    }

    private void Update()
    {
        //Debug.Log(MainButtons.instance.enemies.Count);
    }
}
