using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private float accumulatedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > 5)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
