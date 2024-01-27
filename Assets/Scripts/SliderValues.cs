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

    void Start()
    {
        valueSlider = GetComponent<Slider>();
        valueSlider.value = maxValue; // Start with the slider at its maximum value
    }

    void Update()
    {
        // Simulate a slow fall of the slider value
        valueSlider.value = Mathf.Lerp(valueSlider.value, minValue, fallSpeed * Time.deltaTime);
        sliderImage.color = Color.Lerp(Color.red, Color.green, valueSlider.value);
    }
}
