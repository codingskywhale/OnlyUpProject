using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject GamePauseUIPrefab;
    public GameObject GamePauseUI;

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

        if ( (GameManager.Instance.currentGameState == GameState.GameStart) && GamePauseUI == null)
        {
            GamePauseUI = Instantiate(GamePauseUIPrefab);
        }
    }


}
