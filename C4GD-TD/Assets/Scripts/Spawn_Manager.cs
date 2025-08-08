using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public GameObject boss1;

    public SplineContainer path;

    public TMP_Text waves_text;

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

    private float max_level = 7;
    private float cur_level = 0;

    IEnumerator wave1()
    {
        StartCoroutine(spawn_bloons(boss1, 1f, 1)); yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy4, 1.2f, 8)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy4, 1f, 12)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.72f, 5)); yield return new WaitForSeconds(7f);
        StartCoroutine(spawn_bloons(enemy4, 0.9f, 16)); yield return new WaitForSeconds(21f);
        StartCoroutine(spawn_bloons(enemy4, 0.85f, 12)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy4, 0.7f, 8));

        while(MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 40; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave2());
    }

    IEnumerator wave2()
    {
        StartCoroutine(spawn_bloons(enemy4, 0.62f, 18)); yield return new WaitForSeconds(18f);
        StartCoroutine(spawn_bloons(enemy2, 1.2f, 5)); yield return new WaitForSeconds(16f);
        StartCoroutine(spawn_bloons(enemy2, 0.9f, 7)); yield return new WaitForSeconds(16f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 10)); StartCoroutine(spawn_bloons(enemy4, 2.5f, 6)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 8)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 8)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy2, 0.8f, 12)); StartCoroutine(spawn_bloons(enemy4, 2f, 8)); yield return new WaitForSeconds(25f);
        StartCoroutine(spawn_bloons(enemy2, 0.7f, 12));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 60; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave3());
    }

    IEnumerator wave3()
    {
        StartCoroutine(spawn_bloons(enemy4, 1.5f, 35)); yield return new WaitForSeconds(3f);
        StartCoroutine(spawn_bloons(enemy2, 0.75f, 15)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 0.75f, 16)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 0.75f, 20)); yield return new WaitForSeconds(20f);
        StartCoroutine(spawn_bloons(enemy2, 1f, 8)); StartCoroutine(spawn_bloons(enemy4, 0.5f, 25)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy2, 0.65f, 24)); yield return new WaitForSeconds(22f);
        StartCoroutine(spawn_bloons(enemy2, 0.6f, 18)); StartCoroutine(spawn_bloons(enemy4, 0.2f, 50));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 80; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave4());
    }

    IEnumerator wave4()
    {
        StartCoroutine(spawn_bloons(enemy3, 1f, 6)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy3, 0.85f, 10)); StartCoroutine(spawn_bloons(enemy4, 0.5f, 14)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy2, 0.65f, 12)); StartCoroutine(spawn_bloons(enemy3, 1f, 8)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy2, 2.5f, 10)); StartCoroutine(spawn_bloons(enemy4, 3f, 8)); yield return new WaitForSeconds(2f); StartCoroutine(spawn_bloons(enemy3, 1f, 12)); yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy2, 0.65f, 12)); StartCoroutine(spawn_bloons(enemy3, 0.5f, 3)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy3, 0.6f, 7)); yield return new WaitForSeconds(5f);
        StartCoroutine(spawn_bloons(enemy3, 0.6f, 7)); yield return new WaitForSeconds(12f);
        StartCoroutine(spawn_bloons(enemy4, 0.3f, 80)); yield return new WaitForSeconds(2f); StartCoroutine(spawn_bloons(enemy2, 0.8f, 30)); yield return new WaitForSeconds(14f);
        StartCoroutine(spawn_bloons(enemy3, 0.75f, 16));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 100; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave5());
    }

    IEnumerator wave5()
    {
        ///32 seconds
        StartCoroutine(spawn_bloons(enemy4, 1f, 30)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy2, 1.5f, 20)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy3, 2f, 15)); yield return new WaitForSeconds(6f);

        StartCoroutine(spawn_bloons(enemy2, 0.4f, 6)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy3, 0.5f, 5)); yield return new WaitForSeconds(3f);

        StartCoroutine(spawn_bloons(enemy2, 0.4f, 6)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy3, 0.5f, 5)); yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 2f, 10)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy2, 1.5f, 12)); yield return new WaitForSeconds(1f);
        StartCoroutine(spawn_bloons(enemy3, 2f, 10)); yield return new WaitForSeconds(18f);

        /// 18 seconds

        StartCoroutine(spawn_bloons(enemy4, 1f, 30));
        StartCoroutine(spawn_bloons(enemy2, 1.5f, 20));
        StartCoroutine(spawn_bloons(enemy3, 2f, 15)); yield return new WaitForSeconds(2f);

        //StartCoroutine(spawn_bloons(boss1, 1f, 1));

        StartCoroutine(spawn_bloons(enemy2, 1f, 20)); yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 0.8f, 10));
        StartCoroutine(spawn_bloons(enemy3, 0.8f, 8)); yield return new WaitForSeconds(10f);


        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 120; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        StartCoroutine(wave6());
    }

    IEnumerator wave6()
    {
        ///30 seconds
        StartCoroutine(spawn_bloons(enemy1, 3f, 10)); yield return new WaitForSeconds(35f);

        ///50 seconds
        StartCoroutine(spawn_bloons(enemy3, 5f, 10)); yield return new WaitForSeconds(3f);
        StartCoroutine(spawn_bloons(enemy4, 2.5f, 20)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy1, 2.5f, 20));
        StartCoroutine(spawn_bloons(enemy2, 10f, 5));

        yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy1, 1f, 3));

        yield return new WaitForSeconds(15f);
        StartCoroutine(spawn_bloons(enemy1, 1f, 3));

        yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy1, 0.8f, 5));


        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 140; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        //waves_text.SetText("DONE");
        StartCoroutine(wave7());
    }

    IEnumerator wave7()
    {
        StartCoroutine(spawn_bloons(enemy4, 5f, 20)); yield return new WaitForSeconds(2f);

        ///25 seconds
        StartCoroutine(spawn_bloons(enemy3, 2.5f, 10)); yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy1, 2.5f, 10)); yield return new WaitForSeconds(30f);

        ///25 seconds
        StartCoroutine(spawn_bloons(enemy3, 1.2f, 20)); yield return new WaitForSeconds(10f);
        StartCoroutine(spawn_bloons(enemy1, 3f, 5)); yield return new WaitForSeconds(20f);

        ///40 seconds
        StartCoroutine(spawn_bloons(enemy2, 2f, 10)); 
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(spawn_bloons(enemy3, 0.6f, 3));
            StartCoroutine(spawn_bloons(enemy1, 0f, 1));
            yield return new WaitForSeconds(3f);
        }

        yield return new WaitForSeconds(6f);
        StartCoroutine(spawn_bloons(enemy4, 1f, 25));
        StartCoroutine(spawn_bloons(enemy3, 3f, 10));
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(spawn_bloons(enemy1, 0.6f, 3));
            StartCoroutine(spawn_bloons(enemy3, 0f, 1));
            yield return new WaitForSeconds(3f);
        }

        StartCoroutine(spawn_bloons(boss1, 1f, 1));

        while (MainButtons.instance.enemies.Count > 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(5f);

        MainButtons.instance.balance += 140; cur_level++;
        waves_text.SetText("Wave " + cur_level.ToString() + " / " + max_level.ToString());
        waves_text.SetText("DONE");
        //StartCoroutine(wave7());
    }

    IEnumerator spawn_bloons(GameObject type, float cd, int amt)
    {
        for(int i=0; i<amt; i++)
        {
            //Debug.Log("KOK");
            ist = Instantiate(type); ist.GetComponent<SplineAnimate>().Container = path; MainButtons.instance.enemies.Add(ist);
            if (type == boss1)
            {
                
                if(SceneManager.GetActiveScene().name == "Battle2")
                {
                    ist.transform.localScale = new Vector3(ist.transform.localScale.x / 120, ist.transform.localScale.y / 120, ist.transform.localScale.z / 120);
                    ist.GetComponent<CircleCollider2D>().radius *= 120;
                    ist.GetComponent<Animator>().Play("shark_idle");
                }
                else
                {
                    ist.GetComponent<Animator>().Play("black_hole_idle");
                }
            }

            yield return new WaitForSeconds(cd);
        }
    }

    private void Update()
    {
        //Debug.Log(MainButtons.instance.enemies.Count);
    }
}
