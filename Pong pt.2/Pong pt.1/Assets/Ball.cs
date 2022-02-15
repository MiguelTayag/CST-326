using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //members
    public float velo = 10f;
    public float x;
    public float z;
    public float angle;
    public int player1Score;
    public int player2Score; 
    public AudioClip hitBall;
    private AudioSource source;
    public AudioClip hitBall1;
    private AudioSource source1;
    public AudioClip hitBall2;
    private AudioSource source2;
    public TextMeshPro scoreText;
    public int colorChanger = 0;

    
    


    // Start is called before the first frame update
    public void Start() {
        scoreText = GetComponent<TextMeshPro>();
        //sets up the ball velocity
        x = Random.Range(0, 2) == 0 ? -1 : 1;
        z = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(velo * x, 0f, velo * z);
        source = GetComponent<AudioSource>();
        source1 = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();

    }

    

    // Update is called once per frame
    void Update()
    {
        // player1ScoreText.text = "Score: " + player1Score;
        // player2ScoreText.text = "Score: " + player2Score;
        //checks if there's a winner. Prints who won and resets the score.
        if (player1Score == 11)
        {
            Debug.Log("GAME OVER!!! LEFT PADDLE WON!!!");
            player1Score = 0;
            player2Score = 0;
        }
        if (player2Score == 11)
        {
            Debug.Log("GAME OVER!!! RIGHT PADDLE WON!!!");
            player1Score = 0;
            player2Score = 0;
        }
    }

    public void ballAngleReset()
    {
        //resets the ball and randomizes the angle that the ball goes.
        x = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(velo * x, 0f, velo * z);
    }
    public void ballReset()
    {
        ballAngleReset();   
        //puts the ball back to the original position.
        GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        GameObject.Find("Player2").GetComponent<Rigidbody>().transform.localScale = new Vector3(5, 1, 1);
        GameObject.Find("Player1").GetComponent<Rigidbody>().transform.localScale = new Vector3(5, 1, 1);
        GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            // angle determines the angle of the ball depending on which part of the paddle it hits.
            angle = GetComponent<Rigidbody>().transform.position.x - collision.transform.position.x;
           
            //multiplied to 1.2f to increase the velocity by 20% everytime
            GetComponent<Rigidbody>().velocity = new Vector3(velo * angle
                , 0f, GetComponent<Rigidbody>().velocity.z * 1.2f);
            // Debug.Break();
            Debug.Log(angle);
            
            if (angle > 0.5)
            { 
                source2.PlayOneShot(hitBall2);
            }else if (angle < -0.5)
            {
                source.PlayOneShot(hitBall);
            }
            else
            {
                source1.PlayOneShot(hitBall1);

            }        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            // angle determines the angle of the ball depending on which part of the paddle it hits.
            angle = GetComponent<Rigidbody>().transform.position.x - collision.transform.position.x;
             
            //multiplied to 1.2f to increase the velocity by 20% everytime
            GetComponent<Rigidbody>().velocity = new Vector3(velo * angle
                , 0f, GetComponent<Rigidbody>().velocity.z * 1.2f);
            // Debug.Break();
            if (angle > 0.5)
            { 
                source2.PlayOneShot(hitBall2);
            }else if (angle < -0.5)
            {
                source.PlayOneShot(hitBall);
            }
            else
            {
                source1.PlayOneShot(hitBall1);

            }
            Debug.Log(angle);

        }
        if (collision.gameObject.CompareTag("Trigger1"))
        {
            player2Score++;
            //resets the ball and gives the ball to the other side.
            GetComponent<Rigidbody>().velocity = new Vector3(velo * x, 0f, velo * z);
            var r = Random.Range(0, 255);
            var g = Random.Range(0, 255);
            var b = Random.Range(0, 255);
            var a = Random.Range(0, 255);
            GameObject.FindWithTag("Score").GetComponent<TextMeshPro>().faceColor = new Color32((byte)r, (byte)g, (byte)b, (byte)a);
            Debug.Log("Right Paddle Scored!!!");
            Debug.Log(player1Score + " : " + player2Score);
            z = -1;
            ballReset();
        }
        if (collision.gameObject.CompareTag("Trigger2"))
        {
            player1Score++;
            //resets the ball and gives the ball to the other side.
            GetComponent<Rigidbody>().velocity = new Vector3(velo * x, 0f, velo * z);
            var r = Random.Range(0, 255);
            var g = Random.Range(0, 255);
            var b = Random.Range(0, 255);
            var a = Random.Range(0, 255);
            GameObject.FindWithTag("Score").GetComponent<TextMeshPro>().faceColor = new Color32((byte)r, (byte)g, (byte)b, (byte)a);
            Debug.Log("Left Paddle Scored!!!");
            Debug.Log(player1Score + " : " + player2Score);
            z = 1;
            ballReset();

        }
    }
    
}
