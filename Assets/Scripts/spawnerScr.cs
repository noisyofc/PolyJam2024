using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScr : MonoBehaviour
{
    [Header("0 = ciasto, 1 = banan, 2 = gun, 3 = hammer")]
    public int objectIndex;
    private void OnTriggerEnter(Collider other)
    {
        ciastoScr cS = other.GetComponent<ciastoScr>();
        if(cS != null)
        {
            cS.EnterSpawner(objectIndex);
        }
    }
}
