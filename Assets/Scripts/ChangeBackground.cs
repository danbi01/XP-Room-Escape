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

    //�����ȯ
    public void BackGroundChanger()
    {
        //2��° ���ȭ���� �����ִ°��
        if (istwobackground == false)
        {
            onebackground.SetActive(false); //1�� ���ȭ���� ��
            twobackground.SetActive(true);  //2�� ���ȭ���� Ŵ
            istwobackground = true; // ���¸� true�� �����ϰ� 2�� ���ȭ������ �����.
        } 
        
        else
        {
            //�ݴ�� 2�� ���ȭ���� �����ִ� ���
            onebackground.SetActive(true); //1�� ���ȭ���� Ŵ
            twobackground.SetActive(false); //2�� ���ȭ���� ��
            istwobackground = false; // ���¸� false�� �����ϰ� ���������� �����.
        }
        
    }
}
