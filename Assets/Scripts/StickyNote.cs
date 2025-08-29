using UnityEngine;
using TMPro;

public class StickyNote : MonoBehaviour
{

    [SerializeField] private bool isDragging = false;
    public TMP_Text StickyHint;
    private Vector2 offset;

    void Update()
    {
        if (isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            StickyHint.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        Debug.Log("OnMouseDown!");
    }
    private void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("OnMouseDown!");
    }
}
