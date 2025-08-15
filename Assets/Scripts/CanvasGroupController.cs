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
    /* 코드 최적화
    public void ShowCanvas1()
    {
        SetCanvasActive(MainCanvas, false);
        SetCanvasActive(canvas1, true);
        if(canvas2 != null){
        SetCanvasActive(canvas2, false);
        }
    }
    public void ShowCanvas2()
    {
        SetCanvasActive(MainCanvas, false);
        SetCanvasActive(canvas1, false);
        if(canvas2 != null){
        SetCanvasActive(canvas2, true);
        }
    }
    public void HideAllCanvas()
    {
        SetCanvasActive(MainCanvas, true);
        SetCanvasActive(canvas1, false);
        if(canvas2 != null){
        SetCanvasActive(canvas2, false);
        }
    }
    */
    void SetCanvasActive(CanvasGroup cg, bool active)
    {
        cg.alpha = active ? 1f : 0f;
        cg.interactable = active;
        cg.blocksRaycasts = active;
    }
}
