using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower01 : MonoBehaviour
{
    public float cooldown;
    public Color loadedColor = new Color(0, 160, 255, 255);
    public Color basicColor = new Color(0, 0, 0,255);
    public Color shootColor = new Color(233, 0, 14, 255);

    public bool testing = false;

    public GameObject[] topIndexes;
    public GameObject[] sideIndexes;

    private GameObject[] enemys;

    public float range;


    void Start()
    {

    }

    void Update()
    {
        if (testing == true ^ CheckRange(GetEnemy()) == true) //if the Enemy is in Range
        {
            StartCoroutine(LoadIndexColor());
        }

    }

    GameObject GetEnemy() //finds the enemy with the leats Distance
    {
        GameObject enemy = null;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length > 0)
        {

            for (int i = 0; i < enemys.Length; i++)
            {
                if (i! > enemys.Length)
                {
                    if (Vector3.Distance(enemys[i].transform.position, this.transform.position) < Vector3.Distance(enemys[i + 1].transform.position, this.transform.position))
                    {
                        enemy = enemys[i];
                    }
                    else
                    {
                        enemy = enemys[i + 1];
                    }
                }
                else
                {
                    enemy = enemys[i];
                }
            }
            GameObject.Find("Target").transform.position = enemy.transform.position;
            return enemy;
        }
        else
            return null;
    }

    bool CheckRange(GameObject enemy)
    {
        if(Vector3.Distance(enemy.transform.position, this.transform.position) < range)
            return true;
        else
            return false;
    }

    IEnumerator LoadIndexColor() //changes the Color on the Top
    {
        for (int i = 0; i < topIndexes.Length; i++)
        {
            yield return new WaitForSeconds(cooldown / topIndexes.Length);
            topIndexes[i].GetComponent<Renderer>().material.color = loadedColor;
            topIndexes[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        yield return new WaitForSeconds(0.5F);
        for (int i = 0; i < sideIndexes.Length; i++)
        {
            sideIndexes[i].GetComponent <Renderer>().material.color = shootColor;
            sideIndexes[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        yield return new WaitForSeconds(0.1F);

        //reset Color 
        for (int i = 0; i < topIndexes.Length; i++)
        {
            topIndexes[i].GetComponent<Renderer>().material.color = basicColor;
            topIndexes[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        yield return new WaitForSeconds(0.5F);
        for (int i = 0; i < sideIndexes.Length; i++)
        {
            sideIndexes[i].GetComponent<Renderer>().material.color = basicColor;
            sideIndexes[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }

    }
    
}