using UnityEngine;

public class CreditScroll : MonoBehaviour
{
    public float scrollSpeed = 30f; // 초당 픽셀 이동 속도

    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        
    }

    void Update()
    {
    //픽셀 기반 좌표
        rect.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}

