using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float Health;
    public float MaxHealth;

    public Slider healthbar;

    public Image healthIndex;


    public Color high;
    public Color mid;
    public Color low;

    void Start()
    {
        Health = MaxHealth;
        healthbar.maxValue = MaxHealth;
        healthbar.value = Health;

        healthIndex.GetComponent<Image>().color = new Color(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage)
    {
        Health = Health - damage;
        healthbar.value = Health;

        double healthPercent = (Health / MaxHealth) * 100;
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


        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
