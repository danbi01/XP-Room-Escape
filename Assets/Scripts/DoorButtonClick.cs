using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorButtonClick : MonoBehaviour
{
    public Sprite openedDoorSprite;
    private Image buttonImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Image ������Ʈ ��������
        buttonImage = GetComponent<Image>();
        //Button ������Ʈ���� Ŭ�� �̺�Ʈ ���
        GetComponent<Button>().onClick.AddListener(OnDoorClick);
    }
    //�� Ŭ�� �Լ�
    void OnDoorClick()
    {
        //�� Ŭ���� ������ ���ȭ������ ��ü
        buttonImage.sprite = openedDoorSprite;
        //���� ������ ��ȯ
        SceneManager.LoadScene("Epilogue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
