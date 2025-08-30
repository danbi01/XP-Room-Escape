using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject[] backgrounds = new GameObject[2];
    public bool isTwoBackground = false;

    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    //토글
    public void ToggleSwitch()
    {
        isTwoBackground = !isTwoBackground;
        BackGroundChanger(isTwoBackground);
    }

    //배경 바꾸는 함수
    public void BackGroundChanger(bool active)
    {
        backgrounds[0].SetActive(!active);
        backgrounds[1].SetActive(active);
    }
}
