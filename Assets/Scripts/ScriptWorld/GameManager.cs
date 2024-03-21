using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;

    // Metode ini dipanggil ketika tombol "Pause" ditekan
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Metode untuk menjeda permainan
    private void PauseGame()
    {
        Time.timeScale = 0f; // Memberhentikan waktu permainan

        // Tambahkan kode untuk menampilkan menu pause di sini (misalnya: aktifkan UI pause menu)

        isPaused = true;
    }

    // Metode untuk melanjutkan permainan dari mode jeda
    private void ResumeGame()
    {
        Time.timeScale = 1f; // Mengatur kembali waktu permainan ke kecepatan normal

        // Tambahkan kode untuk menyembunyikan menu pause di sini (misalnya: nonaktifkan UI pause menu)

        isPaused = false;
    }

    // Metode untuk me-restart level
    public void RestartLevel()
    {
        // Mendapatkan indeks dari level yang sedang dimuat
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Me-restart level dengan indeks yang sama
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Metode untuk kembali ke menu utama
    public void BackToMainMenu()
    {
        // Kode tambahan jika perlu (misalnya: menyimpan data permainan)

        // Kembali ke menu utama
        SceneManager.LoadScene("MainMenu"); // Ganti "MainMenu" dengan nama scene menu utama Anda
    }
}
