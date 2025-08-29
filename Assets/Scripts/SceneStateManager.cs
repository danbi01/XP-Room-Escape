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
            Debug.Log("Restoring scene state for Computer scene");
            RestoreSceneState();
        }
    }

    public void SaveSceneState()
    {
        if (!manageThisScene) return;

        savedStates = new Dictionary<string, bool>();
        var objs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (var obj in objs)
        {
            string path = GetFullPath(obj.transform);
            savedStates[path] = obj.activeSelf;
        }
    }

    public void RestoreSceneState()
    {
        if (!manageThisScene || savedStates == null) return;

        var objs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var obj in objs)
        {
            string path = GetFullPath(obj.transform);
            if (savedStates.ContainsKey(path))
                obj.SetActive(savedStates[path]);
        }
        Debug.Log("RestoreSceneState 실행됨");
    }

    private string GetFullPath(Transform t)
    {
        if (t.parent == null) return t.name;
        return GetFullPath(t.parent) + "/" + t.name;
    }
}
