using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndex : MonoBehaviour
{
    public LineRenderer line;
    public int segments;
    float radius;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tower = GameObject.Find("Tower01");
        radius = tower.GetComponent<Tower>().range;

        line.positionCount = segments+1;
        line.useWorldSpace = false;
        Draw();
    }
    void Update()
    {
    }

    void Draw()
    {
        float angle = 20f;
        for (int i = 0; i < segments +1; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, 0));
            angle += (360f / segments);
        }
    }
}
