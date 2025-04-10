/*****************************************************************************
// File Name : HealthBar.cs
// Author : Austin Nelson
// Creation Date : March 30, 2025
//
// Brief Description : This Controls Everything to do with the health bar
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
