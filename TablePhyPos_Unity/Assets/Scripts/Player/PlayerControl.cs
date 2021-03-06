﻿using System;
using System.Timers;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(PlayerMove))]
public class PlayerControl : MonoBehaviour
{
    const string AUDIO_WALKSFX = "walkSFX";

    [SerializeField] float speed;
    [SerializeField] float lookSensitivity;
    [SerializeField] Animator animator;

    Vector2 playerMove;
    Vector2 playerRot;
    Timer motionTimer;
    float horizontalMove;
    
    PlayerMove move;
    PlayerController controls;

    public bool isWalking = false;


    void Start()
    {
        motionTimer = new Timer();
        motionTimer.Interval = 650;
        motionTimer.Elapsed += SendMotion;
        move = GetComponent<PlayerMove>();
        controls = new PlayerController();
        controls.Gameplay.Rotate.performed += ctx => playerRot = ctx.ReadValue<Vector2>();
        controls.Gameplay.Forward.performed += ctx => playerMove = ctx.ReadValue<Vector2>();
        controls.Gameplay.Forward.Enable();
        controls.Gameplay.Rotate.Enable();
        controls.Gameplay.Forward.canceled += ctx => playerMove = Vector2.zero;
        controls.Gameplay.Rotate.canceled += ctx => playerRot = Vector2.zero;
    }

    void Update()
    {
        ComputeMovement();
        ComputeRotation();
    }

    void ComputeMovement()
    {
        float xMove = 0;
        float zMove = playerMove.y;
        Vector3 moveHorizontal = xMove > 0.5f ? transform.right * speed : Vector3.zero;
        Vector3 moveVertical = Math.Abs(zMove) > 0.5f ? transform.forward * speed * (zMove / Math.Abs(zMove)) : Vector3.zero;

        if (Math.Abs(zMove) > 0.5f)
        {
            motionTimer.Enabled = true;
            isWalking = true;
            animator.SetFloat("ForwardVelocity", zMove);
            animator.SetFloat("LateralVelocity", xMove);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play(AUDIO_WALKSFX);
            motionTimer.Enabled = false;
            isWalking = false;
            animator.SetFloat("ForwardVelocity", 0);
            animator.SetFloat("LateralVelocity", 0);
            SensorManager.Instance().EndAcceleration();

        }
        Vector3 velocity = (moveHorizontal + moveVertical) * speed;
       
        move.SetVelocity(velocity);
    }

    void ComputeRotation()
    {
        float horizontalRotation = playerRot.x;
        Vector3 rotation = new Vector3(0, horizontalRotation, 0) * lookSensitivity;
        move.SetRotation(rotation);
    }

    void SendMotion(object sender, ElapsedEventArgs e)
    {
        SensorManager.Instance().SendWalkSensation();
    }

}
