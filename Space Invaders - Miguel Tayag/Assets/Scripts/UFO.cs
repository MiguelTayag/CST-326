using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class UFO : MonoBehaviour{

    private GameObject ufo;

    private void Start()
    {
        ufo = GameObject.FindWithTag("UFO");
    }
    
    
}