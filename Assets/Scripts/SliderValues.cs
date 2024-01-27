using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValues : MonoBehaviour
{
    public float fallSpeed = 0.0001f; // Adjust the fall speed as needed
    public float minValue = 0f;
    public float maxValue = 100f;

    public Slider valueSlider;
    public Image sliderImage;
    float val;
    float mult = 1f;
    void Start()
    {
        valueSlider = GetComponent<Slider>();
        valueSlider.value = maxValue; // Start with the slider at its maximum value
        val = minValue;
    }

    void Update()
    {
        val += fallSpeed * Time.deltaTime*mult;
        if(val>maxValue || val<minValue) { mult *= -1; }
        valueSlider.value = Mathf.Lerp(maxValue, minValue, val);

        sliderImage.color = Color.Lerp(Color.red, Color.green, valueSlider.value);
    }
}
