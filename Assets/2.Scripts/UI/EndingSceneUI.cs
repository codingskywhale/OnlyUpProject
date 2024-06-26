using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingSceneUI : MonoBehaviour
{
    public TextMeshProUGUI playTimeText;

    void Start()
    {
        playTimeText.text = "Play Time: \n" + GameManager.Instance.TimerFormat();
        AudioManager.Instance.PlayEndingBGM();
    }
}
