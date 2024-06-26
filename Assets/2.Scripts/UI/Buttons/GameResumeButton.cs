using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResumeButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(OnClickGameResumeButton);
    }

    public void OnClickGameResumeButton()
    {
        GameManager.Instance.GameResume();
    }
}
