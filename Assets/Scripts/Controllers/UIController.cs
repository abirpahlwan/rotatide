using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField] private RectTransform timeline;
    [SerializeField] private RectTransform gameover;

    void Start()
    {
        gameover.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameover.gameObject.SetActive(true);
    }
    
    public void OnClickTimelineButton(string scene)
    {
        SceneController.Instance.LoadScene(scene);
    }

    public void OnClickRestartButton()
    {
        SceneController.Instance.LoadScene("Title");
        gameover.gameObject.SetActive(false);
    }
}
