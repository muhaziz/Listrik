using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHandler : MonoBehaviour
{
    // Metode ini akan dipanggil ketika objek lain menyentuh objek ini
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Periksa apakah objek yang menyentuh adalah pemain
        if (collision.CompareTag("Player"))
        {
            // Menghancurkan pemain
            Destroy(collision.gameObject);

            // Restart level
            RestartLevel();
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
