using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthh : MonoBehaviour
{
    public Slider slide;
    //public Gradient grade;
    //public Image fill;
    public void SetMaxHealth(int health)
    {
        slide.maxValue = health;
        slide.value = health;
        //grade.Evaluate(1f);
        //fill.color = grade.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slide.value = health;
        //fill.color = grade.Evaluate(slide.normalizedValue);
    }
}
