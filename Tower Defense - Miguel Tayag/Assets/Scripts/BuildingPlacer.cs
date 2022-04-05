using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    private TextMeshProUGUI coinsText;
    private CoinTracker coinTScript;
    // Start is called before the first frame update
    void Start()
    {
        coinsText = GameObject.Find("Coins Text").GetComponent<TextMeshProUGUI>();
        coinTScript = coinsText.GetComponent<CoinTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if( Physics.Raycast(ray, out RaycastHit hit, 100.0f) && hit.transform.gameObject != null)
            {
                if (!hit.transform.gameObject.name.Equals("monster") && coinTScript.coins > 0)
                {
                    var location = new Vector3(hit.point.x, (float) (hit.point.y + 3.4), hit.point.z);
                    Instantiate(GameObject.Find("SiegeTower"),
                        location,
                        GameObject.Find("SiegeTower").transform.rotation);
                    coinTScript.coins--;
                }
            }
        }
    }
}
