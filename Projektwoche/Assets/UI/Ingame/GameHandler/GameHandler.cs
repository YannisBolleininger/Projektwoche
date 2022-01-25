using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject spawnVehicle;

    public GameObject playButton;

    public GameObject spawner;

    public GameObject ui;
    string uiNotify;

    int spawener_diff;
    int spawner_round;



    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawener_diff = spawner.GetComponent<Spawner>().difficulty;
        spawner_round = 0;


        //UI controls:
        uiNotify = GameObject.Find("Notification").GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (playButton.GetComponent<Play>().GetState())
        {
            RoundStart();
        }
        if (EnemyAlive())
        {
            if (!EnemyAlive())
            {
                PostRound();
            }
        }
        
    }

    bool EnemyAlive()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemys.Length <= 0)
        {
            return false;
        }
        else {return true;}
    }

    void PostRound()
    {
        spawner_round++;
        
        PreRound();
    }
    void PreRound()
    {
        Debug.Log($"" +
            $"Round: {spawner_round}\n" +
            $"Difficulty: {spawener_diff}\n" +
            $"Health: {this.GetComponent<Base>().health}");

        if (spawner_round > 10)
        {
            Debug.Log("Hardcore mode");
            uiNotify = "Hardcore mode!!!";
        }
    }

    void RoundStart()
    {
        uiNotify = "";
        Debug.Log("Game Started!!");
        spawnVehicle.GetComponent<Spawn_Vehicle>().Move(true);
        playButton.GetComponent<Play>().SetState(false);
    }
}
