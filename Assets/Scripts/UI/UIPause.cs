using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPause : UIBase
{
    [SerializeField] private TMP_Text playTimeText;

    private void Start()
    {
        UIManager.Instance.GamePauseUI = gameObject;
    }

    private void OnEnable()
    {
        GameManager.Instance.GamePause();// TODO : �׽�Ʈ�� �ڵ��̹Ƿ� ���Ŀ� �� �ڵ� ������ ��.
        playTimeText.text = GameManager.Instance.TimerFormat();
    }


    public void GameResumeButton()
    {
        GameManager.Instance.GameResume();
    }

    public void MainMenuButton()
    {
        GameManager.Instance.IntroState();
    }
}
