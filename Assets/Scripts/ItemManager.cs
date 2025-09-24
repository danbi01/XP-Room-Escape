using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemManager : MonoBehaviour
{
    public GameObject InventoryManagerObject;
    public static ItemManager Instance = null;
    GameObject obj;
    
    void Start()
    {
        InventoryManagerObject = GameObject.Find("InventoryCanvas");
        obj = GameObject.Find("Inventory");
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
        if (InventoryManager.Instance.IsKeyInInventory)
        {
            InventoryOnClick();
        }
        else
        {
            Debug.Log("key add");
            // 인벤토리 내 아이템 리스트에 추가
            InventoryManager.Instance.ItemList.Add(gameObject);

            RectTransform keyRect = gameObject.GetComponent<RectTransform>();
            Button keyButtonComponent = gameObject.GetComponent<Button>();
            // 인벤토리 인터페이스 내에 표시
            keyRect.anchoredPosition = new Vector3(870, 450, 0);

            //알파 1로 수정
            ColorBlock cb = keyButtonComponent.colors;
            cb.normalColor = FixAlpha(cb.normalColor);
            cb.highlightedColor = FixAlpha(cb.highlightedColor);
            cb.pressedColor = FixAlpha(cb.pressedColor);
            cb.selectedColor = FixAlpha(cb.selectedColor);
            cb.disabledColor = FixAlpha(cb.disabledColor);
            keyButtonComponent.colors = cb;

            //width가로
            keyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 114.2f);
            //height세로
            keyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100.8f);

            this.gameObject.transform.SetParent(InventoryManagerObject.transform);
            InventoryManager.Instance.IsKeyInInventory = true;
            //키 없는 화분 활성화
            GameObject.Find("1_PotExpanded").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("1_PotExpanded").transform.GetChild(0).gameObject.SetActive(false);
        }    
    }
    // Usb 클릭 시 작동 메소드 
    public void UsbOnClick()
    {
        if (InventoryManager.Instance.IsUsbInInventory)
        {
            InventoryOnClick();
        }
        
        else
        {
            Debug.Log("add");
            // 인벤토리 내 아이템 리스트에 추가
            InventoryManager.Instance.ItemList.Add(gameObject);

            RectTransform UsbRect = gameObject.GetComponent<RectTransform>();
            // 인벤토리 인터페이스 내에 표시 (추후 리스트로 위치 저장해 사용?)
            UsbRect.anchoredPosition = new Vector3(870, 450, 0);

            //width가로
            UsbRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 146.6f);
            //height세로
            UsbRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 114.8f);

            this.gameObject.transform.SetParent(InventoryManagerObject.transform);
            InventoryManager.Instance.IsUsbInInventory = true;
        }
    }

    // 시험지 클릭 시 작동 메소드 
    public void TestPaperOnClick()
    {
        if (InventoryManager.Instance.IsTestPaperInInventory)
        {
            Debug.Log("이것은 오류메시지입니다.");
        }
        else
        {
            Debug.Log("add");
            // 인벤토리 내 아이템 리스트에 추가
            //InventoryManager.Instance.ItemList.Add(gameObject);
            InventoryManager.Instance.IsTestPaperInInventory = true;
            Destroy(gameObject);
        }
    }
    
    //인벤토리 토글
    public void InventoryOnClick()
    {
        Image inventorySlot = obj.GetComponent<Image>();
        InventoryManager.Instance.toggleInventory = !InventoryManager.Instance.toggleInventory;
        if(InventoryManager.Instance.toggleInventory)
        {
            inventorySlot.color = Color.gray;
        }
        else
        {
            inventorySlot.color = Color.white;
        }
    }

    private Color FixAlpha(Color c)
    {
        if (c.a == 0f)
            c.a = 1f;  // 1 = 255
        return c;
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
