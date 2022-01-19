using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 towerPos;
    public int projectileSpeed;
    public GameObject enemy;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = towerPos;
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, projectileSpeed * Time.deltaTime);
        if (enemy != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, enemy.transform.position, projectileSpeed * Time.deltaTime);
            this.transform.LookAt(enemy.transform.position);
            this.transform.Rotate(+90, 0, 0);

            if (this.transform.position == enemy.transform.position)
            {
                enemy.GetComponent<Enemy>().Hit(damage);
                Destroy(gameObject);
            }
        }
    }
}
