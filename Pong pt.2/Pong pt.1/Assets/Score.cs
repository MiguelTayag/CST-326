using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro scoreText;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Left Score: " + GameObject.FindWithTag("ball").GetComponent<Ball>().player1Score + "\n" +
                         "Right Score: " + GameObject.FindWithTag("ball").GetComponent<Ball>().player2Score;
    }

}
