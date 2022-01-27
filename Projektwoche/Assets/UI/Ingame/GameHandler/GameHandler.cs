using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject spawnVehicle;
    public GameObject playButton;
    public GameObject spawner;

    public GameObject ui;
    string uiNotify;
    GameObject uiFadeToBlack;
    GameObject uiGameOver;
    public GameObject buy;

    public GameObject sceneHandler;

    int round;

    int spawener_diff;
    int spawner_round;

    bool postRound = false;
    public bool enemysSpawned = false;
    public bool gameStarted = false;
    bool roundStarted = false;

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawener_diff = spawner.GetComponent<Spawner>().difficulty;
        spawner.GetComponent<Spawner>().round = 0;

        //UI controls:
        uiNotify = GameObject.Find("Notification").GetComponent<Text>().text;
        uiFadeToBlack = GameObject.Find("GameOverBackdrop");
        uiGameOver = GameObject.Find("GameOver");

        buy.GetComponent<Buy>().wealth = 50;

    }

    // Update is called once per frame
    void Update()
    {
        if (playButton.GetComponent<Play>().GetState())
        {
            if (!roundStarted)
            {
                roundStarted = true;
                RoundStart();
            }
        }
        if (enemysSpawned)
        {
            if (!EnemyAlive() && !postRound)
            {
                PostRound();
            }
        }

        if(this.GetComponent<Base>().health <= 0)
        {
            GameOver();
        }


    }

    public bool EnemyAlive()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            postRound = false;   
            return true;
        }
        else {
            return false;
        }
    }

    void PostRound()
    {
        Debug.Log("postround");
        postRound = true;
        gameStarted = false;
        spawner.GetComponent<Spawner>().round +=1;
        uiNotify = $"Wave {round} survived";
        buy.GetComponent<Buy>().wealth += 100;

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles = GameObject.FindGameObjectsWithTag("Projectile");
            Destroy(projectiles[i]);
        }

        playButton.GetComponent<Play>().SetState(false);
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
        gameStarted = true;
        enemysSpawned = false;
        if (spawner.GetComponent<Spawner>().round != 0)
        {
            spawner.GetComponent<Spawner>().VehicleOnPos();
        }
    }

    void GameOver()
    {
        uiGameOver.GetComponent<Text>().enabled = true;
        uiFadeToBlack.GetComponent<Image>().enabled = true;
        uiFadeToBlack.GetComponent<Image>().color = new Color(0, 0, 0, 50);
        sceneHandler.GetComponent<SceneHandler>().SwitchScene(0,5);
    }

}