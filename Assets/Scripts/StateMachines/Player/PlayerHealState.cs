using UnityEngine;

public class PlayerHealState : PlayerBaseState
{
    private Vector3 originalScale;
    private float healDuration = 2f;
    private float currentHealTime = 0f;
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
        healingSpeed = healingSettings.healingSpeed; // Ambil kecepatan penyembuhan dari HealingSettings
    }

    public override void Tick(float deltaTime)
    {
        currentHealTime += deltaTime;
        float healProgress = Mathf.Clamp01(currentHealTime / healDuration);
        Vector3 targetScale = Vector3.Lerp(startScale, originalScale, healProgress * healingSpeed);

        stateMachine.transform.localScale = targetScale;

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
