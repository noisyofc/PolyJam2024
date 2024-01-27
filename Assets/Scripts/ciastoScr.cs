using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ciastoScr : MonoBehaviour
{
    public InputAction throwInput;
    public GameObject ciasto;
    public GameObject PieGFX;
    public Transform throwPoint;
    public float throwStrengthMin;
    public float throwStrengthMax;
    public float throwStrengthDelta;

    bool canThrowPie = false;
    float throwStrength;

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

    public void EnterSpawner()
    {
        canThrowPie = true;
    }

    private void Update()
    {
        PieGFX.SetActive(canThrowPie);
        if(canThrowPie)
        {
            if (throwInput.ReadValue<float>()>0)
            {
                throwStrength += throwStrengthDelta * Time.deltaTime;
                if (throwStrength > throwStrengthMax) { throwStrength = throwStrengthMax; }
            }
            else if (throwInput.WasReleasedThisFrame())
            {
                GameObject GO = Instantiate(ciasto, throwPoint.position, throwPoint.rotation);
                GO.GetComponent<Rigidbody>().AddForce(throwPoint.forward * throwStrength, ForceMode.Impulse);
                GO.GetComponent<ciastoBulletScr>().spawner = gameObject;
                canThrowPie = false;
                Destroy(GO, 10f);
            }
            else
            {
                throwStrength = throwStrengthMin;
            }           
        }
    }

    public void HitByCiasto()
    {
        Debug.Log(transform.name + " was hit by ciasto");
    }
}
