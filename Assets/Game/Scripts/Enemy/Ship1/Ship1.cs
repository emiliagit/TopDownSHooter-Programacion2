using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1 : MonoBehaviour
{

    public GameObject firePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Helath playerLife))
        {
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(fire, 1f);
            playerLife.RecibirDanio(10);
            Destroy(gameObject);
        }
    }
}
