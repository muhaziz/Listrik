using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float jumpTimeElapsed = 0f;
    float fallSpeed = 3f;

    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        // Atur nilai awal waktu loncatan dan lakukan loncatan pertama.
        jumpTimeElapsed = 0f;
        Jump();
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("in Jump State");
        // Tambah waktu loncatan yang telah berlalu.
        jumpTimeElapsed += deltaTime;

        // Cek apakah waktu loncatan telah melewati waktu maksimum atau pemain menyentuh tanah.
        if (jumpTimeElapsed >= stateMachine.MaxJumpTime || !stateMachine.IsGrounded())
        {
            // Jika ya, pindah ke state fall.
            stateMachine.SwitchState(new PlayerFallState(stateMachine, fallSpeed));
        }
        else
        {
            // Jika belum, lanjutkan loncatan.
            Jump();
        }
    }

    public override void Exit()
    {
        // Reset kondisi atau lakukan pembersihan jika diperlukan saat keluar dari state jump.
    }

    private void Jump()
    {
        // Implementasi logika loncatan di sini.
        stateMachine.RB2D.velocity = new Vector2(stateMachine.RB2D.velocity.x, stateMachine.JumpForce);
    }
}
