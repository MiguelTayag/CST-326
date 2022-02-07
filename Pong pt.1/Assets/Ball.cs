using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //members
    public float velo = 10f;
    public float x;
    public float z;
    public float angle;
    private int player1Score;
    private int player2Score;
    
    


    // Start is called before the first frame update
    public void Start() {
        //sets up the ball velocity
        x = Random.Range(0, 2) == 0 ? -1 : 1;
        z = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(velo * x, 0f, velo * z);

    }

    

    // Update is called once per frame
    void Update()
    {
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
        GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            // angle determines the angle of the ball depending on which part of the paddle it hits.
            angle = collision.transform.position.x - GetComponent<Rigidbody>().transform.position.x;
           
            //multiplied to 1.2f to increase the velocity by 20% everytime
            GetComponent<Rigidbody>().velocity = new Vector3(velo * angle * -1
                , 0f, GetComponent<Rigidbody>().velocity.z * 1.2f);
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            // angle determines the angle of the ball depending on which part of the paddle it hits.
            angle = collision.transform.position.x - GetComponent<Rigidbody>().transform.position.x;
            
            //multiplied to 1.2f to increase the velocity by 20% everytime
            GetComponent<Rigidbody>().velocity = new Vector3(velo * angle * -1
                , 0f, GetComponent<Rigidbody>().velocity.z * 1.2f);
        }
        if (collision.gameObject.CompareTag("Trigger1"))
        {
            player2Score++;
            //resets the ball and gives the ball to the other side.
            GetComponent<Rigidbody>().velocity = new Vector3(velo * x, 0f, velo * z);
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
            Debug.Log("Left Paddle Scored!!!");
            Debug.Log(player1Score + " : " + player2Score);
            z = 1;
            ballReset();

        }
    }
    
}
