using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shootingOffset")] public Transform shootOffsetTransform;
    private float movementPerSecond = 20f;
    private Animator playerAnimator;
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    public bool loadScene = false;
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
            Destroy(shot, 3f);
        }

        if (gameObject.CompareTag("Player"))
        {
            float movementAxis = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 
            && !playerAnimator.IsInTransition(0) && 
            ( playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player Die")))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}

