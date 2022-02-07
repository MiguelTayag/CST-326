using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collider " + collider.name + " entered slot " + this.name);
        // Ball ball = gameObject.AddComponent<Ball>();
        // ball.Start();
    }
}
