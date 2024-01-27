using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Throwing : MonoBehaviour
{
    public float throwForce = 10f; // Adjust the throw force as needed
    public LayerMask throwableLayer; 
    public Transform holdingPosObj;
    public Transform raycastStartObj;
    public InputAction throwInput;

    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    public AnimationHelper animationHelper;
    void Start(){
        animationHelper=GetComponent<AnimationHelper>();
    }

    void Update()
    {
        HandleInput();
    }
    private void OnEnable()
    {
        throwInput.Enable();
    }
    private void OnDisable()
    {
        throwInput.Disable();
    }

    void HandleInput()
    {
        if (throwInput.ReadValue<float>()>0)
        {
            if (heldObject == null)
            {
                PickUpObject();
            }            
        }
        else
        {
            ThrowObjectInvoke();
        }
    }

    void PickUpObject()
    {
        // Raycast to check if there's a throwable object in front of the player
        RaycastHit hit;
        if (Physics.Raycast(raycastStartObj.position, -transform.up*2-transform.right, out hit, 5.5f, throwableLayer))
        {
            heldObject = hit.collider.gameObject;
            heldObjectRb = heldObject.GetComponent<Rigidbody>();

            if (heldObjectRb != null)
            {
                throwableBoxScr tBS = heldObject.GetComponent<throwableBoxScr>();

                if (tBS != null && tBS.isInAir) { FindAnyObjectByType<scoreManagerScript>().PerformCatch(); }

                // Disable the object's gravity and make it kinematic while held
                heldObjectRb.useGravity = false;
                heldObjectRb.isKinematic = true;

                // Attach the object to the player
                heldObject.transform.parent = transform;

                heldObject.transform.position = holdingPosObj.position;
                heldObject.transform.rotation = holdingPosObj.rotation;
                heldObject.layer = LayerMask.NameToLayer("Holding");

                // Animator
                animationHelper.GrabObject();
            }
        }
    }

    void ThrowObjectInvoke(){
        animationHelper.animator.SetBool("ThrowObject",true);
    }
    public void ThrowObjectFromAnimation(){
        ThrowObject();
        animationHelper.ThrowObject();
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
            throwableBoxScr tBS = heldObject.GetComponent<throwableBoxScr>();
             
            if (tBS != null) { tBS.isInAir = true; }


            heldObject.layer = LayerMask.NameToLayer("Throwable");

            // Reset the held object variables
            heldObject = null;
            heldObjectRb = null;   

            //temp
            //animationHelper.DropObject();         
            //animationHelper.animator.SetBool("ThrowObject",true);
        }
    }
}
