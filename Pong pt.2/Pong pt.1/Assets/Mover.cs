using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float movementPerSecond = 20f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the paddles using one script.
        if (gameObject.CompareTag("Player1"))
        {
            float movementAxis = Input.GetAxis("Horizontal1");

            // Vector3 force = Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            // Rigidbody rBody = GetComponent<Rigidbody>();
            // if (rBody != null)
            // {
            //     rBody.AddForce(force, ForceMode.VelocityChange);
            // }
            
            transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            
            // Debug.Log(transform.position.x);
           
        }
        if (gameObject.CompareTag("Player2"))
        {
          
            float movementAxis = Input.GetAxis("Horizontal2");

            // Vector3 force = Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            // Rigidbody rBody = GetComponent<Rigidbody>();
            // if (rBody != null)
            // {
            //     rBody.AddForce(force, ForceMode.VelocityChange);
            // }
            
            transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;

            

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bbox = GetComponent<BoxCollider>();
        float xCenter = bbox.bounds.center.x;

        // Debug.Log("Center at " + xCenter + "collided object at " + collision.transform.position.x);

        Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;

        Debug.DrawLine(transform.position, transform.position + newVector * 10f, Color.red);
        // Debug.Break();
    }
}
