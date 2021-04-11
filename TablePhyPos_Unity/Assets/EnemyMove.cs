using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    Transform target;

    NavMeshAgent navmeshAgent;
    Animator animator;

    void Start()
    {
        target = GameObject.Find("PlayerRobot").transform;
        navmeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);

        if(distanceFromTarget >= 7.5)
        {
            //Move
            navmeshAgent.updatePosition = true;
            navmeshAgent.SetDestination(target.position);
            animator.SetTrigger("Walking");
            
        } else
        {
            navmeshAgent.updatePosition = false;
            animator.SetTrigger("Fire");
            // Attack
        }
    }

    public void MoveCharacter()
    {

    }
}
