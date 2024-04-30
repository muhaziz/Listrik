using UnityEngine;

public class ResultMenu : MonoBehaviour
{
    public GameObject[] stars; // Array untuk menyimpan bintang-bintang yang akan diaktifkan

    public void SetStarsActive(int coinCount)
    {
        // Matikan semua bintang
        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }

        // Aktifkan bintang sesuai dengan jumlah koin
        for (int i = 0; i < coinCount; i++)
        {
            stars[i].SetActive(true);
        }
    }
}
