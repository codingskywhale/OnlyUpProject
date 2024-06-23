using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : UIBase
{
    [SerializeField] private Text playTimeText;

    private void Awake()
    {
        playTimeText = GetComponent<Text>();
        playTimeText.text = GameManager.Instance.TimerFormat();
    }

    private void OnEnable()
    {
        playTimeText.text = GameManager.Instance.TimerFormat();
    }
}
