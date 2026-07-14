using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public PlayerInput Input;
    public PlayerMovement movement;
    public PlayerAnimater animator;

    void Start()
    {
        Input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<PlayerAnimater>();
    }

    void Update()
    {
        movement.Move(Input.axis);

        animator.SetMoving(Input.HasAxis(), Input.axis);
    }
}
