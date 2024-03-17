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
                case ScaleRecoveryConfig.ScaleType.Recover:
                    player.StartCoroutine(player.InstantRecoverScale(recoveryConfig.scaleSpeed));
                    break;
                case ScaleRecoveryConfig.ScaleType.NORecover:
                    player.StartCoroutine(player.InstantNoRecoverScale(recoveryConfig.scaleSpeed));
                    break;
            }
        }
    }

}
