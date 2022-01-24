using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    //Towers
    GameObject tower01;

    public GameObject txt_name;
    public GameObject txt_text;

    void Start()
    {
        tower01 = GameObject.FindGameObjectWithTag("Tower01");
    }
    void Update()
    {
        //OnMouseOver();
    }

    private void OnMouseOver()
    {
        txt_text.GetComponent<Text>().text = GetTower().ToString();
        txt_name.GetComponent<Text>().text = this.name;
    }

    string GetTower()
    {
        string ret = null;

        try
        {
            switch (this.name)
            {
                case "UI_Tower01": //Tower01
                    ret = $"Range: \nDamage: ";
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