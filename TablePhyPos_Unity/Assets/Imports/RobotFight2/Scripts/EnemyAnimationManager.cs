using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{

    public Animator animator;

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
//        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFadeInFixedTime(targetAnimation, 0.2f);
    }
    /*
    void OnAnimatorMove()
    {
        float delta = Time.deltaTime;
        enemyLocomotionManager.enemyRigidBody.drag = 0;
        Vector3 deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        enemyLocomotionManager.enemyRigidBody.velocity = velocity;
    }*/
}
