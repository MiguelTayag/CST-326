using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform monster;

    public GameObject bulletObject;

    public Transform bulletPoint;
    public float countDown = 0f;
    public float fireRate = 1f;
    private float towerRadius = 20f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpTarget", 0f, 0.5f);
    }

    void UpTarget()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("monster");
        float shortest = Mathf.Infinity;
        GameObject nearest = null;

        foreach (GameObject enemy in enemyArray)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            //checks which enemy is closest
            if (distance < shortest)
            {
                shortest = distance;
                nearest = enemy;
            }

            if (nearest != null && shortest <= towerRadius)
            {
                monster = nearest.transform;
            }
            else
            {
                monster = null;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (monster == null)
        {
            return;
        }

        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            ShootBullet();
            countDown = 1f / fireRate;
        }
    }

    void ShootBullet()
    {
        GameObject bullets = Instantiate(bulletObject, bulletPoint.position, bulletPoint.rotation);
        Bullet bullet = bullets.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(monster);
        }
    }
}
