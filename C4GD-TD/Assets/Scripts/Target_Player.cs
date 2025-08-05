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

    void Start()
    {
        dir = target.transform.position - gameObject.transform.position;
        dir.Normalize();
    }

    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().hp -= damage;
            Destroy(gameObject);
        }
    }
}
