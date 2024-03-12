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

        // Shrink player when moving
        if (stateMachine.IsMoving())
        {
            ShrinkPlayer();
            if(stateMachine.InputReader.Dashing)
            {
                stateMachine.SwitchState(new PlayerDashState(stateMachine));
            }
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
        // Calculate reduction amount based on reduction rate and time
        float reductionAmount = stateMachine.MaxReduction * stateMachine.ReductionRate * Time.deltaTime;

        // Calculate new scale based on original scale and reduction amount
        Vector3 newScale = stateMachine.transform.localScale - stateMachine.OriginalScale * reductionAmount;

        // Ensure new scale does not go below 0
        newScale = Vector3.Max(newScale, Vector3.zero);

        // Apply new scale to player
        stateMachine.transform.localScale = newScale;
    }


}
