using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(OnClickMainMenuButton);
    }

    public void OnClickMainMenuButton()
    {
        GameManager.Instance.IntroState();
    }
}
