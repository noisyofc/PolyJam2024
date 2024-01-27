using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManagerScript : MonoBehaviour
{
    public targetScr[] targets;
    public float improvementValue;
    public void PerformPie()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesPie && !targets[i].isLost)
            {
                targets[i].val += improvementValue;
            }
        }
    }

    public void PerformBanana()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesBanana && !targets[i].isLost)
            {
                targets[i].val += improvementValue;
            }
        }
    }

    public void PerformGun()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesGun && !targets[i].isLost)
            {
                targets[i].val += improvementValue;
            }
        }
    }

    public void PerformHammer()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesHammer && !targets[i].isLost)
            {
                targets[i].val += improvementValue;
            }
        }
    }

    public void PerformCatch()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].likesCatch && !targets[i].isLost)
            {
                targets[i].val += improvementValue;
            }
        }
    }
}
