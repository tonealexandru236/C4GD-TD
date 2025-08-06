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

        waves_text.SetText("Wave 1 / 2");

        StartCoroutine(spawn_bloons(enemy4, 1.2f, 10));
        yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy4, 1f, 12));
        yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy4, 0.7f, 5));
        yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 0.7f, 5));
        yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 0.7f, 5));
        yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 0.6f, 10));
        yield return new WaitForSeconds(9f);

        StartCoroutine(spawn_bloons(enemy4, 0.7f, 25));
        yield return new WaitForSeconds(20f);

        StartCoroutine(spawn_bloons(enemy4, 0.5f, 15));
        yield return new WaitForSeconds(9f);

        waves_text.SetText("Wave 2 / 2");
        yield return new WaitForSeconds(5f);

        StartCoroutine(spawn_bloons(enemy4, 0.6f, 20));
        yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy2, 1f, 12));
        yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy2, 0.8f, 15));
        yield return new WaitForSeconds(15f);

        StartCoroutine(spawn_bloons(enemy2, 0.9f, 20));
        yield return new WaitForSeconds(2f);
        StartCoroutine(spawn_bloons(enemy4, 3f, 6));
        yield return new WaitForSeconds(21f);

        StartCoroutine(spawn_bloons(enemy2, 0.6f, 20));
        yield return new WaitForSeconds(12f);

        StartCoroutine(spawn_bloons(enemy2, 0.75f, 25));
        yield return new WaitForSeconds(3f);
        StartCoroutine(spawn_bloons(enemy4, 2f, 8));
        yield return new WaitForSeconds(20f);

        StartCoroutine(spawn_bloons(enemy2, 0.55f, 30));
        yield return new WaitForSeconds(15f);

        waves_text.SetText("DONE");
    }

    IEnumerator spawn_bloons(GameObject type, float cd, int amt)
    {
        for(int i=0; i<amt; i++)
        {
            Debug.Log("KOK");
            ist = Instantiate(type); ist.GetComponent<SplineAnimate>().Container = path; MainButtons.instance.enemies.Add(ist);
            yield return new WaitForSeconds(cd);
        }
    }
}
