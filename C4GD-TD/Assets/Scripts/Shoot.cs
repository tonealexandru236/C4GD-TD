using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float firerate;
    public float range;
    public int amt;

    public float proj_size_multiplier;
    public int pierce;

    void Start()
    {
        pierce = 1;
        proj_size_multiplier = 1;
        StartCoroutine(do_shooting());
    }

    IEnumerator do_shooting()
    {
        while(true)
        {
            yield return new WaitForSeconds(firerate / 2 - (0.1f * (amt-1)/2));

            while (count_enemies() == null)
            {
                yield return new WaitForEndOfFrame();
                gameObject.GetComponent<Animator>().SetBool("can_shoot", false);
            }

            gameObject.GetComponent<Animator>().SetBool("can_shoot", true);
            yield return new WaitForSeconds(firerate / 2 - (0.1f * (amt - 1) / 2));

            GameObject next_target = count_enemies();
            if(next_target != null)
            {
                //Debug.Log("shoot");

                /// Shooting animation here

                for (int i = 0; i < amt; i++)
                {
                    next_target = count_enemies();
                    if (next_target != null)
                    {

                        GameObject ist = Instantiate(projectile);
                        ist.transform.position = gameObject.transform.position;
                        ist.GetComponent<Target_Player>().target = next_target;

                        ist.transform.localScale = new Vector3(ist.transform.localScale.x * proj_size_multiplier, ist.transform.localScale.y * proj_size_multiplier, ist.transform.localScale.z * proj_size_multiplier);
                        ist.GetComponent<Target_Player>().pierces = pierce;

                        yield return new WaitForSeconds(0.15f);
                    }
                }

                //MainButtons.instance.enemies.Remove(next_target);
            }
            else
                gameObject.GetComponent<Animator>().SetBool("can_shoot", false);
        }
    }

    GameObject count_enemies()
    {
        int cnt = 0;
        float maxx = int.MinValue;
        GameObject rez = null;

        if (MainButtons.instance.enemies.Count > 0)
        {
            foreach (GameObject enemy in MainButtons.instance.enemies)
            {
                //Debug.Log(Vector2.Distance(enemy.transform.position, transform.position));
                if (enemy != null && Vector2.Distance(enemy.transform.position, transform.position) < range && enemy.GetComponent<SplineAnimate>() != null)
                {
                    cnt++;
                    //Debug.Log("Ballon detected"); ///IT DETECTS
                    if (enemy.GetComponent<SplineAnimate>().NormalizedTime > maxx)
                    {
                        maxx = enemy.GetComponent<SplineAnimate>().NormalizedTime;
                        rez = enemy;
                    }
                }
            }
        }

        return rez;
    }
}
