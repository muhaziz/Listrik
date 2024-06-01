using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Image characterImage;

    public void ChangeExpression(CharacterExpression characterExpression)
    {
        if (characterExpression != null)
        {
            characterImage.sprite = characterExpression.expressionSprite;
        }
        else
        {
            Debug.LogWarning("Ekspresi tidak valid.");
        }
    }
}
