using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCounts;

    private void Start()
    {
        coinsCounts = GameObject.FindGameObjectsWithTag("Stars").Length;

    }

    public void starsAchieved()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("Stars").Length;
        int coinsCollected = coinsCounts - coinsLeft;
        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCollected.ToString()) * 100;

        if (percentage >= 33 && percentage < 66)
        {
            stars[0].SetActive(true);
        }
        else if (percentage >= 66 && percentage < 70)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}