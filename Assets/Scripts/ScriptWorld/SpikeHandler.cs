using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHandler : MonoBehaviour
{
    public GameManager manager;
    public GameObject GameoverActive;
    public GameObject GameOver;
    public AudioClip soundEffect;
    public AudioSource externalAudioSource;
    public GameObject Music;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            GameOver.SetActive(true);
            Music.SetActive(false);
            manager.ChangeActiveUI(GameoverActive);
            PlaySoundEffect();
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
