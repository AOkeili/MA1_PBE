using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {

        slider = GetComponent<Slider>();
    }

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.minValue = 0;
    }

    public void setHealthValue(float currentHealth)
    {
        slider.value = currentHealth;
        if (currentHealth == 0) transform.parent.gameObject.SetActive(false);
    }
}
