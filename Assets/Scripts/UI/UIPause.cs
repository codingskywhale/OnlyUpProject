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
        if (tmp_isInitialized == true) GameManager.Instance.GamePause();// TODO : 테스트용 코드이므로 추후에 이 코드 삭제할 것.}
        
        playTimeText.text = GameManager.Instance.TimerFormat();
        tmp_isInitialized = true; //
    }
}
