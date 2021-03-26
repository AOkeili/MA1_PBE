using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lookSensitivity;
    [SerializeField] Animator animator;

    Vector2 playerMove;
    Vector2 playerRot;
    float horizontalMove;

    PlayerMove move;
    PlayerController controls;

    void Start()
    {
        move = GetComponent<PlayerMove>();
        controls = new PlayerController();
       // controls.Gameplay.Fire.performed += ctx => KillPlayer();
        controls.Gameplay.Rotate.performed += ctx => playerRot = ctx.ReadValue<Vector2>();
        controls.Gameplay.Forward.performed += ctx => playerMove = ctx.ReadValue<Vector2>();
        controls.Gameplay.Forward.Enable();
        controls.Gameplay.Rotate.Enable();
        controls.Gameplay.Forward.canceled += ctx => playerMove = Vector2.zero;
        controls.Gameplay.Rotate.canceled += ctx => playerRot = Vector2.zero;
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
        float xMove = playerMove.x;
//        float zMove = Input.GetAxis("Vertical");
        float zMove = playerMove.y;
        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;
        animator.SetFloat("ForwardVelocity", zMove);
        animator.SetFloat("LateralVelocity", xMove);

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;
        move.SetVelocity(velocity);
    }

    void ComputeRotation()
    {
        // float horizontalRotation = Input.GetAxisRaw("Mouse X");
        float horizontalRotation = playerRot.x;
        Vector3 rotation = new Vector3(0, horizontalRotation, 0) * lookSensitivity;
        move.SetRotation(rotation);
    }

    void KillPlayer()
    {
        
            Player p = GetComponent<Player>();
            p.TakeDamage(9999);
    }
}
