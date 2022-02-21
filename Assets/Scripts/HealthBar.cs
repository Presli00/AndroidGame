using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        healthText.text = health.ToString();
    }
}
