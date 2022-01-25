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

    public GameObject[] enemys; //stores all enemys in spawn order

    public Transform[] waypoints;

    public GameObject vehicle; 


    public void VehicleOnPos()
    {
        vehicle.GetComponent<Spawn_Vehicle>().Move(false);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < amout; i++)
        {
            yield return new WaitForSeconds(waitingTime);
            GameObject enemy = enemys[i];
            enemy.transform.position = this.transform.position;
            DiffHandler();
            enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health * hpMultiply;
            enemy = Instantiate(enemy);
        }

    }

    void DiffHandler()
    {
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
    }
}
