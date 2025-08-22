using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ComputerLogin : MonoBehaviour
{

    public TMP_InputField inputField_PW;
    private string passwordInput = "";
    private string password = "test1234";
    public GameObject lockScreen;
    public GameObject homeScreen;

    void Start()
    {
        homeScreen.SetActive(false);
    }
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
            // + 효과음 넣기
            // + LockScreen 천천히 사라지도록 - 시간 지연 주고, 투명도 transition (300ms?)
            lockScreen.SetActive(false);
            homeScreen.SetActive(true);
        }
        else
        {
            // + 비번 틀렸을 때... 효과 넣기?
            Debug.Log("Wrong!");
        }
    }
    public void PasswordInputChange()
    {
        passwordInput = inputField_PW.text;
    }
}
