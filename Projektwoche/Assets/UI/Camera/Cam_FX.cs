using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_FX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake(float amout)
    {
        transform.position = transform.position*amout;
    }

}
