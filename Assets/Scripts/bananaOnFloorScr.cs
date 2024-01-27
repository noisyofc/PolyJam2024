using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaOnFloorScr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ciastoScr cS = other.GetComponent<ciastoScr>();
        if(cS != null)
        {
            cS.HitByBanana();
            Destroy(gameObject);
        }
    }
}
