using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public InputAction movementInput;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movementInput.Enable();
    }
    private void OnDisable()
    {
        movementInput.Disable();
    }
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Calculate the movement direction
        
        Vector3 movement = new Vector3(movementInput.ReadValue<Vector2>().x, 0f, movementInput.ReadValue<Vector2>().y).normalized;

        // Move the player using Rigidbody.MovePosition
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);

        // Rotate the player based on input
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
