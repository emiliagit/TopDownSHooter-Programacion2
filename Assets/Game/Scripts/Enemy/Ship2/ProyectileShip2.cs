using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileShip2 : MonoBehaviour
{
    public GameObject firePrefab;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colision con player");
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(fire, 1f);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent(out Helath player))
        {
            player.RecibirDanio(10);
            Debug.Log("vida restada");
        }
    }
}
