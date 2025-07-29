using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject Key;
    public GameObject Canvas;
    public bool IsKeySpawned;
    void Start()
    {
        IsKeySpawned = false;
    }


    void FixedUpdate()
    {        
        if(Canvas==null){
            Canvas = GameObject.Find("Canvas");
        }
        switch(SwipeButton.Instance.CurrentWallNumber){ 
            case 3: // WestWall일 때
                Debug.Log(SwipeButton.Instance.CurrentWallNumber);
                // 인벤토리에 Key가 들어있으면
                if(InventoryManager.Instance.ItemList.Contains(Key)){
                    break;
                }
                else{
                    if(!IsKeySpawned){  // 키가 생성되지 않았을 때
                        Debug.Log("key 생성");
                        GameObject KeyObject = Instantiate(Key, transform.position, transform.rotation);
                        // UI오브젝트(버튼)는 항상 Canvas 하위로 설정
                        KeyObject.transform.SetParent(Canvas.transform);
                        IsKeySpawned = true;
                    }
                }
                break;
        }
    }
}
