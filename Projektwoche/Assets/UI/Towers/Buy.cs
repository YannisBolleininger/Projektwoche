using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public float costTower01;
    public float costTower02;
    public float costTower03;
    public float costTower04;

    public float wealth;

    public GameObject uiNotify;
    public GameObject uiCoinCount;


    void Start()
    {

    }

    void Update()
    {
        uiCoinCount.GetComponent<Text>().text = wealth.ToString();
    }

    public bool CanBuy(GameObject tower)
    {
        if (GetCost(tower) <= wealth)
        {
            wealth -= GetCost(tower);
            return true;
        }
        else
        {
            return false;
        }
    }

    float GetCost(GameObject tower)
    {
        float ret = 0;
        if (tower.name == "UITower01")
        {
            ret = costTower01;
        }
        if (tower.name == "UITower02")
        {
            ret = costTower02;
        }
        if (tower.name == "UITower03")
        {
            ret = costTower03;
        }
        if (tower.name == "UITower04")
        {
            ret = costTower04;
        }
        return ret;
    }
}