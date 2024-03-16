using UnityEngine;

public class ScaleRecoveryTrigger : MonoBehaviour
{
    [SerializeField] private ScaleRecoveryConfig recoveryConfig;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();

        }
    }
}
