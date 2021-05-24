using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyState : StateMachineBehaviour
{
    Transform target;
    Player player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.Find("PlayerRobot").transform;
        player = GameObject.Find("PlayerRobot").GetComponent<Player>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.isDead()) return;

        float distanceFromTarget = Vector3.Distance(animator.transform.position, target.position);

        if (distanceFromTarget >= 7.5) animator.SetTrigger("Walking");
        else animator.SetTrigger("Fire");
    }
}
