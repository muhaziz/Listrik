using UnityEngine;
using UnityEngine.UI;

public class LinearProgressionAuthApacheSession : MonoBehaviour
{
    [Header("Auth Settings")]
    public string currentEmail;
    public InputField currentEmailField;
    public string currentOrganization;
    public InputField currentOrganizationField;

    private const string CURRENT_EMAIL_KEY = "CurrentEmail";
    private const string CURRENT_ORGANIZATION_KEY = "CurrentOrganization";

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitializeCurrentSession", 1);
    }

    public void InitializeCurrentSession()
    {
        // Mendapatkan nilai email dan organisasi dari PlayerPrefs
        currentEmail = PlayerPrefs.GetString(CURRENT_EMAIL_KEY);
        currentOrganization = PlayerPrefs.GetString(CURRENT_ORGANIZATION_KEY);

        // Menampilkan nilai email dan organisasi di input field
        currentEmailField.text = currentEmail;
        currentOrganizationField.text = currentOrganization;
    }
}
