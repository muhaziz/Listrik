using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class AutoSceneChanger : MonoBehaviour
{
    public string sceneName;

    public float delay = 5.0f;

    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        // Menunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}
