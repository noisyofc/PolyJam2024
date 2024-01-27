using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    public string jumpButton = "Jump_PX";
    public LayerMask groundLayerToIgnore;
    public float raycastDistance = 0.1f;
    private BoxCollider boxCollider;
    private bool isGrounded = true;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider=GetComponent<BoxCollider>();
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        GroundCheck();
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("JumpStart",true);
        }
        else {
            animator.SetBool("JumpStart",false);
        }
    }
    

    void GroundCheck()
    {
        RaycastHit hit;
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, boxCollider.size.y/2+raycastDistance-boxCollider.center.y, ~groundLayerToIgnore);
        isGrounded = Physics.Raycast(transform.position+Vector3.up*raycastDistance, Vector3.down, out hit, raycastDistance*2, ~groundLayerToIgnore);

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
