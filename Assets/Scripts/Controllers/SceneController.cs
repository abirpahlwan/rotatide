using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public void LoadScene(string scene)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadSceneAsync(scene);
        }
    }

    public void UnloadScene(string scene)
    {
        if (SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}
