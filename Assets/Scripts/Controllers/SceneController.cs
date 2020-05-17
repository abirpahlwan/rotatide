using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : Singleton<SceneController>
{
    public void LoadScene(string scene)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadSceneAsync(scene);

            // TODO Use toggle
            foreach (var button in UIController.Instance.transform.GetComponentsInChildren<Button>())
            {
                if (button.name.Equals(scene + "Button"))
                {
                    button.GetComponent<Image>().color = Color.cyan;
                    continue;
                }
                
                button.GetComponent<Image>().color = Color.white;
            }
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
