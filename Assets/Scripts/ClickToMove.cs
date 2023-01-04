using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Vector3 targetLocation;
    private NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
            Debug.Log(hit.collider.gameObject.name);
            targetLocation = hit.point;
            }
        }
    

    if(Vector3.Distance(transform.position, targetLocation) < navMeshAgent.stoppingDistance)
    {
        navMeshAgent.isStopped = true;
    } else
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(targetLocation);
    }



    }








}
