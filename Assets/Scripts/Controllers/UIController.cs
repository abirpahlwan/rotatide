using System;
using UnityEngine;

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

    public void OnClickRestartButton()
    {
        GameManager.Instance.LoadScene("Title");
        gameover.gameObject.SetActive(false);
    }
}
