using System;
using System.Timers;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(PlayerMove))]
public class PlayerControl : MonoBehaviour
{
    const string AUDIO_WALKSFX = "walkSFX";

    [SerializeField] float speed;
    [SerializeField] float bobbing;
    [SerializeField] float lookSensitivity;
    [SerializeField] Animator animator;
    [SerializeField] Transform cockpit;
    [SerializeField] [Range(0f,4f)] float lerpIntensity;

    Vector2 playerMove;
    Vector2 playerRot;
    Vector3 cockpitOriginPos;
    Timer motionTimer;
    float horizontalMove;
    float timeElapsed;

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
            Debug.Log("Moving");

        }
        else
        {
            FindObjectOfType<AudioManager>().Play(AUDIO_WALKSFX);
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

        //---------------------------------------------  SensorManager.Instance().SendRotateMotion(rotation.y > 0);

        //---------------------------------------------if (horizontalRotation == 0) SensorManager.Instance().EndRotateMotion();
        move.SetRotation(rotation);
    }

    void KillPlayer()
    {

        Player p = GetComponent<Player>();
        p.TakeDamage(9999);
    }


    void SendMotion(object sender, ElapsedEventArgs e)
    {
        //  FindObjectOfType<AudioManager>().Play(AUDIO_WALKSFX);
        SensorManager.Instance().SendWalkSensation();
        Debug.Log("I walk");
    }

}
