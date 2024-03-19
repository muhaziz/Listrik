using UnityEngine;

public class ScaleRecoveryTrigger : MonoBehaviour
{
    [SerializeField] private ScaleRecoveryConfig recoveryConfig;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
            switch (recoveryConfig.scaleType)
            {
                case ScaleRecoveryConfig.ScaleType.Scale:
                    player.StartCoroutine(player.InstantRecoverScale(recoveryConfig.scaleSpeed));
                    break;
                case ScaleRecoveryConfig.ScaleType.RecoverSlow:
                    player.StartCoroutine(player.SlowRecoverScale(recoveryConfig.scaleSpeed));
                    break;
                case ScaleRecoveryConfig.ScaleType.ReduceSlow:
                    player.StartCoroutine(player.ReduceScale(recoveryConfig.target, recoveryConfig.scaleSpeed));
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
            // Tetapkan ukuran target sebagai ukuran saat keluar dari trigger
            recoveryConfig.target = player.transform.localScale;
            // Restart sistem shrink dengan ukuran target yang baru
            StartCoroutine(player.ReduceScale(recoveryConfig.target, recoveryConfig.scaleSpeed));
        }
    }
}
