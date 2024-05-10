using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombol : MonoBehaviour
{
    public GameObject ObjectActivate;
    public Animator objectAnimator; // Referensi ke komponen Animator pada objek yang ingin Anda animasikan

    private void Start()
    {
        // Mengambil referensi ke komponen Animator pada objek yang ingin Anda animasikan
        objectAnimator = ObjectActivate.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enters trigger zone");

            // Memeriksa apakah objek yang diaktifkan sedang aktif
            if (ObjectActivate.activeSelf)
            {
                Debug.Log("Close");
                ObjectActivate.SetActive(false);
                //  objectAnimator.SetBool("isOpen", false);
            }
            else
            {
                Debug.Log("Open");
                ObjectActivate.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exits trigger zone");

            if (ObjectActivate.activeSelf)
            {
                Debug.Log("Close");
                ObjectActivate.SetActive(false);
            }
            else
            {
                Debug.Log("Open");
                ObjectActivate.SetActive(true);
            }
        }
    }
}
