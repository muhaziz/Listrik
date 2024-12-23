using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public Animator objectAnimator; // Referensi ke komponen Animator pada objek yang ingin Anda animasikan
    public GameObject ObjectActivate;

    private void Start()
    {
        // Mengambil referensi ke komponen Animator pada objek yang ingin Anda animasikan
        objectAnimator = ObjectActivate.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectAnimator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectAnimator.SetBool("isOpen", false);
        }
    }
}
