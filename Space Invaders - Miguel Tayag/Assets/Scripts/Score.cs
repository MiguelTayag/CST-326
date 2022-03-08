using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    private TextMeshProUGUI hiscore;

    public int theScore = 0;
    public int theHiScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        hiscore = GameObject.Find("High Score").GetComponent<TextMeshProUGUI>();
        theHiScore = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The score is " + theScore + " called by: " + gameObject);
        if (theScore > theHiScore)
        {
            theHiScore = theScore;
        }
        if (theScore == 0)
        {
            score.text = "Score \n 0000";
        }else if (theScore < 100)
        {
            score.text = "Score \n 00";
            score.text += theScore + "";
        }else if (theScore < 1000)
        {
            score.text = "Score \n 0";
            score.text += theScore + "";
        }
        else
        {
            score.text = "Score \n";
            score.text += theScore + "";
        }
        if (theHiScore == 0)
        {
            hiscore.text = "High-Score \n 0000";
        }else if(theHiScore < 100)
        {
            hiscore.text = "High-Score \n 00";
            hiscore.text += theHiScore + "";
        }else if (theHiScore < 1000)
        {
            hiscore.text = "High-Score \n 0";
            hiscore.text += theHiScore + "";
        }
        else
        {
            hiscore.text = "High-Score \n";
            hiscore.text += theHiScore + "";
        }
    }
}
