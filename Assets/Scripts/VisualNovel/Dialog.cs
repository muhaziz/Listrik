using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "VisualNovel/Dialog", order = 3)]
public class Dialog : ScriptableObject
{
    public DialogLine[] dialogLines;
}
