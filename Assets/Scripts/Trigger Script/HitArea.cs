
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    public HealingSettings healingSettings;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateMachine player = other.GetComponent<PlayerStateMachine>();
            if (player != null)
            {
                Debug.Log("In");
                player.SwitchState(new PlayerHitState(player));
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
                Debug.Log("exit`");
                player.SwitchState(new PlayerHitState(player));
            }
        }
    }
}

