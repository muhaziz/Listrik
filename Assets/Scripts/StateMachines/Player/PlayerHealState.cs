using System;
using System.Collections;
using UnityEngine;

public class PlayerHealState : PlayerBaseState
{
    private Vector3 originalScale; // Simpan skala asli pemain saat memasuki state
    private float healDuration = 2f; // Durasi penyembuhan dalam detik
    private float currentHealTime = 0f; // Waktu penyembuhan saat ini

    public PlayerHealState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        // Simpan skala asli pemain
        originalScale = stateMachine.OriginalScale;
        // Reset waktu penyembuhan saat memasuki state
        currentHealTime = 0f;
        // Kembalikan skala pemain ke nilai aslinya
        stateMachine.transform.localScale = originalScale;
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Entering heal State");
        // Tambahkan waktu yang telah berlalu sejak masuk ke state
        currentHealTime += deltaTime;

        // Hitung persentase seberapa jauh penyembuhan telah berlangsung
        float healProgress = Mathf.Clamp01(currentHealTime / healDuration);

        float slowedHealProgress = Mathf.Pow(healProgress, 0.5f); // Perlahan proses penyembuhan dengan menggunakan akar kuadrat
        Vector3 targetScale = Vector3.Lerp(Vector3.zero, originalScale, slowedHealProgress);
        stateMachine.transform.localScale = targetScale;


        Vector2 movementInput = stateMachine.InputReader.MovementValue;
        MovePlayer(movementInput);
    }

    public override void Exit()
    {

    }

    private void MovePlayer(Vector2 movementInput)
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0f);
        stateMachine.RB2D.velocity = new Vector2(moveDirection.x * stateMachine.MovementSpeed * 0.5f, stateMachine.RB2D.velocity.y);
    }

}
