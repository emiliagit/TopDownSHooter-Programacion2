using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship3 : MonoBehaviour
{
    public float radio = 10f; // Radio de detección del jugador
    public float moveSpeed = 0.5f; // Velocidad de movimiento del enemigo


    private bool playerDetectado = false; // Variable para controlar si el jugador ha sido detectado
    private Vector3 playerPosition;

    private Rigidbody2D Rb;

    public float hp;

    public Transform player;


    private bool isDead = false;

    public Aim aim;


    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca el transform del jugador
    }

    private void Update()
    {

        aim.shipAim();
        MovEnemy();

        if (hp == 0 && !isDead)
        {
            //Die();
        }
    }

    public void RecibirDanio()
    {
        hp -= 1;

    }

    private void MovEnemy()
    {
        if (hp > 0)
        {
            if (!playerDetectado)
            {
                // Comprueba si el jugador está dentro del radio de detección
                if (Vector3.Distance(transform.position, player.position) <= radio)
                {
                    Debug.Log("player detectado");
                    playerDetectado = true; // Marca al jugador como detectado
                    playerPosition = player.position; // Establece la posición del jugador como destino
                }
            }
            else
            {
                // Comprueba si el enemigo ha llegado a la posición del jugador
                if (Vector3.Distance(transform.position, playerPosition) <= 0.1f) // Puedes ajustar el umbral según sea necesario
                {
                    // Calcula la nueva posición del jugador
                    playerPosition = player.position;
                }

                // Calcula la dirección hacia la nueva posición del jugador
                Vector3 direction = (playerPosition - transform.position).normalized;

                // Mueve al enemigo hacia la posición del jugador
                transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent(out Helath player))
        {
            player.RecibirDanio(10);
        }
    }
}
