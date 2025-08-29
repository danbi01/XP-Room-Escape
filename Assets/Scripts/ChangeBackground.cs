using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject onebackground;
    public GameObject twobackground;
    public bool istwobackground = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //배경전환
    public void BackGroundChanger()
    {
        //2번째 배경화면이 꺼져있는경우
        if (istwobackground == false)
        {
            onebackground.SetActive(false); //1번 배경화면을 끔
            twobackground.SetActive(true);  //2번 배경화면을 킴
            istwobackground = true; // 상태를 true로 변경하고 2번 배경화면임을 기록함.
        } 
        
        else
        {
            //반대로 2번 배경화면이 켜져있는 경우
            onebackground.SetActive(true); //1번 배경화면을 킴
            twobackground.SetActive(false); //2번 배경화면을 끔
            istwobackground = false; // 상태를 false로 변경하고 꺼져있음을 기록함.
        }
        
    }
}
