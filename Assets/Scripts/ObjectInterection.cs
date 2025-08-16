using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ObjectInterection : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region BookDrag
    //책 드래그 
    private Transform originalSlot;
    private Transform canvasRoot;

    void Start()
    {
        //최상위 캔버스 찾기 
        canvasRoot = GetComponentInParent<Canvas>().transform;
        //시작할 때 슬롯 기억하기 (잘못 드래그하면 다시 원위치로 돌아옴)
        originalSlot = transform.parent;
    }

    //드래그 시작 시 최상위로 올림
    public void OnBeginDrag(PointerEventData eventData)
    {
        //대상이 책이 아니면 실행 안 함
        if(!CompareTag("Book")) return;
        originalSlot = transform.parent;
        transform.SetParent(canvasRoot); 
    }
    //드래그 중 마우스를 따라감
    public void OnDrag(PointerEventData eventData)
    {
        if(!CompareTag("Book")) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!CompareTag("Book")) return;
        Transform targetSlot = GetSlotUnderPointer(eventData);
        //슬롯에 드롭 시
        if(targetSlot != null)
        {
            if(targetSlot.childCount == 0)
            {//빈 슬롯에 드롭 시
                transform.SetParent(targetSlot);
                transform.localPosition = Vector3.zero;
            }
            else
            {//다른 책이 있으면
                Transform otherBook = targetSlot.GetChild(0);
                otherBook.SetParent(originalSlot);
                otherBook.localPosition = Vector3.zero;
                transform.SetParent(targetSlot);
                transform.localPosition = Vector3.zero;
            }
        }
        //슬롯이 아닌 곳에 드롭 시
        else
        {
            transform.SetParent(originalSlot);
            transform.localPosition = Vector3.zero;
        }
    }

    //드롭한 곳이 슬롯인 지 판별하는 함수
    private Transform GetSlotUnderPointer(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach(var result in results)
        {
            if(result.gameObject.CompareTag("Slot"))
            {
                return result.gameObject.transform;
            }
        }
        return null;
    }
    //책 드래그 끝
    #endregion

    void Update()
    {
        
    }

    public void ComputerClickHandler()
    {
        Debug.Log("computer 클릭");
        SceneManager.LoadScene("Computer");
    }

}
