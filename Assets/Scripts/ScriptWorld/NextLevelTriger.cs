using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevelTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public string nextLevelAreaTag = "NextLevelArea";
    public string nextLevelName;
    public GameObject objectToActivate;
    public GameObject ResultMenu;
    public float delayBeforeLoading = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            StartCoroutine(LoadNextLevelWithDelay());
        }
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        ResultMenu.gameObject.SetActive(true);
    }

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