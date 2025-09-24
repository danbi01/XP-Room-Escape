using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneCleaner : MonoBehaviour
{
    void Start()
    {
        // 현재 활성화 씬
        Scene currentScene = SceneManager.GetActiveScene();

        // 모든 오브젝트 찾기 (비활성 포함)
        GameObject[] allObjects = FindObjectsByType<GameObject>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );
        foreach (GameObject obj in allObjects)
        {
            // 현재 씬에 없는 오브젝트 없애기(DontDestroyOnLoad)
            if (obj.scene != currentScene)
            {
                Destroy(obj);
            }
        }
    }
}
