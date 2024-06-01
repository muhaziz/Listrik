using UnityEngine;

[CreateAssetMenu(fileName = "CharacterExpression", menuName = "VisualNovel/CharacterExpression", order = 1)]
public class CharacterExpression : ScriptableObject
{
    public string expressionName;
    public Sprite expressionSprite;
}
