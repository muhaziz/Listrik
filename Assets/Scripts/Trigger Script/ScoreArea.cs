using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreArea : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public Image BintangUI;
    public GameObject Bintang;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BintangUI.gameObject.SetActive(true); // Mengaktifkan UI bintang
            Destroy(Bintang); // Menghancurkan objek bintang
            score++; // Menambah skor
            UpdateScoreUI(); // Memperbarui tampilan skor
        }
    }

    void UpdateScoreUI()
    {
        // Memperbarui teks skor pada UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
