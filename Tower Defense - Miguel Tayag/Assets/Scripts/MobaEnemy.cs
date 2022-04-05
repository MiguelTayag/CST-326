using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MobaEnemy : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 meshPosition = GetNavmeshPosition(target.position);
        // agent.SetDestination(meshPosition);
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray pickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(pickRay, out RaycastHit hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }

    }

    Vector3 GetNavmeshPosition(Vector3 samplePosition)
    {
        NavMesh.SamplePosition(samplePosition, out NavMeshHit hitInfo, 100f, -1);
        return hitInfo.position;
    }
}
