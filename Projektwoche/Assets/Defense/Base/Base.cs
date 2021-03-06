using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image healthIndex;
    public Slider healthbar;
    public Color high;
    public Color mid;
    public Color low;

    void Start()
    {
        health = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / maxHealth;
        Debug.Log(health);
        Debug.Log(health / maxHealth);
    }

    public void Hit(float damage)
    {
        if(health > 0)
        {
            
            health = health - damage;
            double healthPercent = (health / maxHealth) * 100;
            if (healthPercent < 66.6)
            {
                healthIndex.GetComponent<Image>().color = mid;
                if (healthPercent < 33.3)
                {
                    healthIndex.GetComponent<Image>().color = low;
                }
            }
            else
            {
                healthIndex.GetComponent<Image>().color = high;
            }
        }
        Debug.Log("HP: " + health);
        Debug.Log("HP normalized: " + Mathf.InverseLerp(0, 1, health));


    }
}
