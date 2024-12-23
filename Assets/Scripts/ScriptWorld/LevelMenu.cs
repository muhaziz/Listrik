using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject ParentButtons;

    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
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
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = ParentButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
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
