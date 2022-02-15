using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    private int scale = 1;
    private int length = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ball") && this.name.Equals("PowerUp1"))
        {
            scale++;
            Debug.Log("Yes!");
            GameObject.FindWithTag("ball").GetComponent<Rigidbody>().transform.localScale = new Vector3(scale, scale, scale);
        }
        if (collider.CompareTag("ball") && this.name.Equals("PowerUp2"))
        {
            Debug.Log("No!");
            length += 3;
            GameObject.Find("Player1").GetComponent<Rigidbody>().transform.localScale = new Vector3(length, 1, 1);
            GameObject.Find("Player2").GetComponent<Rigidbody>().transform.localScale = new Vector3(length, 1, 1);
        }
        
    }
}
