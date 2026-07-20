using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement movement;

    PlayerBattle battle;

    PlayerAnimater animator;

    public Vector2 axis;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        battle = GetComponent<PlayerBattle>();
        animator = GetComponent<PlayerAnimater>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 axis_ = value.Get<Vector2>();

        axis = new Vector2(axis_.x, 0);

        animator.Play("Move");
    }

    public bool HasAxis()
    {
        return axis.x !=0 || axis.y != 0;
    }

    public void OnJump()
    {
        if (movement.Jump())
        {
            animator.Play("Jump");
        }
    }

    public void OnAttack()
    {
        battle.Attack();
        animator.Play("Attack 1");
    }

    public void OnDash()
    {
        battle.Dash((int)animator.direction);
    }

    public void OnSkill1()
    {
        battle.Skill1();
    }
}
