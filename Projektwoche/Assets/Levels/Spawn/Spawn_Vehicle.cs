using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Vehicle : MonoBehaviour
{
    public float speed;

    public GameObject spawner;

    bool move = false;

    public Transform start;

    private void Start()
    {
        this.transform.position = start.transform.position;
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }
    private void Update()
    {
        if (move)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, spawner.transform.position, speed * Time.deltaTime);
            if (this.transform.position == spawner.transform.position)
            {
                spawner.GetComponent<Spawner>().VehicleOnPos();
            }
        }
    }

    public void Move(bool state)
    {
        move = state;
    }

}
