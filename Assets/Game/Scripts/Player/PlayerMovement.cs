using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 10f;

    private Rigidbody2D rb;
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CalculateScreenBounds();
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = movement * movementSpeed;
    }

    private void CalculateScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 lowerLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minX = lowerLeft.x;
        maxX = upperRight.x;
        minY = lowerLeft.y;
        maxY = upperRight.y;
    }

    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        transform.position = currentPosition;
    }
}
