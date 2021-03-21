using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public PursueTargetState pursueTargetState;
    public LayerMask detectionLayer;

    public override State Tick(EnemyManager enemyManager, Enemy enemy, EnemyAnimationManager enemyAnimationManager)
    {
        HandleEnemyTargetDetection(enemyManager);
        if (enemyManager.currentTarget != null)
        {
            return pursueTargetState;
        }
        else
        {
            return this;
        }
    }

    void HandleEnemyTargetDetection(EnemyManager enemyManager)
    {
        Collider[] colliders = Physics.OverlapSphere(enemyManager.transform.position, enemyManager.detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Player player = colliders[i].transform.GetComponent<Player>();
            if (player != null)
            {
                Vector3 targetDirection = player.transform.position - enemyManager.transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, enemyManager.transform.forward);
                if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    enemyManager.currentTarget = player;
                }
            }
        }

    }
}
