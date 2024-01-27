using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    public Animator animator;
    private int objectMask;
    void Start()
    {
        animator=GetComponent<Animator>();
        objectMask=animator.GetLayerIndex("ObjectCarry");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GrabObject(){
        animator.SetLayerWeight(objectMask,1f);
    }
    public void DropObject(){
        animator.SetLayerWeight(objectMask,0f);
    }
}
