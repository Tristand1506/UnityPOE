using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    [SerializeField]
    private float HEALTH_MAX;

    private float health;

    Slider healthSlider;

    private void Start()
    {
        health = HEALTH_MAX;
        healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();
        healthSlider.value = 1;
    }

    public void Damage (float amount)
    {
        healthSlider = (gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>();
        health -= amount;
        if (healthSlider!=null)
        {
            healthSlider.value = health / HEALTH_MAX;
        }
       
        if (health<=0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
