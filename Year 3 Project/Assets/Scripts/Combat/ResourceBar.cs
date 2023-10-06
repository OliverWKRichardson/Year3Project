using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider slider;

    public void SetMax(int maxAmount)
    {
        slider.maxValue = maxAmount;
    }

    public void Set(int Amount)
    {
        slider.value = Amount;
    }
}
