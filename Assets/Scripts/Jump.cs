using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    public LayerMask groundLayerToIgnore;
    public float raycastDistance = 0.5f;
    private BoxCollider boxCollider;
    private bool isGrounded = true;
    public Animator animator;
    public InputAction jumpInput;
    private float lastJump=Mathf.NegativeInfinity;
    public float JumpCooldownInSeconds=1f;
    private Movement movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider=GetComponent<BoxCollider>();
        animator=GetComponent<Animator>();
        movement=GetComponent<Movement>();
    }
    void Update()
    {
        GroundCheck();
        HandleInput();
    }
    void HandleInput()
    {
        if (jumpInput.WasPerformedThisFrame() && isGrounded && Time.time+JumpCooldownInSeconds>=lastJump && movement.canMove)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("JumpStart",true);
            lastJump=Time.time;
        }
        else {
            animator.SetBool("JumpStart",false);
        }
    }

    private void OnEnable()
    {
        jumpInput.Enable();
    }
    private void OnDisable()
    {
        jumpInput.Disable();
    }
    

    void GroundCheck()
    {
        RaycastHit hit;
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, boxCollider.size.y/2+raycastDistance-boxCollider.center.y, ~groundLayerToIgnore);
        isGrounded = Physics.Raycast(transform.position+Vector3.up*0.1f, Vector3.down, out hit, raycastDistance*2, ~groundLayerToIgnore);

        // Ignore the collider attached to this GameObject
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isGrounded = false;
        }
        animator.SetBool("IsGrounded",isGrounded);
        
        // Debug.DrawRay(transform.position, Vector3.down*(boxCollider.size.y/2+raycastDistance-boxCollider.center.y));
        //Debug.DrawRay(transform.position, Vector3.down*raycastDistance);

        // Print the result (for debugging purposes)
        //Debug.Log("Is Grounded: " + isGrounded);
    }
}
