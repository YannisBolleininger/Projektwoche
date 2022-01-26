using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Color c_start = new Color(10, 137, 147);

    public GameObject backgroundModel1;
    public GameObject backgroundModel2;

    public GameObject cam;

    public GameObject sceneHandler;

    void Start()
    {
        cam.GetComponent<Camera>().fieldOfView = 80;
        StartCoroutine(ChangeFOV(2));
    }

    // Update is called once per frame
    void Update()
    {
        backgroundModel1.transform.Rotate(0, 10 * Time.deltaTime, 0);
        backgroundModel2.transform.Rotate(0, -10 * Time.deltaTime, 0);
    }

    IEnumerator ChangeColor(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
    IEnumerator ChangeFOV(float duration)
    {
        float fov = cam.GetComponent<Camera>().fieldOfView;
        while (cam.GetComponent<Camera>().fieldOfView != 55)
        {
            yield return new WaitForSeconds((duration/10) / (80 - 55));
            cam.GetComponent<Camera>().fieldOfView = fov--;
        }
        StopCoroutine(ChangeFOV(1));
    }


    public void uiPlay()
    {
        sceneHandler.GetComponent<SceneHandler>().StartGame();
    }

    public void uiInfo()
    {

    }

    public void uiQuit()
    {
        Application.Quit();
    }

}
