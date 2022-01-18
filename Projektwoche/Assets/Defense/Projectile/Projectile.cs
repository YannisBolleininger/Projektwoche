using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPos;
    public int projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(this.transform.position, 0);
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, projectileSpeed * Time.deltaTime);
    }
}
