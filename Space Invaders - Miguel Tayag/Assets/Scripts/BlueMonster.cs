using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BlueMonster : MonoBehaviour
{
    private GameObject blueMonster;

    private void Start()
    {
        blueMonster = GameObject.FindWithTag("BlueMonster");
    }
    
    
}