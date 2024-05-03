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
    public float Bintang1 = .7f;
    public float Bintang2 = .2f;
    public float delayBeforeLoading = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            leaderboard.InvokeLeaderboard();
            UnlockedLevel();
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // Dapatkan skala pemain
            Vector3 playerScale = collision.transform.localScale;
            // Ambil nilai minimum dari skala pemain
            float minScale = Mathf.Min(playerScale.x, playerScale.y, playerScale.z);

            // Ubah nilai skala pemain menjadi format persen dalam teks
            float scaledPercentage = minScale * 100f;

            // Tentukan jumlah koin berdasarkan rentang skala pemain
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

            // Tampilkan jumlah koin dan skala terakhir pemain di TMP_Text
            coinText.text = "Coins: " + coinCount.ToString();
            scaleText.text = scaledPercentage.ToString("F0"); // Menambahkan format persen ke teks

            // Panggil metode SetStarsActive dari ResultMenu dan kirimkan nilai coinCount
            ResultMenu.GetComponent<ResultMenu>().SetStarsActive(coinCount);

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
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("unlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }

    }
}
