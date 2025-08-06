using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Target_Player : MonoBehaviour
{
    public GameObject target;
    private Vector3 dir;
    public float speed;
    public int damage;

    private bool hits;
    public bool has_splash;

    void Start()
    {
        hits = true;
        dir = target.transform.position - gameObject.transform.position;
        dir.Normalize();
    }

    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && (hits || has_splash))
        {
            hits = false;
            collision.gameObject.GetComponent<Health>().hp -= damage;

            if(has_splash) Destroy(gameObject, 0.1f);
            else Destroy(gameObject);
        }
    }
}
