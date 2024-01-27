using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwableBoxScr : MonoBehaviour
{
    public bool isInAir;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.transform.tag == "floor")
        {
            isInAir = false;
        }
    }
}
