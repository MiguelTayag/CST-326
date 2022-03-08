using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PurpMonster : MonoBehaviour
{
    private GameObject purpMonster;

    private void Start()
    {
        purpMonster = GameObject.FindWithTag("PurpMonster");
    }
    
}