using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public float throwForce = 10f; // Adjust the throw force as needed
    public LayerMask throwableLayer; // Set the layer for objects that can be thrown

    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    private Vector3 originalPosition;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heldObject == null)
            {
                PickUpObject();
            }
            else
            {
                ThrowObject();
            }
        }
    }

    void PickUpObject()
    {
        // Raycast to check if there's a throwable object in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, throwableLayer))
        {
            heldObject = hit.collider.gameObject;
            heldObjectRb = heldObject.GetComponent<Rigidbody>();

            if (heldObjectRb != null)
            {
                // Save the original position of the object
                originalPosition = heldObject.transform.position;

                // Disable the object's gravity and make it kinematic while held
                heldObjectRb.useGravity = false;
                heldObjectRb.isKinematic = true;

                // Attach the object to the player
                heldObject.transform.parent = transform;
            }
        }
    }

    void ThrowObject()
    {
        if (heldObject != null)
        {
            // Detach the object from the player
            heldObject.transform.parent = null;

            // Enable gravity and make the object non-kinematic
            heldObjectRb.useGravity = true;
            heldObjectRb.isKinematic = false;

            // Apply a force to throw the object
            Vector3 throwDirection = transform.forward; // Adjust the throw direction as needed
            heldObjectRb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            // Reset the held object variables
            heldObject = null;
            heldObjectRb = null;
        }
    }
}
