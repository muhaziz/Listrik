using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        Jump(); // Memanggil Jump setelah memeriksa input gerakan
        Debug.Log("in Jump State");
        Vector2 movementInput = stateMachine.InputReader.MovementValue;
        MovePlayer(movementInput);
        if (stateMachine.InputReader.Dashing && stateMachine.BisaDash)
        {
            stateMachine.SwitchState(new PlayerDashState(stateMachine));
        }
        stateMachine.FlipCharacter(movementInput.x);
        if (!stateMachine.IsGrounded())
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
    }

    public override void Exit()
    {
    }

    private void MovePlayer(Vector2 movementInput)
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0f);
        stateMachine.RB2D.velocity = new Vector2(moveDirection.x * stateMachine.MovementSpeed, stateMachine.RB2D.velocity.y);
    }

    private void Jump()
    {
        // Menggunakan JumpForce untuk melompat
        stateMachine.RB2D.velocity = new Vector2(stateMachine.RB2D.velocity.x, stateMachine.JumpForce);
    }
}
