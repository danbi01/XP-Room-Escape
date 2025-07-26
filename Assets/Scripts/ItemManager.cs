using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject InventoryManagerObject;
    public bool IsInventory = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryManagerObject = GameObject.Find("InventoryCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KeyOnClick()
    {
            if(IsInventory)
            {
                Debug.Log("Already exist");
            }
            else
            {
                Debug.Log("add");
                InventoryManager.Instance.ItemList.Add(gameObject);
                RectTransform rectTrans = gameObject.GetComponent<RectTransform>();
                rectTrans.anchoredPosition = new Vector2(-459, -453);
                this.gameObject.transform.SetParent(InventoryManagerObject.transform);
                IsInventory = true;
            }
    }
}
