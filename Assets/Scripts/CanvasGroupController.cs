using UnityEngine;
using System.Collections.Generic;



public class CanvasGroupController : MonoBehaviour
{
    //index0은 MainCanvas
    public List<CanvasGroup> Canvases = new List<CanvasGroup>();
    //버튼 선언
    GameObject exitButton, leftButton, rightButton;
    void Start()
    {   //버튼 할당
        exitButton = GameObject.Find("ButtonCanvas").transform.Find("ExitButton").gameObject;
        leftButton = GameObject.Find("ButtonCanvas").transform.Find("Left").gameObject;
        rightButton = GameObject.Find("ButtonCanvas").transform.Find("Right").gameObject;
        
        ShowCanvas(0);
    }
    public void ShowCanvas(int indexToShow)
    {
        for(int i=0; i<Canvases.Count; i++)
        {
            SetCanvasActive(Canvases[i], i == indexToShow);
        }

        //Exit버튼 활성화 여부
        if(indexToShow != 0)
        {   
            ExitButtonActive(true);
        }
        else
        {   
            ExitButtonActive(false);
        }
    }
    
    void SetCanvasActive(CanvasGroup cg, bool active)
    {
        cg.alpha = active ? 1f : 0f;
        cg.interactable = active;
        cg.blocksRaycasts = active;
    }

    //Exit버튼 활성화하는 함수
    void ExitButtonActive(bool active)
    {
        exitButton.SetActive(active);
        leftButton.SetActive(!active);
        rightButton.SetActive(!active);
    }
    /*
    Exit버튼은 기본적으로 비활성화 상태고 버튼 매니저 자식으로 들어감
    만약 ShowCanvas호출 시 indexToShow가 0이 아니라면 Exit버튼 활성화, 왼오른버튼 비활성화
    Exit버튼 누를 시 ShowCanvas(0); 실행하고 비활성화, 왼오른버튼 활성화
    */
}
