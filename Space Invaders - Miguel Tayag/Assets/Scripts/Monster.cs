using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindWithTag("Monster");
    }

    // Update is called once per frame
    
}
