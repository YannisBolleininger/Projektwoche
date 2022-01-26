using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float Health;
    public float MaxHealth;

    public Slider healthbar;

    public Image healthIndex;

    public Color high;
    public Color mid;
    public Color low;

    bool shooting = false;

    public float cooldown;

    public float damage;

    GameObject aimPoint;
    GameObject Base;

    public GameObject projectile;

    void Start()
    {
        Health = MaxHealth;
        healthbar.maxValue = MaxHealth;
        healthbar.value = Health;

        healthIndex.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        aimPoint = GameObject.Find("AimPoint");
        Base = GameObject.FindGameObjectWithTag("Base");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HitBase()
    {
        if (shooting == false)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        shooting = true;
        while (Base.GetComponent<Base>().health > 0)
        {
            yield return new WaitForSeconds(cooldown);
            Base.GetComponent<Base>().Hit(damage);
            projectile.GetComponent<Projectile_Enemy>().targetPos = aimPoint.transform.position;
            projectile.GetComponent<Projectile_Enemy>().spawnPos = this.transform.position;
            GameObject shot = Instantiate(projectile) as GameObject;
        }
    }


    public void Hit(float damage)
    {
        Health = Health - damage;
        healthbar.value = Health;

        double healthPercent = (Health / MaxHealth) * 100;
        if (healthPercent < 66.6)
        {
            healthIndex.GetComponent<Image>().color = mid;
            if (healthPercent < 33.3)
            {
                healthIndex.GetComponent<Image>().color = low;
            }
        }
        else
        {
            healthIndex.GetComponent<Image>().color = high;
        }


        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
