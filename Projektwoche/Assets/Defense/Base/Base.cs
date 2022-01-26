using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public double health;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage)
    {
        if(health > 0)
        {
            health = health - damage;
        }
        Debug.Log("HP: " + health);
    }
}
