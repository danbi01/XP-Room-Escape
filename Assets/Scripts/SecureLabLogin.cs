using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SecureLabLogin : MonoBehaviour
{

    public TMP_InputField inputField_SLID;
    private string SLIDInput = "";
    private string SLID = "baehakjum2025";
    public TMP_InputField inputField_SLPW;
    private string SLPasswordInput = "";
    private string SLPassword = "23997";

    void Start()
    {

    }
    void Update()
    {
        // enter key down
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SLLogin();
        }
    }
    // button click
    public void SLLogin()
    {
        IDPWInputChange();
        
        if (SLIDInput == SLID && SLPasswordInput == SLPassword)
        {
            Debug.Log("Yay!\nLogged in! Let's go and open the door!");
        }
        else
        {
            if (SLIDInput == SLID)
                Debug.Log("ID Correct!");
            else
                Debug.Log("ID Wrong!");
            if (SLPasswordInput == SLPassword)
                Debug.Log("Password Correct!");
            else
                Debug.Log("Password Wrong!");
        }
    }
    public void IDPWInputChange()
    {
        SLIDInput = inputField_SLID.text;
        SLPasswordInput = inputField_SLPW.text;
    }
}
