using UnityEngine;
using UnityEngine.SceneManagement;
public class ItemManager : MonoBehaviour
{
    public GameObject InventoryManagerObject;
    public bool IsKeyInInventory = false, IsUsbInInventory = false, IsTestPaperInInventory = false;
    public static ItemManager Instance = null;
    void Start()
    {
        InventoryManagerObject = GameObject.Find("InventoryCanvas");
    }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        
    }
    // 키 클릭 시 작동 메소드 (터치로 수정 필요)
    public void KeyOnClick()
    {
        if (IsKeyInInventory)
        {
            Debug.Log("이것은 열쇠다.");
        }
        else
        {
            Debug.Log("add");
            // 인벤토리 내 아이템 리스트에 추가
            InventoryManager.Instance.ItemList.Add(gameObject);

            RectTransform keyRect = gameObject.GetComponent<RectTransform>();
            // 인벤토리 인터페이스 내에 표시 (추후 리스트로 위치 저장해 사용?)
            keyRect.anchoredPosition = new Vector3(764, 402, 0);

            //width가로
            keyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2);
            //height세로
            keyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);

            this.gameObject.transform.SetParent(InventoryManagerObject.transform);
            IsKeyInInventory = true;
        }    
    }
    // Usb 클릭 시 작동 메소드 
    public void UsbOnClick()
    {
        if (IsUsbInInventory)
        {
            Debug.Log("이것은 Usb다.");
        }
        else
        {
            Debug.Log("add");
            // 인벤토리 내 아이템 리스트에 추가
            InventoryManager.Instance.ItemList.Add(gameObject);

            RectTransform UsbRect = gameObject.GetComponent<RectTransform>();
            // 인벤토리 인터페이스 내에 표시 (추후 리스트로 위치 저장해 사용?)
            UsbRect.anchoredPosition = new Vector3(500, 402, 0);

            //width가로
            UsbRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2);
            //height세로
            UsbRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);

            this.gameObject.transform.SetParent(InventoryManagerObject.transform);
            IsUsbInInventory = true;
        }
    }

    // 시험지 클릭 시 작동 메소드 
    public void TestPaperOnClick()
    {
        if (IsTestPaperInInventory)
        {
            Debug.Log("이것은 오류메시지입니다.");
        }
        else
        {
            Debug.Log("add");
            // 인벤토리 내 아이템 리스트에 추가
            //InventoryManager.Instance.ItemList.Add(gameObject);
            IsTestPaperInInventory = true;
            Destroy(gameObject);
        }
    }

    public void ComputerExitHandler()
    {
        Debug.Log("컴퓨터 씬 이탈");
        GameManager.instance.sceneStateManager.SaveSceneState();
        Debug.Log("SaveSceneState");
        ObjectSpawnManager.Instance.CanvasSetActive();
        SceneManager.LoadScene("WestWall");

    }
}
