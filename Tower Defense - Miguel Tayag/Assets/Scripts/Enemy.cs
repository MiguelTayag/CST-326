using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    // todo #1 set up properties
    public float health = 3;
    public float maxHealth = 3;
    public GameObject healthBarUI;
    public Slider slider;

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
        health = maxHealth;
        slider.value = CalculateHealth();
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

        slider.value = CalculateHealth();
        
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            RaycastHit hit;
            if( Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.gameObject != null)
            {
                if (hit.transform.gameObject.name.Equals("monster"))
                {
                    health--;
                    if (health == 0)
                    {
                        Destroy(hit.transform.gameObject);
                        coinTScript.coins++;
                    }
                }
            }
        }
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = waypointList[targetWaypointIndex].position;
        targetPosition.y = 10;
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

        if (transform.position.x == waypointList[8].position.x && transform.position.z == waypointList[8].position.z)
        {
            Destroy(transform.gameObject);
            coinTScript.health--;
            if (coinTScript.health <= 0)
            {
                SceneManager.LoadScene("Done");
            }
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

    float CalculateHealth()
    {
        return (health / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
            coinTScript.coins++;
        }
    }
}
