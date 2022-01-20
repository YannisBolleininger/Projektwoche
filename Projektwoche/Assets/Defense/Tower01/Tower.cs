using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject enemy;
    public GameObject target;
    public GameObject rangeIndex;

    public GameObject projectile;


    public int range;
    public float cooldown;

    bool shooting;

    void Start()
    {
        shooting = false;
    }

    void Update()
    {
        if (CheckForEnemy()) //checks if enemy is in scene and in range
        {
            PlaceTarget();
            if(CheckRange())
            {
                if (shooting == false)
                {
                    StartCoroutine(Shoot());
                }
            }
        }

    }

    bool CheckForEnemy() //checks if enemy is in scene
    {
        GameObject l_enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (l_enemy != null)
        {
            enemy = l_enemy;
            return true;
        }
        else {
            shooting = false;
            return false;
        }
    }

    bool CheckRange() //checks if enemy is in range
    {
        if (Vector3.Distance(this.transform.position, enemy.transform.position) < range)
        {
            Debug.Log($"range: {Vector3.Distance(this.transform.position, enemy.transform.position)}");
            return true;            
        }
        else
        {
            shooting = false;
            return false;
        }
    }

    void PlaceTarget() //places target to enemy position
    {
        target.transform.position = enemy.transform.position;
    }

    IEnumerator Shoot() // shoots every *cooldown* seconds
    {
        float health = enemy.GetComponent<Enemy>().Health;
        shooting = true;

        while(health > 0) {
            yield return new WaitForSeconds(cooldown);
            health = health-1;
            //projectile.GetComponent<Projectile>().targetPos = enemy.transform.position;
            projectile.GetComponent<Projectile>().enemy = enemy;
            projectile.GetComponent<Projectile>().towerPos = this.transform.position;
            GameObject shot = Instantiate(projectile) as GameObject;
        }
    }

}