using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputReader inputReader; // Referensi ke InputReader
    public GameObject pausePanel; // Panel pause
    public String SceneMenu = "Main Menu";
    private bool gameIsPaused = false;


    private void Start()
    {
        inputReader.PauseEvent += TogglePause;
    }

    private void OnDestroy()
    {
        inputReader.PauseEvent -= TogglePause;
    }

    void TogglePause()
    {
        if (gameIsPaused)
            Resume();
        else
            Pause();
    }

    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        pausePanel.SetActive(true);
    }

    // Metode untuk melanjutkan permainan
    void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneMenu);
        Time.timeScale = 1f;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
