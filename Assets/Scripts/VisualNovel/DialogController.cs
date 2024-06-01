using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;
    public CharacterController characterController;
    public Dialog currentDialog;

    private int currentLine;

    void Start()
    {
        currentLine = 0;
        ShowLine();
    }

    public void ShowLine()
    {
        if (currentDialog != null && currentLine < currentDialog.dialogLines.Length)
        {
            DialogLine line = currentDialog.dialogLines[currentLine];
            characterController.ChangeExpression(line.characterExpression);
            dialogText.text = line.dialogText;
            currentLine++;
        }
        else
        {
            Debug.Log("Dialog selesai.");
        }
    }

    public void OnNextButton()
    {
        ShowLine();
    }
}
