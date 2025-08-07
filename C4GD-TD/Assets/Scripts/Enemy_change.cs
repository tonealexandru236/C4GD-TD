using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_change : MonoBehaviour
{
    /*public Sprite space_e1;
    public Sprite space_a1;
    public Sprite space_a2;*/

    public Sprite ocean_e1;
    public Sprite ocean_a1;
    public Sprite ocean_a2;

    private SpriteRenderer sprite;
    private Health hp;

    void Awake()
    {
        hp = GetComponent<Health>();

        /*if (SceneManager.GetActiveScene().name == "Battle1")
        {
            sprite.sprite = space_e1;
            hp.die_1 = space_a1;
            if(space_a2 != null) hp.die_2 = space_a2;
        }
        else */if(SceneManager.GetActiveScene().name == "Battle2")
        {
            /*Debug.Log(gameObject);
            Debug.Log(ocean_e1);
            Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite);
            gameObject.GetComponent<SpriteRenderer>().sprite = ocean_e1;*/
            hp.die_1 = ocean_a1;
            hp.act_1 = ocean_e1;
            if (ocean_a2 != null) hp.die_2 = ocean_a2;
        }
    }
}
