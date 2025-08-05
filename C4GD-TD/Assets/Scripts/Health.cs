using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;

    void Start()
    {
        
    }

    void Update()
    {
        if(hp == 0)
        {
            gameObject.GetComponent<Animator>().Play("pop1");
            Destroy(gameObject, 0.5f);
        }
    }
}
