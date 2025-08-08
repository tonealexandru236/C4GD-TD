using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Target_Player : MonoBehaviour
{
    public GameObject target;
    private Vector3 dir;
    public float speed;
    public int damage;

    public bool has_splash;
    public int pierces;

    private Vector3 original_target;

    void Start()
    {
        Destroy(gameObject, 7f);

        original_target = new Vector3(target.transform.position.x, target.transform.position.y, 0);

        Vector3 got = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        dir = got - gameObject.transform.position;

        dir.Normalize();
    }

    void Update()
    {
        if (Vector2.Distance(original_target, gameObject.transform.position) > 0.1f || has_splash == false)
            transform.position += dir * Time.deltaTime * speed;

        if(has_splash == false && target != null)
        {
            Vector3 got = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            dir = got - gameObject.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && (has_splash || pierces >= 1))
        {
            collision.gameObject.GetComponent<Health>().hp -= damage;
            if(collision!= null && collision.GetComponent<Animator>() != null && collision.name.Substring(0, 3) != "Bos") collision.GetComponent<Animator>().Play("hit_feedback", 0, 0);
            pierces--;

            if (has_splash) Destroy(gameObject, 0.1f);
            else if(pierces == 0) Destroy(gameObject);
        }
    }
}
