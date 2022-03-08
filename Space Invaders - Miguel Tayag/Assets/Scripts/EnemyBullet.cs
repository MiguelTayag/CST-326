using TMPro;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;

   
    private GameObject leftBarricade;
    private int leftBarricadeHealthBar;
    private GameObject rightBarricade;
    private int rightBarricadeHealthBar;
    

    private int hiscore;
    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
        rightBarricade = GameObject.Find("RightBarricade");
        rightBarricadeHealthBar = 4;
        leftBarricade = GameObject.Find("LeftBarricade");
        leftBarricadeHealthBar = 4;
        

    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        // Debug.Log("Wwweeeeee");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("LeftBarricade"))
        {
            Destroy(leftBarricade);
        }
        if (collision.gameObject.name.Equals("RightBarricade"))
        {
            Destroy(rightBarricade);
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            Destroy(rightBarricade);
        }
    }
}
