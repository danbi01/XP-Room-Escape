using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawnManager : MonoBehaviour
{
    //아이템
    public GameObject Key, Usb, TestPaper;
    //부모 캔버스
    public GameObject Canvas, LargeBookCase;
    //아이템 생성여부
    public bool IsKeySpawned, IsUsbSpawned, IsTestPaperSpawned;
    public GameObject ExitButton;
    public GameObject[] Canvases = new GameObject[2];
    public static ObjectSpawnManager Instance = null;
    void Start()
    {
        IsKeySpawned = false;
        //Canvas RenderCamera 설정
        
        foreach (GameObject _canvas in Canvases){
            Canvas canvas = _canvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    void Awake()
    {   
        if(Instance!=null){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
        
        Canvases[0] = GameObject.Find("ButtonCanvas");
        Canvases[1] = GameObject.Find("InventoryCanvas");

        //캔버스
        if(Canvas==null){
            Canvas = GameObject.Find("Canvas");
        }
        //컴퓨터 Exit 버튼 생성
        if(SceneManager.GetActiveScene().name=="Computer"){
            Debug.Log("Exit 생성");
            GameObject ExitObject = Instantiate(ExitButton);
            // UI오브젝트(버튼)는 항상 Canvas 하위로 설정
            ExitObject.transform.SetParent(Canvas.transform, false);
            
            Canvases[0].SetActive(false);
            Canvases[1].SetActive(false);
        }
        else{

        }

        //Usb 생성
        switch(SceneManager.GetActiveScene().name){ 
            case "SouthWall": // SouthWall일 때
            
                Debug.Log(InventoryManager.Instance.ItemList.Contains(Usb));
                // 인벤토리에 Usb가 들어있으면
                //if(InventoryManager.Instance.ItemList.Contains(Usb)){
                if(Canvases[1].transform.Find("Usb(Clone)")){
                    IsUsbSpawned = true;
                    break;
                }
                else{
                    if(!IsUsbSpawned){  // 키가 생성되지 않았을 때
                        Debug.Log("usb 생성");
                        GameObject UsbObject = Instantiate(Usb, transform.position, transform.rotation);
                        // UI오브젝트(버튼)는 항상 Canvas 하위로 설정
                        UsbObject.transform.SetParent(Canvas.transform);
                        IsUsbSpawned = true;
                    }
                }
                break;
            
        }

        //Key 생성
        switch (SceneManager.GetActiveScene().name)
        {
            case "WestWall": // WestWall일 때

                Debug.Log(InventoryManager.Instance.ItemList.Contains(Key));
                // 인벤토리에 Key가 들어있으면
                //if(InventoryManager.Instance.ItemList.Contains(Key)){
                if (Canvases[1].transform.Find("Key(Clone)"))
                {
                    IsKeySpawned = true;
                    break;
                }
                else
                {
                    if (!IsKeySpawned)
                    {  // 키가 생성되지 않았을 때
                        Debug.Log("key 생성");
                        GameObject KeyObject = Instantiate(Key, transform.position, transform.rotation);
                        // UI오브젝트(버튼)는 항상 Canvas 하위로 설정
                        KeyObject.transform.SetParent(Canvas.transform);
                        IsKeySpawned = true;
                    }
                }
                break;

        }

        //TestPaper 생성
        switch (SceneManager.GetActiveScene().name)
        {
            case "EastWall": // EastWall일 때

                // 인벤토리에 TestPaper가 들어있으면
                //if(InventoryManager.Instance.ItemList.Contains(TestPaper)){
                if (ItemManager.Instance.IsTestPaperInInventory)
                {
                    IsTestPaperSpawned = true;
                    break;
                }
                else
                {
                    if (!IsTestPaperSpawned)
                    {  // 시험지가 생성되지 않았을 때
                        Debug.Log("TestPaper 생성");
                        GameObject TestPaperObject = Instantiate(TestPaper, transform.position, transform.rotation);
                        // 시험지는 LargeBookCase의 하위로 설정
                        TestPaperObject.transform.SetParent(LargeBookCase.transform);
                        IsTestPaperSpawned = true;
                    }
                }
                break;
        }
    }

    public void CanvasSetActive(){
        Debug.Log(GameObject.Find("InventoryManager").transform.GetChild(0));
        GameObject.Find("ButtonManager").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("InventoryManager").transform.GetChild(0).gameObject.SetActive(true);
    }
}
