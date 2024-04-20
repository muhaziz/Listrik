using UnityEngine;

public class PlayerHealState : PlayerBaseState
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    private float healDuration = 2f;
    private float currentHealTime = 0f;
    private float totalHealTime; // Waktu total yang diperlukan untuk mencapai skala asli
    private Vector3 startScale;
    private float healingSpeed; // Kecepatan penyembuhan
    private HealingSettings healingSettings;

    public PlayerHealState(PlayerStateMachine stateMachine, HealingSettings settings) : base(stateMachine)
    {
        healingSettings = settings;
    }

    public override void Enter()
    {
        originalScale = stateMachine.OriginalScale;
        startScale = stateMachine.transform.localScale;
        currentHealTime = 0f;
        healingSpeed = healingSettings.healingSpeed;

        float distanceToFullScale = Vector3.Distance(startScale, originalScale);
        totalHealTime = distanceToFullScale / Mathf.Max(healingSpeed, 0.01f);
        // Menyesuaikan skala target dengan pengaturan
        targetScale = healingSettings.targetScale;
    }

    public override void Tick(float deltaTime)
    {
        currentHealTime += deltaTime;

        // Hitung persentase seberapa jauh proses penyembuhan telah berlangsung
        float healProgress = Mathf.Clamp01(currentHealTime / totalHealTime);

        // Interpolasi linier antara skala awal dan skala asli berdasarkan persentase penyembuhan
        Vector3 interpolatedScale = Vector3.Lerp(startScale, targetScale, healProgress);

        stateMachine.transform.localScale = interpolatedScale;

        Vector2 movementInput = stateMachine.InputReader.MovementValue;
        MovePlayer(movementInput);
        stateMachine.FlipCharacter(movementInput.x);
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
