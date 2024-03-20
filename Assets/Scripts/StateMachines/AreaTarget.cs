using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
            if (player != null)
            {
                player.SwitchState(new PlayerHealState(player));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
            if (player != null)
            {
                player.SwitchState(new PlayerLocoState(player));
            }
        }
    }
}
