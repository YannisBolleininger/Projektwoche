using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 towerPos;
    public int projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = towerPos;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, projectileSpeed * Time.deltaTime);

        if(this.transform.position == targetPos)
        {
            Destroy(gameObject);
        }
    }
}
