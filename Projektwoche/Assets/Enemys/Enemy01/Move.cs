using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform[] waypoints;
    public float movementSpeed;

    private int nextWaypoint;
    private int quantityWaypoint;


    void Start()
    { 
        int waypointsQuantity = waypoints.Length;
         //set start Postion to start waypoint
        //transform.position = start.transform.position;
    }


    void Update()
    {

        if (this.transform.position != end.transform.position)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint].transform.position, movementSpeed * Time.deltaTime); //moves towards next waypoint

            if (transform.position == waypoints[nextWaypoint].transform.position)
            {
                nextWaypoint++;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.forward, waypoints[nextWaypoint].position - transform.position), 10 * Time.time); //rotates towards next waypoint
            }
        }
        else
        {
               
        }
    }
}