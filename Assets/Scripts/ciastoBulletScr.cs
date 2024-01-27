using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ciastoBulletScr : MonoBehaviour
{
    public GameObject spawner;
    private void OnCollisionEnter(Collision collision)
    {
        ciastoScr cS = collision.gameObject.GetComponent<ciastoScr>();
        if (collision.gameObject != spawner)
        {
            if (cS != null)
            {
                cS.HitByCiasto();
            }
            Destroy(gameObject);
        }
    }
}
