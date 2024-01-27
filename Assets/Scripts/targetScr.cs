using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetScr : MonoBehaviour
{
    public bool likesPie;
    public bool likesBanana;
    public bool likesGun;
    public bool likesHammer;
    public bool likesCatch;
    public float fallingSpeed;
    public Slider valSlider;
    public Image sliderImage;
    public bool isLost;

    public float val;

    public pauseManagerScr pMS;
    void Start()
    {
        pMS = FindObjectOfType<pauseManagerScr>();
        valSlider.value = 1; // Start with the slider at its maximum value
        val = 1;
    }


    void Update()
    {
        if (!pMS.isPaused)
        {
            val -= fallingSpeed * Time.deltaTime;
            valSlider.value = Mathf.Lerp(0, 1, val);
            if (val < 0) { /*Debug.Log(transform.name + " is at 0");*/ }
            if (val > 1) { val = 1; }

            sliderImage.color = Color.Lerp(Color.red, Color.green, valSlider.value);
        }
    }
}
