using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHandler : MonoBehaviour
{
    public GameObject GameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }

    // Metode untuk me-restart level
    private void RestartLevel()
    {
        // Mendapatkan indeks dari level yang sedang dimuat
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Me-restart level dengan indeks yang sama
        SceneManager.LoadScene(currentSceneIndex);
    }
}
