using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    bool start = false;
    bool playAnim = false;
    public GameObject lights;
    public Color activate;
    public Color activated;

    void Start()
    {
       lights.GetComponent<Light>().color = activate;
    }

    void Update()
    {
        if (playAnim) 
        {
            lights.GetComponent <Light>().color = activated;
        }
    }

    public void SetState(bool state)
    {
        Debug.Log("start");
        start = state;
        playAnim = true;
    }
    

    public bool GetState()
    {
        return start;
    }

}
