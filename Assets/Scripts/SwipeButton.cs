using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SwipeButton : MonoBehaviour
{
    public static SwipeButton Instance = null;
    public GameObject ExitButton;
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
    
    void FixedUpdate()
    {
        //컴퓨터 Exit 버튼 활성화
        if(SceneManager.GetActiveScene().name=="Computer"){
            Debug.Log("컴퓨터 Exit 버튼 활성화");
            ExitButton.SetActive(true);
        }
        else{
            Debug.Log("컴퓨터 Exit 버튼 비활성화");
            ExitButton.SetActive(false);
        }
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
    public void ComputerExitHandler()
    {
        Debug.Log("컴퓨터 씬 이탈");
        SceneManager.LoadScene("WestWall");

    }
}
