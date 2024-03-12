using UnityEngine;
public class PlayerFallState : PlayerBaseState
{
    private float fallSpeed;

    public PlayerFallState(PlayerStateMachine stateMachine, float fallSpeed) : base(stateMachine)
    {
        this.fallSpeed = fallSpeed;
    }

    public override void Enter()
    {
        // Ketika memasuki state fall, atur kecepatan jatuh.
         stateMachine.RB2D.velocity = new Vector2(stateMachine.RB2D.velocity.x, -fallSpeed);
    }

    public override void Exit()
    {
        // Bersihkan atau atur ulang sesuatu saat keluar dari state fall.
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.IsGrounded())
        {
            stateMachine.SwitchState(new PlayerLocoState(stateMachine));
        }
    }
}
