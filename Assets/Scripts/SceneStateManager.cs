using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateManager : MonoBehaviour
{
    private static Dictionary<string, bool> savedStates;

    [SerializeField] private bool manageThisScene = true;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Computer")
        {
            RestoreSceneState();
        }
    }

    public void SaveSceneState()
    {
        if (!manageThisScene) return;

        savedStates = new Dictionary<string, bool>();
        var objs = FindObjectsOfType<GameObject>(true);

        foreach (var obj in objs)
        {
            string path = GetFullPath(obj.transform);
            savedStates[path] = obj.activeSelf;
            Debug.Log("saving " + path + " as... " + obj.activeSelf);
        }
    }

    public void RestoreSceneState()
    {
        if (!manageThisScene || savedStates == null) return;

        var objs = FindObjectsOfType<GameObject>(true);
        foreach (var obj in objs)
        {
            string path = GetFullPath(obj.transform);
            if (savedStates.ContainsKey(path))
            {
                obj.SetActive(savedStates[path]);
                Debug.Log("restoring "+path + " as... " + savedStates[path]);
            }
        }
    }

    private string GetFullPath(Transform t)
    {
        if (t.parent == null) return t.name;
        return GetFullPath(t.parent) + "/" + t.name;
    }
}
