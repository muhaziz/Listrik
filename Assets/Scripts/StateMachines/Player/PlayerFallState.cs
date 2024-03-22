using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        // Bersihkan atau atur ulang sesuatu saat keluar dari state fall.
    }

    public override void Tick(float deltaTime)
    {
        Vector2 movementInput = stateMachine.InputReader.MovementValue;
        MovePlayer(movementInput);
        if (stateMachine.InputReader.Dashing && stateMachine.BisaDash)
        {
            stateMachine.SwitchState(new PlayerDashState(stateMachine));
        }
        stateMachine.FlipCharacter(movementInput.x);
        Debug.Log("FallState");
        if (stateMachine.IsGrounded())
        {
            stateMachine.SwitchState(new PlayerLocoState(stateMachine));
        }
    }
    private void MovePlayer(Vector2 movementInput)
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0f);
        stateMachine.RB2D.velocity = new Vector2(moveDirection.x * stateMachine.MovementSpeed, stateMachine.RB2D.velocity.y);
    }

}
