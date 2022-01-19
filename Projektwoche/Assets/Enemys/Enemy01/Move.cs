using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform[] waypoints;


    public float movementSpeed;
    public float turnSpeed;

    private int nextWaypoint;
    private int quantityWaypoint;


    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().waypoints;
    }


    void Update()
    {
        if (nextWaypoint != waypoints.Length)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint].transform.position, movementSpeed * Time.deltaTime); //moves towards next waypoint

            if (transform.position == waypoints[nextWaypoint].transform.position && nextWaypoint != (waypoints.Length-1))
            {
                nextWaypoint++;

                //rotation to next waypoint
                Quaternion rotate = Quaternion.LookRotation(waypoints[nextWaypoint].transform.position - this.transform.position);
                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotate, turnSpeed * Time.deltaTime);

            }
        }
    }
}