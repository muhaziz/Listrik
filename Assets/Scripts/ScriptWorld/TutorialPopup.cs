using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popupUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tutor in");
            // Menampilkan popup tutorial
            popupUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tutor out");
            popupUI.SetActive(false);
        }
    }
}
