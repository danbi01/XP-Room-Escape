using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject Key;
    public GameObject Canvas;
    public bool IsKeySpawned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            case 3: //WestWall일 때
                Debug.Log(SwipeButton.Instance.CurrentWallNumber);
                //인벤토리에 Key가 들어있으면
                if(InventoryManager.Instance.ItemList.Contains(Key)){
                    break;
                }
                else{
                    if(!IsKeySpawned){
                        Debug.Log("key 생성");
                        GameObject KeyObject = Instantiate(Key, transform.position, transform.rotation);
                        KeyObject.transform.SetParent(Canvas.transform);
                        IsKeySpawned = true;
                    }
                }
                break;
        }
    }
}
