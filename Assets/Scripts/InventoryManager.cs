using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance = null;
    // 현재 인벤토리에 있는 아이템 리스트
    public List<GameObject> ItemList = new List<GameObject>(); 
    
    void Awake()
    {
        if(Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update()
    {
        
    }
}
