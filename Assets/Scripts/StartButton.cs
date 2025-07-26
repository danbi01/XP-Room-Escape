using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButtonClickHandler()
    {
        Debug.Log("start");
        SceneManager.LoadScene("Story");
    }
    public void StoryOkButtonClickHandler()
    {
        Debug.Log("StorySkip");
        SceneManager.LoadScene("SouthWall");
    }
}
