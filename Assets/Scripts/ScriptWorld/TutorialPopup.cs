using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popupUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Menampilkan popup tutorial
            popupUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Menyembunyikan popup tutorial saat pemain meninggalkan area trigger
            popupUI.SetActive(false);
        }
    }
}
