﻿//This script was created using Brackeys tutorials
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour
{
    public Slider slider;


    public void SetMaxStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }
    public void SetStamina(float stamina)
    {
        slider.value = stamina;

    }
}
