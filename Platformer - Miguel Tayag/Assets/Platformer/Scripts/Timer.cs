using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float accumulatedTime = 0f;
    private float totalTime = 0f;
    private float theTime = 0f;
    public TextMeshProUGUI theText;
    
    void Start()
    {
        theText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > 1f)
        {
            totalTime += 1f;
            accumulatedTime = 0f;
            // Debug.Log("Time is : " + totalTime);
        }

        theTime = (375 - totalTime);
        theText.text = "Time \n" + theTime;
        //reset the time for now.
        if (theTime == 0)
        {
            theTime = 375f;
        }

    }
}
