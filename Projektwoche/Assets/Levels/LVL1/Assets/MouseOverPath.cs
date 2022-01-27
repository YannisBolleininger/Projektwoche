using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverPath : MonoBehaviour
{
    public GameObject tower;
    bool mouseOverPath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseOver()
    {
        mouseOverPath = true;
    }

}
