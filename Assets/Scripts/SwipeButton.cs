using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SwipeButton : MonoBehaviour
{
    public static SwipeButton Instance = null;

    List<string> LabWallList = new List<string>() {"SouthWall", "EastWall", "NorthWall", "WestWall"};
    public int CurrentWallNumber = 0;
    void Awake()
    {
        if(Instance!=null){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        
    }
    // 왼쪽 화살표 버튼 눌렀을 때
    public void LeftButtonClickHandler()
    {
        CurrentWallNumber -= 1;
        if (CurrentWallNumber < 0)
        {
            CurrentWallNumber = 3;
        }
        Debug.Log("Left" + CurrentWallNumber);
        SceneManager.LoadScene(LabWallList[CurrentWallNumber]);
    }
    // 오른쪽 화살표 버튼 눌렀을 때
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
