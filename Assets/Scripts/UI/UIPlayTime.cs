using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayTime : MonoBehaviour
{
    [SerializeField] private TMP_Text playTimeText;

    private void Awake()
    {
        playTimeText.text = GameManager.Instance.TimerFormat();
    }

    private void Start()
    {
        playTimeText = GetComponent<TMP_Text>();
    }
}
