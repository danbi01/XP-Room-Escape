using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckList : MonoBehaviour
{
    public List<GameObject> CheckListUI = new List<GameObject>();
    public List<GameObject> Check_testpaper = new List<GameObject>();
     public List<GameObject> Check_escape = new List<GameObject>();

    public static CheckList Instance = null;
    void Awake()
    {
        if(Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        // 시험지 획득 시 CheckListUI에 Check아이콘 추가해서 같이 활성화/비활성화 될 수 있도록
        if (InventoryManager.Instance.IsTestPaperInInventory && CheckListUI.Count == 2)
        {
            CheckListUI.Add(Check_testpaper[0]);
            Check_testpaper[1].gameObject.SetActive(true);
        }
        // 탈출 성공 시 위와 같이 
    }
    
    public void CheckBoxClickHandler(bool active)
    {
        Debug.Log("CheckList On");
        foreach (var CheckUI in CheckListUI)
        {
            CheckUI.SetActive(active);
        }
    }
}
