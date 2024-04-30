using System.Collections;
using UnityEngine;

public class ChangeSumbu : MonoBehaviour
{
    public enum Polarity { Positive, Negative }
    public Polarity polarity;
    public PlayerStateMachine PSM;
    private Renderer playerRenderer; // Referensi ke komponen Renderer untuk mengubah warna pemain

    private void Start()
    {
        playerRenderer = PSM.GetComponent<Renderer>(); // Mendapatkan komponen Renderer dari pemain
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (polarity == Polarity.Positive)
            {
                PSM.IsNegative = false;
                ChangePlayerColor(Color.red); // Mengubah warna pemain menjadi merah
            }
            else if (polarity == Polarity.Negative)
            {
                PSM.IsNegative = true;
                ChangePlayerColor(Color.blue); // Mengubah warna pemain menjadi biru
            }
        }
    }

    // Method untuk mengubah warna pemain
    private void ChangePlayerColor(Color color)
    {
        if (playerRenderer != null)
        {
            playerRenderer.material.color = color; // Mengubah warna pemain sesuai dengan parameter color
        }
    }
}
