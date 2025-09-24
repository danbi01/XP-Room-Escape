using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CanvasGroupController : MonoBehaviour
{
    //index0은 MainCanvas
    public List<CanvasGroup> Canvases = new List<CanvasGroup>();
    public GameObject exit, left, right;
    public GameObject inventory;
    public Image SwitchOverlay;
    public Button exitButton;
    public int exitIndex;
    public static CanvasGroupController Instance = null;
    public Sprite[] switchImg = new Sprite[2];
    public bool usbConnected = false;

    void Awake()
    {
        if(Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //씬이 전환될 때마다 실행
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //캔버스 그룹 초기화 
        Canvases.Clear();
        //캔버스 그룹 찾아서 Canvases에 넣기
        CanvasGroup[] found = GameObject.FindObjectsByType<CanvasGroup>(FindObjectsSortMode.None);
        //캔버스 그룹 정렬
        System.Array.Sort(found, (a, b) => a.name.CompareTo(b.name));
        //정렬된 그룹을 리스트에 추가
        Canvases.AddRange(found);

        //exitIndex = 0;
        //exit버튼 이벤트 초기화
        exitButton.onClick.RemoveAllListeners();
        //exit버튼 클릭 연결
        exitButton.onClick.AddListener(() =>{
            if(exitIndex > 0)
            {
                exitIndex -= 1;
            }
            ShowCanvas(exitIndex);
        });
        
        //맨 처음에 exit버튼 비활성화
        if(exit != null)
        {
            exit.SetActive(false);
        }
        //맨 처음에 메인캔버스 보여줌
        if(Canvases != null)
        {   
            Debug.Log("메인캔버스 보여줌");
            ShowCanvas(0);
        }

        //메인캔버스, west책상, east책장에 있는 버튼 클릭 연결
        // GameObject mainCanvas = GameObject.Find("0_MainCanvas");
        // GameObject deskCanvas = GameObject.Find("1_LargeDesk");
        // GameObject bookcaseCanvas = GameObject.Find("1_LargeBookCase");
        // List<GameObject> CanvasWithButtons = new List<GameObject>{
        //     mainCanvas, deskCanvas, bookcaseCanvas
        // };

        GameObject CanvasParent = GameObject.Find("CanvasParent");
        List<GameObject> CanvasWithButtons = new List<GameObject> {CanvasParent};
        List<Button> buttons = new List<Button>();
        foreach(GameObject cwb in CanvasWithButtons)
        {
            if(cwb)
            {
                buttons.AddRange(cwb.GetComponentsInChildren<Button>());
            }
        }

        foreach(var btn in buttons)
        {
            //이전의 버튼 이벤트 다 지움
            btn.onClick.RemoveAllListeners();
            //버튼 이름을 _을 기준으로 구분함
            string[] split = btn.name.Split('_');
            //split[0]을 정수로 변환하여 targetIndex에 넣음
            if (split.Length > 0 && int.TryParse(split[0], out int targetIndex))
            {
                btn.onClick.AddListener(() =>
                {
                    exitIndex += 1;
                    ShowCanvas(targetIndex);
                });
            }
            else
            {
                //스위치 누르면 이미지 변경
                if (btn.name == "SwitchButton")
                {
                    btn.onClick.AddListener(() =>
                    {
                        Image switchImage = btn.gameObject.GetComponent<Image>();
                        switchImage.sprite = switchImage.sprite == switchImg[0] ? switchImg[1] : switchImg[0];
                        SwitchOverlay = GameObject.Find("BackgroundOverlay").GetComponent<Image>();
                        SwitchOverlay.color = new Color(10f / 255f, 10f / 255f, 25f / 255f, SwitchOverlay.color.a == 0.7f ? 0 : 0.7f);
                        SwitchOverlay.transform.SetParent(null);
                        DontDestroyOnLoad(SwitchOverlay.gameObject);
                        SwitchOverlay.transform.SetParent(GameObject.Find("InventoryCanvas").transform);
                        SwitchOverlay.transform.SetAsFirstSibling();
                        //SwitchOverlay.SetActive(!SwitchOverlay.activeSelf);
                    });
                }
                if (btn.name.StartsWith("Monitor"))
                {
                    btn.onClick.AddListener(() =>
                    {
                        //computer씬 오류로 잠시 주석처리
                        SceneManager.LoadScene("Computer");
                        Debug.Log("컴퓨터 씬 이동~~");
                    });
                }
                if (btn.name == "KeyHole")
                {
                    btn.onClick.AddListener(() =>
                    {//키를 갖고 있고 인벤토리를 눌러뒀을 경우
                        if (InventoryManager.Instance.IsKeyInInventory)
                        {
                            if (InventoryManager.Instance.toggleInventory)
                            {
                                RectTransform key = inventory.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
                                key.anchoredPosition = new Vector3(1300, 0, 0);
                                //Drawer_Closed 비활성화 Open활성화
                                GameObject.Find("3_DrawerExpanded").transform.GetChild(1).gameObject.SetActive(true);
                                GameObject.Find("3_DrawerExpanded").transform.GetChild(0).gameObject.SetActive(false);
                                InventoryManager.Instance.IsKeyInInventory = false;
                                ItemManager.Instance.InventoryOnClick();
                            }
                            else
                            {
                                Debug.Log("인벤토리를 눌러 아이템 활성화");
                            }

                        }
                        else
                        {
                            Debug.Log("열쇠가 필요하다");
                        }
                    });
                }
                if(btn.name == "UsbPort")
                {
                    btn.onClick.AddListener(() =>
                    {//usb를 갖고 있고 인벤토리를 눌러뒀을 경우
                        if(InventoryManager.Instance.IsUsbInInventory)
                        {
                            if(InventoryManager.Instance.toggleInventory)
                            {
                                GameObject usbObject = inventory.transform.GetChild(3).gameObject;
                                RectTransform Usb = usbObject.gameObject.GetComponent<RectTransform>();
                                Usb.anchoredPosition = new Vector3(-50, 200, 0);
                                usbObject.transform.SetParent(GameObject.Find("2_TowerExpanded").transform);
                                InventoryManager.Instance.IsUsbInInventory=false;
                                usbConnected = true;
                                ItemManager.Instance.InventoryOnClick();
                            }
                            else
                            {
                                Debug.Log("인벤토리를 눌러 아이템 활성화");
                            }
                        }
                        else
                        {
                            Debug.Log("usb가 필요하다");
                        }

                    });
                }
            }
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {   
        
    }

    //캔버스 보여주는 함수
    public void ShowCanvas(int indexToShow)
    {
        for(int i=1; i<Canvases.Count; i++)
        {
            SetCanvasActive(Canvases[i], i == indexToShow);
        }

        //Exit버튼 활성화 여부
        if(indexToShow != 0)
        {   
            ExitButtonActive(true);
        }
        else
        {   
            ExitButtonActive(false);
        }
        
    }
    
    void SetCanvasActive(CanvasGroup cg, bool active)
    {
        cg.alpha = active ? 1f : 0f;
        cg.interactable = active;
        cg.blocksRaycasts = active;
    }

    //Exit버튼 활성화하는 함수
    void ExitButtonActive(bool active)
    {
        if (SceneManager.GetActiveScene().name == "Computer"||SceneManager.GetActiveScene().name == "Epilogue") return;
        GameObject.Find("ButtonCanvas").transform.GetChild(2).gameObject.SetActive(active); //exit
        GameObject.Find("ButtonCanvas").transform.GetChild(0).gameObject.SetActive(!active); //left
        GameObject.Find("ButtonCanvas").transform.GetChild(1).gameObject.SetActive(!active); //right
    }
    

}
