using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickGameStartButton);
    }

    public void OnClickGameStartButton()
    {
        GameManager.Instance.GameStart();
    }
}
