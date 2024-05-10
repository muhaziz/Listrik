using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class NextLevelTrigger : MonoBehaviour
{
    public LinearProgressionAuthApacheLeaderboard leaderboard;
    public string playerTag = "Player";
    public GameObject objectToActivate;
    public GameObject ResultMenu;
    public TMP_Text coinText;
    public TMP_Text scaleText;
    public AudioClip soundEffect;
    public AudioSource externalAudioSource;
    public GameObject Music;
    public float Bintang1 = .7f;
    public float Bintang2 = .2f;
    public float delayBeforeLoading = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {

            UnlockedLevel();
            Music.SetActive(false);
            PlaySoundEffect();

            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            Vector3 playerScale = collision.transform.localScale;
            float minScale = Mathf.Min(playerScale.x, playerScale.y, playerScale.z);
            float scaledPercentage = minScale * 100f;
            int coinCount = 0;
            if (minScale > Bintang1)
            {
                coinCount = 3;
            }
            else if (minScale > Bintang2)
            {
                coinCount = 2;
            }
            else
            {
                coinCount = 1;
            }

            coinText.text = "Coins: " + coinCount.ToString();
            scaleText.text = scaledPercentage.ToString("F0");
            ResultMenu.GetComponent<ResultMenu>().SetStarsActive(coinCount);
            leaderboard.InvokeLeaderboard();
            StartCoroutine(LoadNextLevelWithDelay());
        }
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        ResultMenu.gameObject.SetActive(true);
    }

    void UnlockedLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }

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
