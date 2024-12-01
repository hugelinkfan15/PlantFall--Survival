using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBar : MonoBehaviour
{

    public Slider slide;

    public Gradient gradient;

    public Image fill;

    public void SetValue(float value)
    { 
        slide.value = value;

        fill.color = gradient.Evaluate(slide.normalizedValue);
    }

    /// <summary>
    /// Sets max value and changes the current value of display bar to max
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxValue(float value)
    {
        slide.maxValue = value;
        slide.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    /// <summary>
    /// Sets max value of displayBar without adjusting the current value
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxValueOnly(float value)
    {
        slide.maxValue = value;
        fill.color = gradient.Evaluate(slide.normalizedValue);
    }
}
