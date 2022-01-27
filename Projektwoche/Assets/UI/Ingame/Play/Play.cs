using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    bool start = false;
    bool playAnim = false;
    public GameObject lights;
    public Color notPlaying;
    public Color playing;

    public GameObject spawner;

    void Start()
    {
       lights.GetComponent<Light>().color = notPlaying;
    }

    void Update()
    {
        if (GetState()) 
        {
            lights.GetComponent <Light>().color = playing;
        }
        if (!GetState())
        {
            lights.GetComponent<Light>().color = notPlaying;
        }
    }

    public void SetState(bool state)
    {
        start = state;
        playAnim = state;
        if (start && GameObject.Find("Spawner").GetComponent<Spawner>().round > 0)
        {
            spawner.GetComponent<Spawner>().VehicleOnPos();
        }
    }
    

    public bool GetState()
    {
        return start;
    }

}
