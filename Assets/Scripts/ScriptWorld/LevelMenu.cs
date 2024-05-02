using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject ParentButtons;

    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            levelButtons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }

    void ButtonsToArray()
    {
        int childCount = ParentButtons.transform.childCount;
        levelButtons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            levelButtons[i] = ParentButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
    public void ResetPlayerPrefs()
    {
        // Hapus kunci yang ingin di-reset
        PlayerPrefs.DeleteKey("ReachedIndex");
        PlayerPrefs.DeleteKey("UnlockedLevel");

        // Simpan perubahan
        PlayerPrefs.Save();

        // Atau, jika Anda ingin menghapus semua data PlayerPrefs
        // PlayerPrefs.DeleteAll();
    }

}
