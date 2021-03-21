using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyAnimationManager enemyAnimationManager;
    Enemy enemy;

    public State currentState;

    public bool isPerformingAction;
    public float distanceFromTarget;
    public float currentCooldown = 0;
    public Player currentTarget;
    public Rigidbody enemyRigidBody;

    [Header("Detection Parameters")]
    public float detectionRadius = 20;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    public float maximumAttackRange; 

    [Header("Move Parameters")]
    public float moveSpeed = 15f;
    public float rotationSpeed = 25f;

    void Awake()
    {
        enemyAnimationManager = GetComponent<EnemyAnimationManager>();
        enemy = GetComponent<Enemy>();
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        enemyRigidBody.isKinematic = false;
    }

    void Update()
    {
        HandleCooldown();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleStateMachine();
    }

    void HandleStateMachine()
    {
        if(currentState != null)
        {
            State nextState = currentState.Tick(this, enemy, enemyAnimationManager);
            if (nextState != null)
                SwitchToNextState(nextState);
        }

      /*  if (enemyLocomotionManager.currentTarget != null)
        {
            enemyLocomotionManager.distanceFromTarget = Vector3.Distance(enemyLocomotionManager.currentTarget.transform.position, transform.position);
        }

        if (enemyLocomotionManager.currentTarget == null)
        {
            enemyLocomotionManager.HandleDetection();
        }
        else if (enemyLocomotionManager.distanceFromTarget > enemyLocomotionManager.stoppingDistance)
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
        else if (enemyLocomotionManager.distanceFromTarget <= enemyLocomotionManager.stoppingDistance)
        {
            //HANDLE ATTACK
            enemyLocomotionManager.HandleRotateTowardTarget();
            AttackTarget();
        }
      */

    }

    void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }

    void HandleCooldown()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.fixedDeltaTime;
        }

        if (isPerformingAction)
        {
            if (currentCooldown <= 0)
            {
                isPerformingAction = false;
            }
        }
    }

}
