using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // todo #1 set up properties
    public int health = 3;

    public float speed = 3f;

    public int coins = 3;

    public List<Transform> waypointList;

    private int targetWaypointIndex;

    private TextMeshProUGUI coinsText;
    private CoinTracker coinTScript;
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public delegate void EnemyDied(Enemy deadEnemy);

    public event EnemyDied OnEnemyDied;
    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        coinsText = GameObject.Find("Coins Text").GetComponent<TextMeshProUGUI>();
        coinTScript = coinsText.GetComponent<CoinTracker>();
        // todo #2
        //   Place our enemy at the starting waypoint
        targetWaypointIndex = 0;
        transform.position = waypointList[targetWaypointIndex].position;
        targetWaypointIndex = 1;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            RaycastHit hit;
            if( Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null )
            {
                health--;
                Debug.Log("The health is " + health);
                if (health == 0)
                {
                    Destroy(hit.transform.gameObject);
                    coinTScript.coins++;
                }
            }
        }
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = waypointList[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;
        // todo #4 Check if destination reaches or passed and change target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1 && targetWaypointIndex != waypointList.Count - 1)
        {
            TargetNextWaypoint();
        }
        Vector3 newPosition = transform.position;
        newPosition += movementDir * speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        // transform.position = newPosition;
        transform.LookAt(targetPosition);
        
        bool enemyDied = false;
        if (enemyDied)
        {
            OnEnemyDied?.Invoke(this);
        }
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
        if (targetWaypointIndex == waypointList.Count)
        {
            Debug.Log("movement");
        }
        targetWaypointIndex++;

    }
}
