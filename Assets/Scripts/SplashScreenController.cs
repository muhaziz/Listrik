using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreenController : MonoBehaviour
{
    public string nextSceneName; // Nama scene selanjutnya setelah splash screen

    // Durasi tampilan splash screen (dalam detik)
    public float splashScreenDuration = 5f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(splashScreenDuration);
        LoadNextScene();
    }

    // Method untuk memuat scene selanjutnya
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
