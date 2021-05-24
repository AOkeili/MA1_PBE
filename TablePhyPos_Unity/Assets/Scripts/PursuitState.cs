using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursuitState : StateMachineBehaviour
{
    Transform target;
    NavMeshAgent navmeshAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.Find("PlayerRobot").transform;
       if(navmeshAgent == null) navmeshAgent = GameObject.Find("EnemyRobot").GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceFromTarget = Vector3.Distance(animator.transform.position, target.position);

        if (distanceFromTarget >= 7.5)
        {
            //Move
            navmeshAgent.updatePosition = true;
            navmeshAgent.SetDestination(target.position);
            animator.SetTrigger("Walking");

        }
        else
        {
            navmeshAgent.updatePosition = false;
            animator.SetTrigger("Fire");
            // Attack
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Walking");
    }
}
