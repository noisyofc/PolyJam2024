using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaBulletScr : BulletScript
{
    public GameObject bananaOnFloor;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "floor")
        {
            Instantiate(bananaOnFloor, collision.contacts[0].point, bananaOnFloor.transform.rotation);
            Destroy(gameObject);
        }
    }
}
