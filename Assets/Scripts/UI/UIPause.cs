using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPause : UIBase
{
    [SerializeField] private TMP_Text playTimeText;

    bool tmp_isInitialized = false; //

    private void Start()
    {
        UIManager.Instance.GamePauseUI = gameObject;
        SetActive(false);
        
    }

    private void OnEnable()
    {
        if (tmp_isInitialized == true) GameManager.Instance.GamePause();// TODO : �׽�Ʈ�� �ڵ��̹Ƿ� ���Ŀ� �� �ڵ� ������ ��.}
        
        playTimeText.text = GameManager.Instance.TimerFormat();
        tmp_isInitialized = true; //
    }
}
