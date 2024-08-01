using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2 : MonoBehaviour
{
    private Transform player;

    public Aim aim;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float bulletForce = 7f;

    public float detectionRadius = 6f;

    private void Start()
    {
        //player = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {

        aim.shipAim();


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {

            if (Time.time >= nextFireTime)
            {
                AttackPlayer();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

    }

    private void AttackPlayer()
    {
        Vector2 directionToPlayer = (player.position - projectileSpawnPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.LookRotation(directionToPlayer));


        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = directionToPlayer * bulletForce;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
