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
    GameObject uiFadeToBlack;
    GameObject uiGameOver;

    int round;

    int spawener_diff;
    int spawner_round;

    int a = 0;


    bool fadeStart = false;

    public bool enemysSpawned = false;


    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawener_diff = spawner.GetComponent<Spawner>().difficulty;
        spawner_round = 0;

        round = GameObject.Find("Spawner").GetComponent<Spawner>().round;

        //UI controls:
        uiNotify = GameObject.Find("Notification").GetComponent<Text>().text;
        uiFadeToBlack = GameObject.Find("GameOverBackdrop");
        uiGameOver = GameObject.Find("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (playButton.GetComponent<Play>().GetState())
        {
            RoundStart();
        }
        if (enemysSpawned)
        {
            if (!EnemyAlive())
            {
                PostRound();
            }
        }

        if(this.GetComponent<Base>().health < 0)
        {
            GameOver();
        }


    }

    bool EnemyAlive()
    {
        GameObject enemys = GameObject.FindGameObjectWithTag("Enemy");
        if(enemys == null)
        {
            Debug.Log("alive");
            return false;
        }
        else {
            Debug.Log("notalive");
            return true;
        }
    }

    void PostRound()
    {
        spawner_round++;
        uiNotify = $"Wave {round} survived";

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
        a = 0;
    }

    void RoundStart()
    {
        uiNotify = "";
        Debug.Log("Game Started!!");
        spawnVehicle.GetComponent<Spawn_Vehicle>().Move(true);
        playButton.GetComponent<Play>().SetState(false);
    }

    void GameOver()
    {
        uiGameOver.GetComponent<Text>().enabled = true;
        uiFadeToBlack.GetComponent<Image>().enabled = true;

        if (!fadeStart)
        {
            StartCoroutine(FadeToBlack(1));
        }
        //scene handler -> main menu
    }

    IEnumerator FadeToBlack(float duration)
    {
        fadeStart = true;
        while (uiFadeToBlack.GetComponent<Image>().color != new Color(0, 0, 0, 255))
        {
            a++;
            yield return new WaitForSeconds(duration / 255);
            uiFadeToBlack.GetComponent<Image>().color = new Color(0, 0, 0, a +1);
        }
    }
}
