using UnityEngine;

public class ScaleRecoveryTrigger : MonoBehaviour
{
    // [SerializeField] private ScaleRecoveryConfig recoveryConfig;

    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
    //         switch (recoveryConfig.scaleType)
    //         {
    //             case ScaleRecoveryConfig.ScaleType.Scale:
    //                 player.StartCoroutine(player.InstantRecoverScale(recoveryConfig.instantScale));
    //                 break;
    //             case ScaleRecoveryConfig.ScaleType.RecoverSlow:
    //                 player.StartCoroutine(player.SlowRecoverScale(recoveryConfig.scaleSpeed));
    //                 break;
    //             case ScaleRecoveryConfig.ScaleType.ReduceSlow:
    //                 player.StartCoroutine(player.ReduceScale(recoveryConfig.targetScale, recoveryConfig.scaleSpeed));
    //                 break;
    //         }
    //     }
    // }
}
