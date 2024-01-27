using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManagerScript : MonoBehaviour
{
    public targetScr[] targets;
    public float improvementValue;
    public float multiplier = 1;
    public float timer;
    public GameObject[] comboCounter;
    int comboIterator;

    

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) { timer = 0; multiplier = 1; }
        comboIterator = (int)multiplier-2;
        if (comboIterator > comboCounter.Length - 1) { comboIterator = comboCounter.Length - 1; }
        SetComboVisibility();
    }
    public void PerformPie()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesPie && !targets[i].isLost)
            {
                targets[i].val += improvementValue*multiplier;                
            }
        }
        multiplier = 1;
    }
    void SetComboVisibility()
    {
        for(int i = 0;i < comboCounter.Length; i++)
        {
            comboCounter[i].SetActive(i== comboIterator);
        }
    }
    public void PerformBanana()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesBanana && !targets[i].isLost)
            {
                targets[i].val += improvementValue * multiplier;
            }
        }
        multiplier = 1;
    }

    public void PerformGun()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesGun && !targets[i].isLost)
            {
                targets[i].val += improvementValue * multiplier;               
            }
        }
        multiplier = 1;
    }

    public void PerformHammer()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesHammer && !targets[i].isLost)
            {
                targets[i].val += improvementValue * multiplier;                
            }
        }
        multiplier = 1;
    }

    public void PerformCatch()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesCatch && !targets[i].isLost)
            {
                targets[i].val += improvementValue * multiplier;                
            }
        }
        multiplier = 1;
    }

    public void RemoveStar()
    {

    }
}
