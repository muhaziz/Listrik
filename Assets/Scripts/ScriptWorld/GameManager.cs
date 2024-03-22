using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputReader inputReader; // Referensi ke InputReader
    public GameObject pausePanel; // Panel pause
    private bool gameIsPaused = false;

    private void Start()
    {
        // Menambahkan respons untuk event PauseEvent dari InputReader
        inputReader.PauseEvent += TogglePause;
    }

    private void OnDestroy()
    {
        // Menghapus respons event saat objek dihancurkan
        inputReader.PauseEvent -= TogglePause;
    }

    // Metode untuk menjeda atau melanjutkan permainan saat tombol Pause ditekan
    void TogglePause()
    {
        if (gameIsPaused)
            Resume();
        else
            Pause();
    }

    // Metode untuk menjeda permainan
    void Pause()
    {
        Time.timeScale = 0f; // Memperlambat waktu menjadi 0
        gameIsPaused = true;
        // Aktifkan panel pause
        pausePanel.SetActive(true);
    }

    // Metode untuk melanjutkan permainan
    void Resume()
    {
        Time.timeScale = 1f; // Mengembalikan waktu ke kecepatan normal
        gameIsPaused = false;
        // Nonaktifkan panel pause
        pausePanel.SetActive(false);
    }

    // Metode untuk me-restart permainan
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Pastikan waktu kembali ke kecepatan normal setelah me-restart
    }

    // Metode untuk kembali ke menu utama
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu"); // Ganti "MainMenu" dengan nama scene menu utama Anda
        Time.timeScale = 1f; // Pastikan waktu kembali ke kecepatan normal saat kembali ke menu
    }
}
