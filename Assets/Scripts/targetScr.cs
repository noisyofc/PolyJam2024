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
    bool substractedStars = false;

    public pauseManagerScr pMS;
    public Animator animator;
    public string animName;
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
            if (val < 0&&!substractedStars) { FindObjectOfType<pauseManagerScr>().stars -= 1; substractedStars = true; animator.Play(animName); }
            if (val > 1) { val = 1; }

            sliderImage.color = Color.Lerp(Color.red, Color.green, valSlider.value);
        }
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
