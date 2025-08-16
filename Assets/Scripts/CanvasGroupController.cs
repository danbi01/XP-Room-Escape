using UnityEngine;
using System.Collections.Generic;

public class CanvasGroupController : MonoBehaviour
{
    //index0은 MainCanvas
    public List<CanvasGroup> Canvases = new List<CanvasGroup>();
    void Start()
    {
        ShowCanvas(0);
    }
    public void ShowCanvas(int indexToShow)
    {
        for(int i=0; i<Canvases.Count; i++)
        {
            SetCanvasActive(Canvases[i], i == indexToShow);
        }
    }
    
    void SetCanvasActive(CanvasGroup cg, bool active)
    {
        cg.alpha = active ? 1f : 0f;
        cg.interactable = active;
        cg.blocksRaycasts = active;
    }

    /*
    Exit버튼은 기본적으로 비활성화 상태고 버튼 매니저 자식으로 들어감
    만약 ShowCanvas호출 시 indexToShow가 0이 아니라면 Exit버튼 활성화, 왼오른버튼 비활성화
    Exit버튼 누를 시 ShowCanvas(0); 실행하고 비활성화, 왼오른버튼 활성화
    */
}
