using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform start;

    public int difficulty;
    public int round;
    public int hpMultiply;
    public int amout;

    public float waitingTime;

    public GameObject[] allEnemys;

    public Transform[] waypoints;

    public GameObject vehicle; 


    public void VehicleOnPos()
    {
        vehicle.GetComponent<Spawn_Vehicle>().Move(false);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //DiffHandler();
        for (int i = 0; i < amout; i++)
        {
            yield return new WaitForSeconds(waitingTime);
            GameObject enemy = GetEnemy();
            enemy.transform.position = this.transform.position;
            enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health * hpMultiply;
            enemy = Instantiate(enemy);
        }

    }

    void DiffHandler()
    {

        //Helath of Enemy
        if (round > 5)
        {
            difficulty = 2;

            if (round > 7)
            {
                difficulty = 3;
                if (round > 10)
                {
                    difficulty++;
                }
            }
        }
        if(round > 10)
        {
            hpMultiply = (difficulty / 2);
        }
        else { hpMultiply = difficulty; }
        
        //amount of Enemys
        if(round < 10)
        {
            amout = 8;
            if(round < 7)
            {
                amout = 6;
                if(round < 5)
                {
                    amout = 4;
                    if(round < 2)
                    {
                        amout = 2;
                    }
                }
            }
        }
        else
        {
            amout++;
        }

        //Type of Enemy
        
    }

    GameObject GetEnemy()
    {
        int lengt = amout;
        if (amout < allEnemys.Length)
        {
            lengt = allEnemys.Length;
        }
        if (round < lengt ^ round < 5)
        {
            int i = 0;
            for (i = 0;  i < amout / lengt; i++)
            {
                // enemy = allEnemys[1];
                Debug.Log("Enemy1");

            }
            for (i = amout / lengt; i < amout / (lengt / 2); i++)
            {
                //enemy = allEnemys[2];
                Debug.Log("Enemy2");
            }
            if(round > 5)
            {

            }
        }
        else
        {
            int i = 0;
            for (i = 0; i < amout / lengt; i++)
            {
                // enemy = allEnemys[1];
                Debug.Log("Enemy1");

            }
            for (i = amout / lengt; i < amout / (lengt / 2); i++)
            {
                //enemy = allEnemys[2];
                Debug.Log("Enemy2");
            }
            for (i = amout / (lengt / 2); i < (amout / lengt) + (amout / (lengt / 2)); i++)
            {
                //enemy = allEnemys[3];
                Debug.Log("Enemy3");
            }
            for (i = (amout / lengt) + (amout / (lengt / 2)); i < amout; i++)
            {
                //enemy = allEnemys[4];
                Debug.Log("Enemy4");
            }

        }
        return null;
    }
}
