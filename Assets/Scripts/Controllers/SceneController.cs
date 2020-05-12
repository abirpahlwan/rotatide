using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    public static SceneController Instance { get { return instance; } }
    
    private string previousSceneName;
    public string PreviousSceneName {get {return previousSceneName;}}

    private string currentSceneName;
    public string CurrentSceneName{get {return currentSceneName;}}
    
    void Awake ()
    {
        DontDestroyOnLoad(this);
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(currentSceneName))
        {
            previousSceneName = currentSceneName;
        }

        currentSceneName = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadPreviousScene()
    {
        
    }
    
    public void LoadNextScene()
    {
        
    }
}
