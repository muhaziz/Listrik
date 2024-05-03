using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popupUI;
    public AudioClip soundClip; // Suara yang ingin diputar

    private AudioSource audioSource; // Komponen AudioSource

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = soundClip;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tutor in");

            // Memutar suara
            if (soundClip != null)
            {
                audioSource.PlayOneShot(soundClip);
            }

            // Menampilkan popup tutorial
            popupUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tutor out");
            popupUI.SetActive(false);
        }
    }
}
