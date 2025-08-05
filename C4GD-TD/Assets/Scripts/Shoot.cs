using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float firerate;
    public float range;

    void Start()
    {
        StartCoroutine(do_shooting());
    }

    IEnumerator do_shooting()
    {
        while(true)
        {
            while(count_enemies() == null)
                yield return new WaitForEndOfFrame();

            yield return new WaitForSeconds(firerate);

            GameObject next_target = count_enemies();
            if(next_target != null)
            {
                Debug.Log("shoot");

                GameObject ist = Instantiate(projectile);
                ist.transform.position = gameObject.transform.position;
                ist.GetComponent<Target_Player>().target = next_target;

                //MainButtons.instance.enemies.Remove(next_target);
            }
        }
    }

    GameObject count_enemies()
    {
        int cnt = 0;
        float maxx = int.MinValue;
        GameObject rez = null;

        foreach(GameObject enemy in MainButtons.instance.enemies)
        {
            //Debug.Log(Vector2.Distance(enemy.transform.position, transform.position));
            if (Vector2.Distance(enemy.transform.position, transform.position) < range && enemy.GetComponent<SplineAnimate>() != null)
            {
                cnt++;
                Debug.Log("Ballon detected"); ///IT DETECTS
                if(enemy.GetComponent<SplineAnimate>().NormalizedTime > maxx)
                {
                    maxx = enemy.GetComponent<SplineAnimate>().NormalizedTime;
                    rez = enemy;
                }
            }
        }

        return rez;
    }
}
