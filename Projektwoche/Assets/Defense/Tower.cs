using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject enemy;
    public GameObject bone;
    public Vector3 aimOffset;

    public GameObject projectile;
    public GameObject gameHandler;


    public int range;
    public float cooldown;

    bool shooting;

    void Start()
    {
        shooting = false;
        gameHandler = GameObject.Find("Base");
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
        Quaternion rotate = Quaternion.LookRotation(enemy.transform.position - (bone.transform.position - aimOffset));
        bone.transform.rotation = Quaternion.RotateTowards(bone.transform.rotation, rotate, 1);
    }

    IEnumerator Shoot() // shoots every *cooldown* seconds
    {
        float health = enemy.GetComponent<Enemy>().Health;
        shooting = true;

        while(gameHandler.GetComponent<GameHandler>().EnemyAlive()) {
            yield return new WaitForSeconds(cooldown);
            health = health-1;
            projectile.GetComponent<Projectile>().enemy = enemy;
            projectile.GetComponent<Projectile>().towerPos = this.transform.position;
            GameObject shot = Instantiate(projectile) as GameObject;
        }
    }

    public override string ToString()
    {
        return $"Range: {range}\n" +
            $"Cooldown: {cooldown} seconds\n" +
            $"Damage: {projectile.GetComponent<Projectile>().damage}";
    }



}