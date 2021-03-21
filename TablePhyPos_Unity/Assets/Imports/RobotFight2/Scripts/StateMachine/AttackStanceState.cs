using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStanceState : State
{
    public AttackState attackState;
    public PursueTargetState pursueTargetState;
    public override State Tick(EnemyManager enemyManager, Enemy enemy, EnemyAnimationManager enemyAnimationManager)
    {
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if ((enemyManager.currentCooldown <= 0) && (enemyManager.distanceFromTarget <= enemyManager.maximumAttackRange))
        {
            return attackState;
        }
        else if (enemyManager.distanceFromTarget > enemyManager.maximumAttackRange)
        {
            return pursueTargetState;
        }
        else
        {
            return this;
        }
    }
}
