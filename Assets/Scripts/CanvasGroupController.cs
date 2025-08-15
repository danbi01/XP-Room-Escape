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
}
