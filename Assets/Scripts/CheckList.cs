using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour
{
    public List<GameObject> CheckListUI = new List<GameObject>();

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

    }
    
    public void CheckBoxClickHandler()
    {
        Debug.Log("CheckList On");
        foreach (var CheckUI in CheckListUI)
        {
            CheckUI.SetActive(true);
        }
    }

    public void CheckListOff()
    {
        Debug.Log("CheckList Off");
        foreach (var CheckUI in CheckListUI)
        {
            CheckUI.SetActive(false);
        }
    }
}
