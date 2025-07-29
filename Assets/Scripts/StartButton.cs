using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    void Start()
    {
        
    }

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
