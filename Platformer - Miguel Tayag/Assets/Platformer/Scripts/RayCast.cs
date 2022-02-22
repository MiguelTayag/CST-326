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
    private int coins;

    void Start()
    {
        coinText = GameObject.FindWithTag("CoinCount").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if ( Physics.Raycast (ray,out hit))
            {
                var theObject = hit.collider.gameObject;
                if (theObject.CompareTag("Brick"))
                {
                    Destroy(theObject);
                }
                
                if (theObject.CompareTag("Question"))
                {
                    coins++;
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
