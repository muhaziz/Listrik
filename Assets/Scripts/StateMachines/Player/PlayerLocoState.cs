using System.Collections;
using UnityEngine;


public class PlayerLocoState : PlayerBaseState
{

    public PlayerLocoState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("in Loco State");
        Vector2 movementInput = stateMachine.InputReader.MovementValue;
        MovePlayer(movementInput);
        if (stateMachine.IsMoving())
        {
            if (stateMachine.InputReader.Dashing && stateMachine.BisaDash)
            {
                stateMachine.SwitchState(new PlayerDashState(stateMachine));
            }
            ShrinkPlayer();
            stateMachine.FlipCharacter(movementInput.x);
        }

    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }

    private void MovePlayer(Vector2 movementInput)
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0f);
        stateMachine.RB2D.velocity = new Vector2(moveDirection.x * stateMachine.MovementSpeed, stateMachine.RB2D.velocity.y);
    }

    private void ShrinkPlayer()
    {

        float reductionAmount = stateMachine.MaxReduction * stateMachine.ReductionRate * Time.deltaTime;
        Vector3 newScale = stateMachine.transform.localScale - stateMachine.OriginalScale * reductionAmount;
        newScale = Vector3.Max(newScale, Vector3.zero);
        stateMachine.transform.localScale = newScale;
    }
}
