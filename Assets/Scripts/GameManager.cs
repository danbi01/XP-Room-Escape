using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneStateManager sceneStateManager;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // SceneStateManager 추가
        if (sceneStateManager == null)
            sceneStateManager = gameObject.AddComponent<SceneStateManager>();
    }
}
