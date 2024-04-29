using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeSumbu : MonoBehaviour
{
    public enum Polarity { Positive, Negative }
    public Polarity polarity;
    public PlayerStateMachine PSM;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (polarity == Polarity.Positive)
            {
                PSM.IsNegative = false;
            }
            else if (polarity == Polarity.Negative)
            {
                PSM.IsNegative = true;
            }
        }
    }
}
