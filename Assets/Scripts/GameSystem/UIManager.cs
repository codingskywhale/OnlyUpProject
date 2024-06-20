using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject GamePauseUIPrefab;
    public GameObject GamePauseUI;

    public GameObject InGameUIPrefab;
    public GameObject InGameUI;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
        }

        if (GamePauseUI == null)
        {
            GamePauseUI = Instantiate(GamePauseUIPrefab);
        }
        if (InGameUI == null)
        {
            InGameUI = Instantiate(InGameUIPrefab);
        }
    }
}
