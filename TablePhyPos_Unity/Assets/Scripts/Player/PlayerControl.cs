using System;
using System.Timers;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(PlayerMove))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lookSensitivity;
    [SerializeField] Animator animator;
    [SerializeField] Transform cockpit;

    Vector2 playerMove;
    Vector2 playerRot;
    Vector3 cockpitOriginPos;
    Timer motionTimer;
    float horizontalMove;
    int countStep;
    
    PlayerMove move;
    PlayerController controls;

    public bool isWalking = false;


    void Start()
    {
        motionTimer = new Timer();
        motionTimer.Interval = 650; //850
        motionTimer.Elapsed += SendMotion;
        move = GetComponent<PlayerMove>();
        controls = new PlayerController();
       // controls.Gameplay.Fire.performed += ctx => KillPlayer();
        controls.Gameplay.Rotate.performed += ctx => playerRot = ctx.ReadValue<Vector2>();
        controls.Gameplay.Forward.performed += ctx => playerMove = ctx.ReadValue<Vector2>();
        controls.Gameplay.Forward.Enable();
        controls.Gameplay.Rotate.Enable();
        controls.Gameplay.Forward.canceled += ctx => playerMove = Vector2.zero;
        controls.Gameplay.Rotate.canceled += ctx => playerRot = Vector2.zero;
        cockpitOriginPos = cockpit.transform.localPosition;
    }

    void Update()
    {
        //Test Death
       /* if (Input.GetKeyDown(KeyCode.K))
        if()
        {
            Player p = GetComponent<Player>();
            p.TakeDamage(9999);
        }*/

        ComputeMovement();
        ComputeRotation();
    }

    void ComputeMovement()
    {

        //  float xMove = Input.GetAxis("Horizontal");
        //float xMove = playerMove.x;
        float xMove = 0;
        //        float zMove = Input.GetAxis("Vertical");
        float zMove = playerMove.y;
       // Vector3 moveHorizontal = xMove > 0.3f ? transform.right * xMove : Vector3.zero;
        //Vector3 moveVertical = zMove > 0.3f ? transform.forward * zMove : Vector3.zero;
        Vector3 moveHorizontal = xMove > 0.5f ? transform.right * speed : Vector3.zero;
        Vector3 moveVertical = Math.Abs(zMove) > 0.5f ? transform.forward * speed * (zMove/ Math.Abs(zMove)) : Vector3.zero;

        if (Math.Abs(zMove) > 0.5f) { 
            motionTimer.Enabled = true;
            isWalking = true;
            animator.SetFloat("ForwardVelocity", zMove);
            animator.SetFloat("LateralVelocity", xMove);
            Debug.Log("Moving");

        }
        else
        {
            Debug.Log("Not Moving");
            motionTimer.Enabled = false;
            isWalking = false;
            animator.SetFloat("ForwardVelocity", 0);
            animator.SetFloat("LateralVelocity", 0);
            SensorManager.Instance().EndAcceleration();

        }
        //Vector3 velocity = (moveHorizontal + moveVertical) * speed;
        Vector3 velocity = (moveHorizontal + moveVertical) * Time.deltaTime;
        move.SetVelocity(velocity);
    }

    void ComputeRotation()
    {
        // float horizontalRotation = Input.GetAxisRaw("Mouse X");
        float horizontalRotation = playerRot.x;
        Vector3 rotation = new Vector3(0, horizontalRotation, 0) * lookSensitivity;
        SensorManager.Instance().SendRotateMotion(rotation.y > 0);
        if (horizontalRotation == 0) SensorManager.Instance().EndRotateMotion();
        move.SetRotation(rotation);
    }

    void KillPlayer()
    {
        
            Player p = GetComponent<Player>();
            p.TakeDamage(9999);
    }


    void SendMotion(object sender, ElapsedEventArgs e)
    {
        if (!isWalking) countStep = 0;
       // float stepValue = (countStep % 2) == 0 ? 0 : 0.4f;
       // Debug.Log("StepVal = " + stepValue);
        SensorManager.Instance().SendWalkSensation();
        countStep = (countStep + 1) % 10;
    }
    
}
