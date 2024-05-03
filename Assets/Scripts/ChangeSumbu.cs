using UnityEngine;

public class ChangeSumbu : MonoBehaviour
{
    public enum Polarity { Positive, Negative }
    public Polarity polarity;
    public PlayerStateMachine PSM;
    private SpriteRenderer playerSpriteRenderer; // Referensi ke komponen SpriteRenderer untuk mengubah warna pemain

    private void Start()
    {
        // Mencari komponen SpriteRenderer pada root object pemain
        playerSpriteRenderer = PSM.transform.root.GetComponentInChildren<SpriteRenderer>();

        // Jika sprite renderer tidak ditemukan, coba mencarinya pada pemain itu sendiri
        if (playerSpriteRenderer == null)
        {
            playerSpriteRenderer = PSM.GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (polarity == Polarity.Positive)
            {
                PSM.IsNegative = false;
                ChangePlayerColor(new Color(0.949f, 0.243f, 0.243f, 1f)); // Mengubah warna pemain menjadi merah dengan menggunakan nilai HEX code F23E3
            }
            else if (polarity == Polarity.Negative)
            {
                PSM.IsNegative = true;
                ChangePlayerColor(new Color(0.105f, 0.518f, 1f, 1f)); // Mengubah warna pemain menjadi biru dengan menggunakan nilai HEX code 1B84FF
            }
        }
    }

    // Method untuk mengubah warna pemain
    private void ChangePlayerColor(Color color)
    {
        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.color = color; // Mengubah warna pemain sesuai dengan parameter color
        }
    }
}
