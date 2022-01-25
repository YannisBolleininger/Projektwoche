using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject spawnVehicle;

    public GameObject playButton;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playButton.GetComponent<Play>().GetState())
        {
            spawnVehicle.GetComponent<Spawn_Vehicle>().Move(true);
            Debug.Log("Game Started!!");
            playButton.GetComponent<Play>().SetState(false);
        }
    }
}
