using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("Brick")]
    public GameObject brickPrefab;
    [FormerlySerializedAs("QuestionBox")]
    public GameObject questionBoxPrefab;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;

    public Transform mario;


    private int coins;
    private int score;


    void Start()
    {
        coinText = GameObject.FindWithTag("CoinCount").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindWithTag("score").GetComponent<TextMeshProUGUI>();
        mario = GameObject.FindWithTag("Mario").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space)){ 
            RaycastHit hit; 
            Ray ray = new Ray(mario.transform.position, new Vector3(0,1,0));
            if ( Physics.Raycast (ray,out hit, (float)3))
            {
                var theObject = hit.collider.gameObject;
                if (theObject.CompareTag("Brick")) 

                {
                    Destroy(theObject);
                    score += 100;
                    if (score < 1000)
                    {
                        scoreText.text = "Mario \n 000" + score;
                    }
                    else if (score < 10000)
                    {
                        scoreText.text = "Mario \n 00" + score;
                    }
                }
                
                if (theObject.CompareTag("Question"))
                {
                    coins++;
                    score += 100;
                    if (score < 1000)
                    {
                        scoreText.text = "Mario \n 000" + score;
                    }
                    else if (score < 10000)
                    {
                        scoreText.text = "Mario \n 00" + score;
                    }
                    if (coins < 10)
                    {
                        coinText.text = "x0" + coins;
                    }
                    else
                    {
                        coinText.text = "x" + coins;
                    }
                }
                Debug.Log(theObject); // ensure you picked right object
            }
        }
        
    }
}
