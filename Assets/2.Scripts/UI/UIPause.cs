using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPause : UIBase
{
    [SerializeField] private TMP_Text playTimeText;

    private void OnEnable()
    {
        playTimeText.text = GameManager.Instance.TimerFormat();
    }
}
