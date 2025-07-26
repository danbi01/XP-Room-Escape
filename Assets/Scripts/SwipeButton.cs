using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SwipeButton : MonoBehaviour
{
    private static SwipeButton Instance = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    List<string> LabWallList = new List<string>() {"SouthWall", "EastWall", "NorthWall", "WestWall"};
    int CurrentWallNumber = 0;
    void Awake()
    {
        if(Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftButtonClickHandler()
    {
        CurrentWallNumber -= 1;
        if(CurrentWallNumber < 0){
            CurrentWallNumber = 3;
        }
        Debug.Log("Left"+CurrentWallNumber);
        SceneManager.LoadScene(LabWallList[CurrentWallNumber]);
    }

    public void RightButtonClickHandler()
    {
        CurrentWallNumber += 1;
        if(CurrentWallNumber > 3){
            CurrentWallNumber = 0;
        }
        Debug.Log("Right"+CurrentWallNumber);
        SceneManager.LoadScene(LabWallList[CurrentWallNumber]);
    }
}
