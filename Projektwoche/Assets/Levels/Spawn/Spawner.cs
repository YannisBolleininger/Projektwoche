using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform start;

    public int difficulty;
    public int round;

    public float waitingTime;

    public GameObject[] enemys; //stores all enemys in spawn order

    public Transform[] waypoints;

    public GameObject vehicle; 


    void Start()
    {
        // vehicle.GetComponent<Spawn_Vehicle>().Move(true);
    }

    public void VehicleOnPos()
    {
        vehicle.GetComponent<Spawn_Vehicle>().Move(false);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            yield return new WaitForSeconds(waitingTime);
            GameObject enemy = enemys[i];
            enemy.transform.position = this.transform.position;
            enemy = Instantiate(enemy);
        }

    }
}
