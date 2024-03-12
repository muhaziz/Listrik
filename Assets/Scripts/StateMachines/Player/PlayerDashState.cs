using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashDurationTimer;
    private bool isGrounded;

    public PlayerDashState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        dashDurationTimer = stateMachine.DashCooldown;
        //Dash();
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Entering DashState");

        // RB.velocity= new Vector2(transform.local.x*dashingpower, 0f);
    }

    private void ControlDashVelocity()
    {
        // Terapkan kecepatan dash dalam arah yang ditentukan
        float dashVelocityX = stateMachine.DashSpeed * stateMachine.FacingDirection.x;
        stateMachine.RB2D.velocity = new Vector2(dashVelocityX, stateMachine.RB2D.velocity.y);
    }


    public override void Exit()
    {
    }

    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
