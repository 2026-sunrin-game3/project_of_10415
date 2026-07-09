using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public PlayerInput Input;
    public PlayerMovement movement;

    void Start()
    {
        Input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        movement.Move(Input.axis);
    }
}
