using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ComputerLogin : MonoBehaviour
{

    public TMP_InputField inputField_PW;
    private string passwordInput = "";
    private string password = "test1234";

    void Update()
    {
        // enter key down
        if (passwordInput.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Login();
        }
    }
    // button click
    public void Login()
    {
        PasswordInputChange();
        if (passwordInput == password)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
    public void PasswordInputChange()
    {
        passwordInput = inputField_PW.text;
    }
}
