using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBarricade : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject rightBarricade;
    private int rightBarricadeHealthBar;

    void Start()
    {
        rightBarricade = GameObject.Find("RightBarricade");
        rightBarricadeHealthBar = 4;
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