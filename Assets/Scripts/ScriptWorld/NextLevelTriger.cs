using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    // Nama tag untuk pemain
    public string playerTag = "Player";

    // Nama tag untuk area pindah ke level berikutnya
    public string nextLevelAreaTag = "NextLevelArea";

    // Nama level berikutnya dalam urutan build
    public string nextLevelName;

    // Objek yang akan diaktifkan sebelum memuat level berikutnya
    public GameObject objectToActivate;

    // Ketika objek lain memasuki area trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(playerTag))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // Pindah ke level berikutnya
            LoadNextLevel();
        }
    }

    // Fungsi untuk memuat level berikutnya
    private void LoadNextLevel()
    {
        // Jika nama level berikutnya tidak ditetapkan, pindah ke level berikutnya dalam urutan build
        if (string.IsNullOrEmpty(nextLevelName))
        {
            // Mendapatkan indeks level saat ini
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Memuat level berikutnya dalam urutan build
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // Memuat level berdasarkan nama yang ditetapkan
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
