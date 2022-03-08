using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private int holder;
    private int numberOfEnemiesKilled;
    private float accumulatedTime = 0f;
    private float totalTime = 0f;
    private int totalMoves = 14;
    private int switcher = 1;
    private int numMoves = 7;
    private GameObject enemies;
    private float timeSpeed = 1f;
    [FormerlySerializedAs("enemyBullet")] public GameObject enemyBulletPrefab;
    [FormerlySerializedAs("shootingOffsetEnemy")] public Transform shootOffsetTransform;
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    //-----------------------------------------------------------------------------

    private void Start()
    {
        enemies = GameObject.FindWithTag("enemies");
        Debug.Log("start");
    }

    private void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > timeSpeed && numMoves < totalMoves)
        {
            GameObject shot = Instantiate(enemyBulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            // Debug.Log(switcher);
            enemies.transform.position = new Vector3((float) (enemies.transform.position.x + (switcher * (0.75))),
                    enemies.transform.position.y, enemies.transform.position.z);
            accumulatedTime = 0f;
            numMoves++;
            Destroy(shot, 3f);

        }

        if (numMoves == totalMoves)
        {
            numMoves = 0;
            switcher *= -1;
            enemies.transform.position = new Vector3((float) (enemies.transform.position.x),
                (float) (enemies.transform.position.y - (0.5)), enemies.transform.position.z);
            // timeSpeed -= 0.15f;
            // if (timeSpeed < 0.15f)
            // {
            //     timeSpeed = 0.15f;
            // }
        }

        // Debug.Log(numMoves);
        // Debug.Log(totalMoves);
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject); // destroy bullet
            timeSpeed -= 0.04f;
            numberOfEnemiesKilled++;
            if (timeSpeed < 0.15f)
            {
                timeSpeed = 0.15f;
            }
            Debug.Log(numberOfEnemiesKilled);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
