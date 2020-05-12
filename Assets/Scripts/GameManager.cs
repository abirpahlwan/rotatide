using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static SceneController SceneController;

    void Awake()
    {
        SceneController = gameObject.AddComponent<SceneController>();
    }
    
    private void Start()
    {
        SceneController.LoadScene("Title");
    }
    
    public void LoadScene(string sceneName)
    {
        SceneController.LoadScene(sceneName);
    }
}
