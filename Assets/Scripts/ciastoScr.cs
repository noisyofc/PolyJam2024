using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ciastoScr : MonoBehaviour
{
    public InputAction throwInput;
    public GameObject ciasto;
    public GameObject banana;
    public Transform gunFirePt;
    public Transform hammerHitPt;
    public float hammerHitsMax = 3f;
    [Header("GFX objects")]
    public GameObject PieGFX;
    public GameObject BananaGFX;
    public GameObject GunGFX;
    public GameObject HammerGFX;
    [Header("throwing logic")]
    public Transform throwPoint;
    public float throwStrengthMin;
    public float throwStrengthMax;
    public float throwStrengthDelta;
    public float slipStrength;
    public float hitStrength;

    bool canThrow = false;
    bool holdsCiasto = false;
    bool holdsBanana = false;
    bool holdsGun = false;
    bool holdsHammer = false;
    float throwStrength;
    float hammerHits;

    private void Start()
    {
        throwStrength = throwStrengthMin;
    }

    private void OnEnable()
    {
        throwInput.Enable();
    }
    private void OnDisable()
    {
        throwInput.Disable();
    }

    public void EnterSpawner(int objectIndex)
    {
        if (!canThrow)
        {
            canThrow = true;
            switch (objectIndex)
            {
                case 0: holdsCiasto = true; break;
                case 1: holdsBanana = true; break;
                case 2: holdsGun=true; break;
                case 3: holdsHammer=true; hammerHits = hammerHitsMax; break;
            }
        }
    }

    private void Update()
    {
        PieGFX.SetActive(holdsCiasto);
        BananaGFX.SetActive(holdsBanana);
        GunGFX.SetActive(holdsGun);
        HammerGFX.SetActive(holdsHammer);
        if(canThrow)
        {
            if (throwInput.ReadValue<float>()>0)
            {
                throwStrength += throwStrengthDelta * Time.deltaTime;
                if (throwStrength > throwStrengthMax) { throwStrength = throwStrengthMax; }
            }
            else if (throwInput.WasReleasedThisFrame())
            {
                UsePower();
            }
            else
            {
                throwStrength = throwStrengthMin;
            }           
        }
    }
    public void UsePower()
    {
        if (holdsCiasto)
        {
            GameObject GO = Instantiate(ciasto, throwPoint.position, throwPoint.rotation);
            GO.GetComponent<Rigidbody>().AddForce(throwPoint.forward * throwStrength, ForceMode.Impulse);
            GO.GetComponent<BulletScript>().spawner = gameObject;
            canThrow = false;
            holdsCiasto = false;
            Destroy(GO, 10f);
        }
        else if (holdsBanana)
        {
            GameObject GO = Instantiate(banana, throwPoint.position, throwPoint.rotation);
            GO.GetComponent<Rigidbody>().AddForce(throwPoint.forward * throwStrength, ForceMode.Impulse);
            GO.GetComponent<BulletScript>().spawner = gameObject;
            canThrow = false;
            holdsBanana = false;
            Destroy(GO, 10f);
        }
        else if (holdsGun)
        {
            RaycastHit hit;
            if (Physics.Raycast(gunFirePt.position, gunFirePt.forward, out hit, 30f))
            {
                ciastoScr cS = hit.collider.GetComponent<ciastoScr>();
                if (cS != null)
                {
                    cS.HitByGun(gunFirePt.forward);
                }
                else
                {
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(gunFirePt.forward * hitStrength, ForceMode.Impulse);
                    }
                }
            }
            canThrow = false;
            holdsGun = false;
        }
        else if (holdsHammer)
        {
            RaycastHit hit;
            if (Physics.Raycast(hammerHitPt.position, -hammerHitPt.up, out hit, 3f))
            {
                ciastoScr cS = hit.collider.GetComponent<ciastoScr>();
                if (cS != null)
                {
                    cS.HitByHammer(hammerHitPt.forward);
                }
                else
                {
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(hammerHitPt.forward * hitStrength, ForceMode.Impulse);
                    }
                }
            }

            hammerHits--;

            if (hammerHits == 0)
            {
                canThrow = false;
                holdsHammer = false;
            }
        }
    }
    public void HitByCiasto()
    {
        Debug.Log(transform.name + " was hit by ciasto");
    }
    public void HitByBanana()
    {
        Debug.Log(transform.name + " was hit by banana");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * slipStrength, ForceMode.Impulse);
    }
    public void HitByGun(Vector3 dir) 
    {
        Debug.Log(transform.name + " was hit by gun");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * slipStrength, ForceMode.Impulse);
    }
    public void HitByHammer(Vector3 dir)
    {
        Debug.Log(transform.name + " was hit by hammer");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * slipStrength, ForceMode.Impulse);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(hammerHitPt.position, hammerHitPt.position - hammerHitPt.up * 3f);
    //}
}
