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
    private Vector3 lastKnownPosition;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        lastKnownPosition=transform.position;
    }

    private void OnEnable()
    {
        movementInput.Enable();
    }
    private void OnDisable()
    {
        movementInput.Disable();
    }
    void FixedUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Calculate the movement direction
        
        Vector3 movement = new Vector3(movementInput.ReadValue<Vector2>().x, 0f, movementInput.ReadValue<Vector2>().y).normalized;

        // Move the player using Rigidbody.MovePosition
        Vector3 oldPosition = Vector3.zero+transform.position;
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
        UpdateAnimations(movement);

        // Rotate the player based on input
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void UpdateAnimations(Vector3 movement){
        float velocity=(lastKnownPosition-transform.position).magnitude;
        //Debug.Log(velocity);
        //Debug.Log($"{lastKnownPosition} {transform.position}");
        if(velocity>0.01 && movement!=Vector3.zero){
            animator.SetFloat("MoveSpeed",1f);
        }
        else animator.SetFloat("MoveSpeed",0f);
        lastKnownPosition=transform.position;
    }
}
