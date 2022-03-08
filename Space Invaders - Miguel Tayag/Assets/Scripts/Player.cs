using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shootingOffset")] public Transform shootOffsetTransform;
    private float movementPerSecond = 20f;
    private Animator playerAnimator;
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    //-----------------------------------------------------------------------------
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            playerAnimator.SetTrigger(Shoot);
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");

            
            Destroy(shot, 3f);
        }
        
        if (gameObject.CompareTag("Player"))
        {
            float movementAxis = Input.GetAxis("Horizontal");

            // Vector3 force = Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            // Rigidbody rBody = GetComponent<Rigidbody>();
            // if (rBody != null)
            // {
            //     rBody.AddForce(force, ForceMode.VelocityChange);
            // }
            
            transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
            
            // Debug.Log(transform.position.x);
           
        }
    }
}
