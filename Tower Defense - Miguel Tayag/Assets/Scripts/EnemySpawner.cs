using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnerLoc;
    public float time;
    public int enemyCount = 10;
    public int enemySpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (time >= 5f)
        {
            Debug.Log("ins");
            Instantiate(enemyPrefab, spawnerLoc.position, GameObject.Find("monster").transform.rotation);
            time = 0f;
            enemyCount++;
        }
    }
}
