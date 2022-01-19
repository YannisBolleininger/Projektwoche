using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject enemy;
    public GameObject target;

    public GameObject projectile;


    public int range;
    public float cooldown = 10;
    void Start()
    {
        
    }

    void Update()
    {
        if (CheckForEnemy()) //checks if enemy is in scene and in range
        {
            PlaceTarget();
            if(CheckRange())
            {
                StartCoroutine(Shoot());
            }
            StopCoroutine(Shoot());
        }
        else StopCoroutine(Shoot());

    }

    bool CheckForEnemy() //checks if enemy is in scene
    {
        GameObject l_enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (l_enemy != null)
        {
            enemy = l_enemy;
            return true;
        }
        else return false;
    }

    bool CheckRange() //checks if enemy is in range
    {
        if (Vector3.Distance(this.transform.position, enemy.transform.position) < range)
            return true;
        else return false;
    }

    void PlaceTarget() //places target to enemy position
    {
        target.transform.position = enemy.transform.position;
    }

    IEnumerator Shoot() // shoots every *cooldown* seconds
    {
        float health = enemy.GetComponent<Enemy>().Health;
        while(health > 0)
        {
            yield return new WaitForSeconds(cooldown);
            GameObject shot = Instantiate(projectile) as GameObject;
            projectile.GetComponent<Projectile>().targetPos = enemy.transform.position;
            projectile.GetComponent<Projectile>().towerPos = this.transform.position;
        }
    }

}