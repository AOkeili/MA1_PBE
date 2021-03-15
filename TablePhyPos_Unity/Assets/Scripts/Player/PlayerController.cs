using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lookSensitivity;
    [SerializeField] Animator animator;
    PlayerMove move;

    void Start()
    {
        move = GetComponent<PlayerMove>();
    }

    void Update()
    {
        //Test Death
        if (Input.GetKeyDown(KeyCode.K))
        {
            Player p = GetComponent<Player>();
            p.TakeDamage(9999);
        }

        ComputeMovement();
        ComputeRotation();
    }

    void ComputeMovement()
    {

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;
        animator.SetFloat("ForwardVelocity", zMove);
        animator.SetFloat("LateralVelocity", xMove);

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;
        move.SetVelocity(velocity);
    }

    void ComputeRotation()
    {
        float horizontalRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, horizontalRotation, 0) * lookSensitivity;
        move.SetRotation(rotation);
    }
}
