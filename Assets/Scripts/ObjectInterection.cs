using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectInterection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComputerClickHandler()
    {
        Debug.Log("computer 클릭");
        SceneManager.LoadScene("Computer");
    }

    public void BookScroll()
    {
        
    }
}
