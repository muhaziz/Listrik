using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public PlayerDashState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Entering DashState");
        if (stateMachine.BisaDash && !stateMachine.LagiDash)
        {
            stateMachine.StartCoroutine(Dashi());
        }
    }
    public override void Exit()
    {
    }


    private IEnumerator Dashi()
    {
        stateMachine.BisaDash = false;
        stateMachine.LagiDash = true;
        float origravi = stateMachine.RB2D.gravityScale;
        stateMachine.RB2D.gravityScale = 0f;

        // Tentukan arah dash berdasarkan facingRight
        float dashDirection = stateMachine.facingRight ? 1f : -1f;

        stateMachine.RB2D.velocity = new Vector2(dashDirection * stateMachine.DashPower, 0);
        stateMachine.tr.emitting = true;
        yield return new WaitForSeconds(stateMachine.DashTime);
        stateMachine.RB2D.gravityScale = origravi;
        stateMachine.LagiDash = false;
        stateMachine.tr.emitting = false;
        stateMachine.StartDashCooldown();
        stateMachine.SwitchState(new PlayerLocoState(stateMachine));
    }

}
