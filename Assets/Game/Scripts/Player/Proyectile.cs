using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed = 15f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.TryGetComponent(out EnemyLife enemy))
        //{
        //    enemy.LoseHealth(1);
        //    Destroy(gameObject);
        //}
        //else if (collision.gameObject.CompareTag("Terrain"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
