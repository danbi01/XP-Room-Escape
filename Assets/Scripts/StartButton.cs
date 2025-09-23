using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public GameObject canvas;

    public void StoryOkButtonClickHandler()
    {
        Debug.Log("StorySkip");
        SceneManager.LoadScene("Intro");
    }

    public void StartButtonClickHandler()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("SouthWall");
    }

    public void GameRuleOpen()
    {
        Debug.Log("GameRule");
        canvas.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void GameRuleClose()
    {
        Debug.Log("Close");
        canvas.transform.GetChild(2).gameObject.SetActive(false);
    }

}
