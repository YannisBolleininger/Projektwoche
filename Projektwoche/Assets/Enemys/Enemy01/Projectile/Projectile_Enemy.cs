using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Enemy : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 spawnPos;
    public int projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = spawnPos;
    }

    // Update is called once per frame
    void Update()
    {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, projectileSpeed * Time.deltaTime);
            this.transform.LookAt(targetPos);
            this.transform.Rotate(+90, 0, 0);

        if (this.transform.position == targetPos)
        {
            Destroy(gameObject);
        }

    }
}
