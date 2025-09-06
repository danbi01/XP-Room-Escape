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
        //Image 컴포넌트 가져오기
        buttonImage = GetComponent<Image>();
        //Button 컴포넌트에서 클릭 이벤트 등록
        GetComponent<Button>().onClick.AddListener(OnDoorClick);
    }
    //문 클릭 함수
    void OnDoorClick()
    {
        //문 클릭시 검은색 배경화면으로 교체
        buttonImage.sprite = openedDoorSprite;
        //엔딩 씬으로 전환
        SceneManager.LoadScene("EndingScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
