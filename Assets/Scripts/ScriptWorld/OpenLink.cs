using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public string linkURL = "https://youtu.be/TBcfhJoCVQo?si=2I8CxzyqtJ0zqm7O";

    public void OpenExternalLink()
    {
        Application.OpenURL(linkURL);
    }
}
