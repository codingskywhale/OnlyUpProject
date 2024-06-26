using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiPlayButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickMultiPlayButton);
    }

    public void OnClickMultiPlayButton()
    {
        SceneManager.LoadScene(3);
    }
}
