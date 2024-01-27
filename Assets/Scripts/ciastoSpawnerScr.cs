using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ciastoSpawnerScr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ciastoScr cS = other.GetComponent<ciastoScr>();
        if(cS != null)
        {
            cS.EnterSpawner();
        }
    }
}
