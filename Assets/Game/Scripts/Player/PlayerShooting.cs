using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float fireRate = 1f;

    float nextFireTime;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 shootDirection = (mousePosition - transform.position).normalized;

        transform.up = shootDirection;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Establece el tiempo del próximo disparo.
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, transform.rotation);
    }
    public void AttackSpeedIncrease(float increase)
    {
        fireRate = fireRate * increase;
    }
}
