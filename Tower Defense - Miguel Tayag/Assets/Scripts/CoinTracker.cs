using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    private TextMeshProUGUI coinsText;

    public int coins;

    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        coinsText = gameObject.GetComponent<TextMeshProUGUI>();
        coins = 5;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + coins + "\n" + "Health <3: " + health;
    }
}
