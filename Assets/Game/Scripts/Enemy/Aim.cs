using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Transform player;
    public Transform ship; 
    public float rotationSpeed = 5f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        shipAim();
    }

    public void shipAim()
    {

        if (player != null && ship != null)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = player.position - ship.position;

            // Calcula el ángulo en el plano 2D (eje z)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Crea la rotación deseada en el eje z
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            // Rota la torreta suavemente hacia el jugador
            ship.rotation = Quaternion.Lerp(ship.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
