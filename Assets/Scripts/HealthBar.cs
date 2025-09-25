using UnityEngine;
using UnityEngine.UI;       //Allows script to manage UI related stuff in Unity

public class HealthBar : MonoBehaviour
{
    public Slider slider;   //Accesses a slider component for the health bar
 
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
