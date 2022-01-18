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

    public Transform projecile;

    public float range;

    GameObject enemy = null;
    GameObject target = GameObject.FindGameObjectWithTag("Target");

    void Start()
    {
        GetEnemy();
    }

    void Update()
    {
        if (testing == true ^ GetEnemyInRange() == true) //if the Enemy is in Range
        {
            StartCoroutine(LoadIndexColor());
            StopCoroutine(LoadIndexColor());
        }

    }

    void GetEnemy()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    bool GetEnemyInRange()
    {
        if (enemy != null && Vector3.Distance(this.transform.position, enemy.transform.position) < range)
        {
            AimAtEnemy();
            return true;
        }
        else return false;
    }

    void AimAtEnemy()
    {
        target.transform.position = enemy.transform.position;
    }

    double GetHealth()
    {
        double health = enemy.GetComponent<Enemy>().Health;
        return health;
    }

    IEnumerator Shoot()
    {
        if (GetHealth() > 0)
        {
            yield return new WaitForSeconds(cooldown);
            projecile.GetComponent<Projectile>().targetPos = target.transform.position;
            Instantiate(projecile, this.transform.position, Quaternion.identity);
        }
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
        StartCoroutine(Shoot());
        yield return new WaitForSeconds(0.1F);

        //reset Color

        for (int i = 0; i < topIndexes.Length; i++)
        {
            topIndexes[i].GetComponent<Renderer>().material.color = basicColor;
            topIndexes[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
        for (int i = 0; i < sideIndexes.Length; i++)
        {
            sideIndexes[i].GetComponent<Renderer>().material.color = basicColor;
            sideIndexes[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
        StopCoroutine(LoadIndexColor());
    }

}