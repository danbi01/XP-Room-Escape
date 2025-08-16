using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
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
        Debug.Log("Start");
        SceneManager.LoadScene("Story");
    }

    public void StoryOkButtonClickHandler()
    {
        Debug.Log("StorySkip");
        SceneManager.LoadScene("SouthWall");
    }
}
