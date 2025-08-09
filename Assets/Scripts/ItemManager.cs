using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemManager : MonoBehaviour
{
    public GameObject InventoryManagerObject;
    public bool IsInventory = false;
    void Start()
    {
        InventoryManagerObject = GameObject.Find("InventoryCanvas");
    }

    void Update()
    {
        
    }
    // 아이템 클릭 시 작동 메소드 (터치로 수정 필요)
    public void KeyOnClick()
    {
        if (IsInventory)
        {
            Debug.Log("Already exist");
        }
        else
        {
            Debug.Log("add");
            // 인벤토리 내 아이템 리스트에 추가
            InventoryManager.Instance.ItemList.Add(gameObject);

            RectTransform keyRect= gameObject.GetComponent<RectTransform>();
            // 인벤토리 인터페이스 내에 표시 (추후 리스트로 위치 저장해 사용?)
            keyRect.anchoredPosition = new Vector2(764, 402);

            //width가로
            keyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2);
            //height세로
            keyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);

            this.gameObject.transform.SetParent(InventoryManagerObject.transform);
            IsInventory = true;
        }
    }

    public void ComputerExitHandler()
    {
        Debug.Log("컴퓨터 씬 이탈");
        ObjectSpawnManager.Instance.CanvasSetActive();
        SceneManager.LoadScene("WestWall");

    }
}
