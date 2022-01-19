using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform start;

    public int difficulty;
    public int round;

    public float waitingTime;

    bool enemysSpawned = false;

    public GameObject[] enemys; //stores all enemys in spawn order

    public Transform[] waypoints;

    void Start()
    {
        this.transform.position = start.transform.position;
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if(enemysSpawned && GameObject.FindGameObjectWithTag("Enemy") == null)
        {

        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            yield return new WaitForSeconds(waitingTime);
            GameObject enemy = enemys[i];
            enemy = Instantiate(enemy);
        }
        enemysSpawned=true;

    }
}
