using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    const string FORWARD_MOVE_ANIM = "ForwardVelocity";

    public AttackStanceState combatStanceState;

    public override State Tick(EnemyManager enemyManager, Enemy enemy, EnemyAnimationManager enemyAnimationManager)
    {
        if (enemyManager.isPerformingAction) return this;

        HandleMoveToTarget(enemyManager, enemyAnimationManager);
        if (enemyManager.distanceFromTarget <= enemyManager.maximumAttackRange)
        {
            enemyManager.enemyRigidBody.velocity = Vector3.zero;
            enemyAnimationManager.animator.SetFloat(FORWARD_MOVE_ANIM, 0, 0.1f, 5f);
            return combatStanceState;
        }
        else
        {
            return this;
        }
    }


    public void HandleMoveToTarget(EnemyManager enemyManager, EnemyAnimationManager enemyAnimationManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if (enemyManager.distanceFromTarget > enemyManager.maximumAttackRange)
        {
            enemyAnimationManager.animator.SetFloat(FORWARD_MOVE_ANIM, 1);
            targetDirection.y = 0;
            var value = targetDirection * enemyManager.moveSpeed ;
            Debug.Log("value : " + value);
            enemyManager.enemyRigidBody.AddForce(value);
        }

        HandleRotateTowardTarget(enemyManager);
    }
    void HandleRotateTowardTarget(EnemyManager enemyManager)
    {
        Vector3 direction = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        direction.y = 0;
        direction.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.fixedDeltaTime);
    }
}
