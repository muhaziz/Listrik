using UnityEngine;

[CreateAssetMenu(fileName = "DialogLine", menuName = "VisualNovel/DialogLine", order = 2)]
public class DialogLine : ScriptableObject
{
    public CharacterExpression characterExpression;
    public string dialogText;
}
