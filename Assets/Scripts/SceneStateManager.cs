using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateManager : MonoBehaviour
{
    private static Dictionary<string, Dictionary<string, bool>> savedStates
        = new Dictionary<string, Dictionary<string, bool>>();

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
        RestoreSceneState(scene.name);
    }

    public void SaveSceneState(string sceneName = null)
    {
        if (sceneName == null)
            sceneName = SceneManager.GetActiveScene().name;

        var state = new Dictionary<string, bool>();
        var objs = FindObjectsOfType<GameObject>(true);

        foreach (var obj in objs)
        {
            string path = GetFullPath(obj.transform);
            state[path] = obj.activeSelf;
            // Debug.Log($"[Save] {sceneName} :: {path} = {obj.activeSelf}");
        }

        savedStates[sceneName] = state;
    }

    public void RestoreSceneState(string sceneName = null)
    {
        if (sceneName == null)
            sceneName = SceneManager.GetActiveScene().name;

        if (!savedStates.ContainsKey(sceneName))
            return;

        var state = savedStates[sceneName];
        var objs = FindObjectsOfType<GameObject>(true);

        foreach (var obj in objs)
        {
            string path = GetFullPath(obj.transform);
            if (state.ContainsKey(path))
            {
                obj.SetActive(state[path]);
                // Debug.Log($"[Restore] {sceneName} :: {path} = {state[path]}");
            }
        }
    }

    private string GetFullPath(Transform t)
    {
        if (t.parent == null) return t.name;
        return GetFullPath(t.parent) + "/" + t.name;
    }
}
