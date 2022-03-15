using TMPro;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;

    private Score scoreScript;
    private Score hiScoreScript;
    private GameObject score;
    private GameObject highScore;
    private int theScore;
    private int theHiScore;
    private GameObject leftBarricade;
    private int leftBarricadeHealthBar;
    private GameObject rightBarricade;
    private int rightBarricadeHealthBar;
    private Animator ufoAnimator;
    private GameObject ufo;
    private Animator blueAnimator;
    private GameObject purp;
    private Animator purpAnimator;
    private GameObject blue;
    private Animator monsterAnimator;
    private GameObject monster;
    private int hiscore;
    private static readonly int Die = Animator.StringToHash("Die");

    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
        score = GameObject.Find("Score");
        highScore = GameObject.Find("High Score");
        scoreScript = score.GetComponent<Score>();
        hiScoreScript = highScore.GetComponent<Score>();
        rightBarricade = GameObject.Find("RightBarricade");
        rightBarricadeHealthBar = 4;
        leftBarricade = GameObject.Find("LeftBarricade");
        leftBarricadeHealthBar = 4;
        ufo = GameObject.Find("UFO");
        blue = GameObject.Find("BlueMonster");
        purp = GameObject.Find("PurpMonster");
        monster = GameObject.Find("Monster");

        ufoAnimator = ufo.GetComponent<Animator>();
        purpAnimator = purp.GetComponent<Animator>();
        blueAnimator = blue.GetComponent<Animator>();
        monsterAnimator = monster.GetComponent<Animator>();


    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        // Debug.Log("Wwweeeeee");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Monster"))
        {
            scoreScript.theScore += 40;
            hiScoreScript.theScore += 40;
            monsterAnimator.SetTrigger(Die);
        }
        if (collision.gameObject.name.Equals("UFO"))
        {
            scoreScript.theScore += 30;
            hiScoreScript.theScore += 30;
            ufoAnimator.SetTrigger(Die);


        }
        if (collision.gameObject.name.Equals("BlueMonster"))
        {
            scoreScript.theScore += 20;
            hiScoreScript.theScore += 20;
            blueAnimator.SetTrigger(Die);



        }
        if (collision.gameObject.name.Equals("PurpMonster"))
        {
            scoreScript.theScore += 10;
            hiScoreScript.theScore += 10;
            purpAnimator.SetTrigger(Die);

        }
        if (collision.gameObject.name.Equals("LeftBarricade"))
        {
            Destroy(leftBarricade);
        }
        if (collision.gameObject.name.Equals("RightBarricade"))
        {
            Destroy(rightBarricade);
        }   
        Destroy(collision.gameObject);
        
    }
}
