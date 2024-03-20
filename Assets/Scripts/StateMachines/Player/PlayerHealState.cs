using System.Collections;
using UnityEngine;

public class PlayerHealState : PlayerBaseState
{
    private Vector3 originalScale; // Simpan skala asli pemain saat memasuki state
    private bool isInHealArea = false; // Menyimpan informasi apakah pemain masih berada di area penyembuhan

    public PlayerHealState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        originalScale = stateMachine.OriginalScale;
        stateMachine.transform.localScale = originalScale;
        isInHealArea = true;
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Entering heal State");
        Vector2 movementInput = stateMachine.InputReader.MovementValue;
        MovePlayer(movementInput);

    }

    public override void Exit()
    {
        // Bersihkan jika diperlukan saat keluar dari state heal
    }

    private void MovePlayer(Vector2 movementInput)
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0f);
        stateMachine.RB2D.velocity = new Vector2(moveDirection.x * stateMachine.MovementSpeed * 0.5f, stateMachine.RB2D.velocity.y);
    }

}
