using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ObjectInterection : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region BookDrag
    //책 드래그 기능 코드
    public List<Transform> allSlots = new List<Transform>();
    private Transform originalSlot;
    private Transform canvasRoot;
    //드래그 중 우선 렌더용
    //private Canvas overrideCanvas;

    void Start()
    {
        //최상위 캔버스 찾기 
        canvasRoot = GetComponentInParent<Canvas>().transform;
        //시작할 때 슬롯 기억하기 (잘못 드래그하면 다시 원위치로 돌아옴)
        originalSlot = transform.parent;
    }

    //드래그 시작 시 책이 잘 보이게 최상위로 올림
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
        //마우스/손가락 위치를 UI 좌표로 변환 
        Vector2 localPoint;
        //최상위 캔버스 좌표
        RectTransform canvasRect = canvasRoot.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            //현재 마우스/터치 위치를 최상위 캔버스 상 좌표로 변환
            canvasRect, 
            //현재 마우스/터치 위치
            Input.mousePosition, 
            //렌더링 모드: 카메라 
            Camera.main, 
            //변환된 값을 localPoint 변수에 담음
            out localPoint);
        transform.localPosition = localPoint;

        //슬롯 체크
        Transform hoveredSlot = GetSlotUnderPointer(eventData);
        if(hoveredSlot != null && hoveredSlot.childCount > 0)
        {
            Transform otherBook = hoveredSlot.GetChild(0);
            if(otherBook != this.transform)
            {//드래그 중인 책이 자리를 뺏으면 빈 슬롯을 찾아 들어가기
                Transform emptySlot = FindEmptySlot();
                if(emptySlot != null)
                {
                    otherBook.SetParent(emptySlot);
                    otherBook.localPosition = Vector3.zero;
                }
            }
        }
    }
    
    //드래그 끝나면 빈 슬롯에 들어감
    public void OnEndDrag(PointerEventData eventData)
    {
        if(!CompareTag("Book")) return;
        Transform targetSlot = GetSlotUnderPointer(eventData);

        if(targetSlot != null && targetSlot.childCount == 0)
        {//빈 슬롯에 드롭 시 거기로 이동
            transform.SetParent(targetSlot);
            transform.localPosition = Vector3.zero;
        }
        else
        {//책이 있는 슬롯 or 슬롯 밖에다가 드롭 시 빈 슬롯으로 이동 
            Transform emptySlot = FindEmptySlot();
            if(emptySlot != null)
            {
                transform.SetParent(emptySlot);
                transform.localPosition = Vector3.zero;
            }
            else //실행될 일 없지만 안전장치로 만듦
            {//빈 슬롯이 없으면 원래 자리로 이동
                transform.SetParent(originalSlot);
                transform.localPosition = Vector3.zero;
            }
        }
    }

    //빈 슬롯을 찾는 함수
    private Transform FindEmptySlot()
    {
        foreach(Transform slot in allSlots)
        {
            if(slot.childCount == 0)
            {
                return slot;
            }
        }
        return null;
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

    /*
    #region LockerInputPassword
    //금고 비밀번호 입력 기능 코드
    public Image[] leds; 
    private string input = "";
    public string correctPassword = "1234";
    public int maxLength = 4;
    public Color ledOnColor = Color.Green;
    public Color ledOffColor = Color.Black;
    public Color errorColor = Color.red;

    public void OnNumberPress(string number)
    {
        if(input.Length < maxLength)
        {
            input += number;
            leds[input.Length - 1].color = ledOnColor;
            if(input.Length == maxLength)
            {
                StartCoroutine(CheckPassword());
            }
        }
    }

    IEnumerator CheckPassword()
    {
        //0.3초 딜레이
        yield return new WaitForSeconds(0.3f);
        if(input == correctPassword)
        {
            Debug.Log("잠금 해제");
        }
        else
        {
            Debug.Log("틀림");
            //빨검빨검
            for(int i=1; i<5; i++)
            {
                foreach(var led in leds)
                {
                    if(i%2)
                        led.color = errorColor;
                    else
                        led.color = ledOffColor;
                }
                yield return new WaifForSeconds(0.3f);
            }
            ResetLeds();
        }
        input = "";
    }

    void ResetLeds()
    {
        foreach(var led in leds)
            led.color = ledOffColor;
    }

    #endregion
    */
    public void ComputerClickHandler()
    {
        Debug.Log("computer 클릭");
        SceneManager.LoadScene("Computer");
    }

}
