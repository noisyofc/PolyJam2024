using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis(horizontalAxis);
        float verticalInput = Input.GetAxis(verticalAxis);

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Normalize the vector to prevent faster diagonal movement

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Rotate the player based on input
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
