using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 mousePos;

    public GameObject tower01;
    public GameObject uiTower01;
    public GameObject tower02;
    public GameObject uiTower02;
    public GameObject tower03;
    public GameObject uiTower03;
    public GameObject tower04;
    public GameObject uiTower04;

    GameObject clickedTower;

    bool followMouse = false;

    Vector3 mousePos3D;
    Vector3 originalPos;

    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
        }
        if (followMouse)
        {
            Ray ray = cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                mousePos3D = raycastHit.point;
            }
            GetUITower(clickedTower).transform.position = mousePos3D;

            if (Input.GetMouseButtonDown(0))
            {
                followMouse = false;
                Instantiate(GetTower(clickedTower), mousePos3D, Quaternion.identity);
                GetUITower(clickedTower).transform.position = originalPos;
            }


        }
    }


    public void OnClick(GameObject uitower)
    {
        clickedTower = uitower;
        originalPos = uitower.transform.position;
        followMouse = true;
    }

    GameObject GetTower(GameObject uitower)
    {
        GameObject ret = null;
        if(uitower.name == "UITower01")
        {
            ret = tower01;
        }
        if(uitower.name == "UITower02")
        {
            ret = tower02;
        }
        if(uitower.name == "UITower03")
        {
            ret = tower03;
        }
        if(uitower.name == "UITower04")
        {
            ret = tower04;
        }
        return ret;
    }
    
    GameObject GetUITower(GameObject uitower)
    {
        GameObject ret = null;
        if(uitower.name == "UITower01")
        {
            ret = uiTower01;
        }
        if(uitower.name == "UITower02")
        {
            ret = uiTower02;
        }
        if(uitower.name == "UITower03")
        {
            ret = uiTower03;
        }
        if(uitower.name == "UITower04")
        {
            ret = uiTower04;
        }
        return ret;
    }


}