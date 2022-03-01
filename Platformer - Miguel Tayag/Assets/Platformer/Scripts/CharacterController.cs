using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool feetInContactWithGround;
    public float runForce = 5f;
    public float jumpForce = 20f;
    public float jumpBonus = 10f;
    public float runBonus = 10f;
    public float maxRunSpeed = 6f;

    private Animator animComp;
    private Collider c;
    private Rigidbody body;

    private Transform mario;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        c = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
        mario = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float castDistance = (c.bounds.extents.y + 0.1f);
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);
        
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if (feetInContactWithGround && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        } else if (body.velocity.y > 0f && Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpBonus, ForceMode.Force);
        }
        
        

        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            float boostedX = jumpBonus * Mathf.Sign(body.velocity.x);
            if (feetInContactWithGround && Input.GetKey(KeyCode.LeftShift) &&  mario.transform.rotation.y > 0)
            {
                body.velocity = new Vector3(boostedX, body.velocity.y, body.velocity.z);
                Debug.Log("boost?");

            }else if (feetInContactWithGround && Input.GetKey(KeyCode.LeftShift) && mario.transform.rotation.y < 0)
            {
                body.velocity = new Vector3(boostedX, body.velocity.y, body.velocity.z);
                Debug.Log("boost?");
            }
            else
            {
                body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
            }

            if (Input.GetKey(KeyCode.A))
            {
                mario.rotation = Quaternion.Euler(mario.transform.rotation.x, (float) -108.56,
                    mario.transform.rotation.z);
            }

            if (Input.GetKey(KeyCode.D))
            {
                mario.rotation = Quaternion.Euler(mario.transform.rotation.x, (float) 108.56,
                    mario.transform.rotation.z);
            }
        }

        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 3f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
        
        animComp.SetFloat("Speed", body.velocity.magnitude);
    }
}
