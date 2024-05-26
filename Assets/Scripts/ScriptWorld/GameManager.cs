using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public InputReader inputReader; // Referensi ke InputReader
    public GameObject pausePanel; // Panel pause
    public GameObject pauseActive; // Panel pause
    public AudioClip soundEffect;
    public AudioSource externalAudioSource;
    public GameObject Music;
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

    public void Pause()
    {
        PlaySoundEffect();
        Time.timeScale = 0f;
        gameIsPaused = true;
        pausePanel.SetActive(true);
        Music.SetActive(false);
        ChangeActiveUI(pauseActive);
    }

    // Metode untuk melanjutkan permainan
    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        PlaySoundEffect();
        Music.SetActive(true);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeActiveUI(GameObject UI)
    {
        EventSystem.current.SetSelectedGameObject(UI);
    }

    public void DestroyObject(GameObject UI)
    {
        Destroy(UI);
    }

    public void PlaySoundEffect()
    {
        // Memeriksa apakah audio source telah ditetapkan
        if (externalAudioSource != null)
        {
            // Memeriksa apakah efek suara telah ditetapkan
            if (soundEffect != null)
            {
                // Memainkan efek suara satu kali menggunakan audio source eksternal
                externalAudioSource.PlayOneShot(soundEffect);
            }
            else
            {
                Debug.LogError("No sound effect assigned!");
            }
        }
        else
        {
            Debug.LogError("No external audio source assigned!");
        }

    }
}
