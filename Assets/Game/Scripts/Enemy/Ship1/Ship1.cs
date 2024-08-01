using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Helath playerLife))
        {
            playerLife.RecibirDanio(10);
            Destroy(gameObject);
        }
    }
}
