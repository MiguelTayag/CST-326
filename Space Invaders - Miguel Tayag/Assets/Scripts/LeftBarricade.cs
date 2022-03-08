using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBarricade : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject leftBarricade;
    private int leftBarricadeHealthBar = 4;

    void Start()
    {
        leftBarricade = GameObject.Find("LeftBarricade");
        leftBarricadeHealthBar = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       Destroy(collision.gameObject); // destroy bullet

    }
}
