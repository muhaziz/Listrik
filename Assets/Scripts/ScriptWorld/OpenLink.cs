using UnityEngine;

public class OpenLink : MonoBehaviour
{
    private string linkURL = "https://tel-u.ac.id/slimetric";

    public void OpenExternalLink()
    {
        Application.OpenURL(linkURL);
    }
}
