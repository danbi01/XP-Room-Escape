using UnityEngine;

public class CanvasGroupController : MonoBehaviour
{
    public CanvasGroup MainCanvas, canvas1, canvas2;
    void Start()
    {
        HideAllCanvas();
    }
    public void ShowCanvas1()
    {
        SetCanvasActive(MainCanvas, false);
        SetCanvasActive(canvas1, true);
        SetCanvasActive(canvas2, false);
    }
    public void ShowCanvas2()
    {
        SetCanvasActive(MainCanvas, false);
        SetCanvasActive(canvas1, false);
        SetCanvasActive(canvas2, true);
    }
    public void HideAllCanvas()
    {
        SetCanvasActive(MainCanvas, true);
        SetCanvasActive(canvas1, false);
        SetCanvasActive(canvas2, false);
    }
    void SetCanvasActive(CanvasGroup cg, bool active)
    {
        cg.alpha = active ? 1f : 0f;
        cg.interactable = active;
        cg.blocksRaycasts = active;
    }
}
