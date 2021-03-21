using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    public const string FORWARD_MOVE_ANIM = "ForwardVelocity";

    EnemyManager enemyManager;
    EnemyAnimationManager enemyAnimationManager;
   
 

    void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyAnimationManager = GetComponent<EnemyAnimationManager>();
    }

    void Start()
    {
    }

}
