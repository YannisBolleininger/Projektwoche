using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update

    Transform camera;
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }

}