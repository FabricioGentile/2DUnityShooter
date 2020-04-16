using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    //creates a slider
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        //fill the bar with the HP of the player
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        //updates the health  bar
        slider.value = health;
    }
}
