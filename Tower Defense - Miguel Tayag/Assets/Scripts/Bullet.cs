using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform targetMonster;

    public float speed = 50f;
    // Start is called before the first frame update
    public void Seek(Transform target)
    {
        targetMonster = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetMonster == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = targetMonster.position - transform.position;
        float distFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distFrame)
        {
            Hit();
            return;
        }
        transform.Translate(direction.normalized * distFrame, Space.World);
        
    }

    void Hit()
    {
        targetMonster.GetComponent<Enemy>().TakeDamage(0.2f);
        Destroy(gameObject);
    }
}
