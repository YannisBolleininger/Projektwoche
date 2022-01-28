using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu_Info : MonoBehaviour
{
    //Towers
    public GameObject tower01;
    public GameObject tower02;
    public GameObject tower03;
    public GameObject tower04;
    

    public GameObject text;

    void Start()
    {
    }
    void Update()
    {
       // OnMouseOver();  
    }

    private void OnMouseOver()
    {
        text.GetComponent<Text>().text = GetTower();
    }

    string GetTower()
    {
        string ret = null;
        try
        {
            switch (this.name)
            {
                case "UI_Tower01": //Tower01
                    ret = $"Range: {tower01.GetComponent<Tower>().range}\nDamage: {tower01.GetComponent<Tower>().projectile.GetComponent<Projectile>().damage}";
                    break;

                case "UI_Tower02": //Tower02, not existing yet
                    ret = null;
                    break;
            }
        }
        catch (System.Exception e)
        {
            e = new System.Exception("Error, probably the name");
            throw;
        }

        return ret;
    }
}