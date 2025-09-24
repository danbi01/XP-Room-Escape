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

    public GameObject secureLabInnerCanvas;
    public GameObject secureLabInnerCanvas_Unlock;
    public GameObject secureLabInnerCanvas_Unlocked;

    public static bool secureLabUnlocked = false;

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
            secureLabInnerCanvas.SetActive(false); // 로그인 화면 없어지고 
            secureLabInnerCanvas_Unlock.SetActive(true); // 문 조작 화면 (예: 잠금 해제!)
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
    public void Unlock()
    {
        secureLabUnlocked = true;
        secureLabInnerCanvas_Unlock.SetActive(false); // 문 조작 화면 없어지고
        secureLabInnerCanvas_Unlocked.SetActive(true); // 해제완료되었다는 메시지 띄우기
    }
}
