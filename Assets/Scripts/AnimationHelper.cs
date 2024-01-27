using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    public Animator animator;
    private int objectMask;
    private int oneHandMask;
    void Start()
    {
        animator=GetComponent<Animator>();
        objectMask=animator.GetLayerIndex("ObjectCarry");
        oneHandMask=animator.GetLayerIndex("OneHand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GrabObject(){
        animator.SetLayerWeight(objectMask,1f);
    }
    public void ThrowObject(){
        animator.SetLayerWeight(objectMask,0f);
        animator.SetBool("ThrowObject",false);
    }
    public void OneHand(){
        animator.SetBool("SwingHammer",false);
        animator.SetLayerWeight(oneHandMask,1f);        
    }
    public void OneHandDrop(){
        animator.SetLayerWeight(oneHandMask,0f);
        animator.SetBool("ThrowBanana",false);
        animator.SetBool("SwingHammer",false);
    }
    public void FinishHammerSwingAnim()
    {
        animator.SetBool("SwingHammer",false);
    }
}
