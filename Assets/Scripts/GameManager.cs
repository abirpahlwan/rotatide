using System;

public class GameManager : Singleton<GameManager>
{

    void Awake()
    {
        // TODO Unload all scenes
    }
    
    private void Start()
    {
        SceneController.Instance.LoadScene("Title");
    }
}
