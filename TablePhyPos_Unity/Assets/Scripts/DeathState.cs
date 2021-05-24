using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NavMeshAgent navmesh = animator.GetComponent<NavMeshAgent>();
       navmesh.isStopped = true;
        navmesh.velocity = Vector3.zero;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Enemy enemy = animator.GetComponent<Enemy>();
        enemy.Die();
    }

}
