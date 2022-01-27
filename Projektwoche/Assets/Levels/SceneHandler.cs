using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void SwitchScene(int index, float after)
    {
        StartCoroutine(SwitchSceneIE(index, after));
    }
    IEnumerator SwitchSceneIE(int index, float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }
}
