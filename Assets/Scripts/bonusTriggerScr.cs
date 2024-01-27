using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bonusTriggerScr : MonoBehaviour
{
    public scoreManagerScript sMC;
    public float multiplierBonus;
    public float multiplierTime;
    public float maxCooldown;
    float cooldown;
    private void Start()
    {
        sMC = FindObjectOfType<scoreManagerScript>();
        cooldown = 0;
    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
        //gameObject.GetComponent<MeshRenderer>().enabled = cooldown < 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (cooldown < 0)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                sMC.multiplier += multiplierBonus;
                if (sMC.timer < multiplierTime)
                {
                    sMC.timer = multiplierTime;
                }
                cooldown = maxCooldown;
            }
        }
    }
}
