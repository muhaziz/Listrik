using UnityEngine;

public class ScaleRecoveryTrigger : MonoBehaviour
{
    [SerializeField] private ScaleRecoveryConfig recoveryConfig;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
            switch (recoveryConfig.recoveryType)
            {
                case ScaleRecoveryConfig.RecoveryType.Instant:
                    player.StartCoroutine(player.InstantRecoverScale(recoveryConfig.recoverySpeed));
                    break;
                case ScaleRecoveryConfig.RecoveryType.Slow:
                    player.StartCoroutine(player.SlowRecoverScale(recoveryConfig.recoverySpeed));
                    break;
            }
        }
    }
}
