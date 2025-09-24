using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorButtonClick : MonoBehaviour
{
    private Image DoorImg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Image ������Ʈ ��������
        DoorImg = GetComponent<Image>();
        //Button ������Ʈ���� Ŭ�� �̺�Ʈ ���
        GetComponent<Button>().onClick.AddListener(OnDoorClick);
    }
    //�� Ŭ�� �Լ�
    void OnDoorClick()
    {
        DoorImg.color = new Color(0, 0, 0);
        SceneManager.LoadScene("Epilogue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
