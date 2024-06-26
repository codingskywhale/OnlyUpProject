using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }


    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        GamePauseUI = null;
        if (GameManager.Instance.currentGameState != GameState.Intro)
        {
            GamePauseUI = Instantiate(GamePauseUIPrefab);
        }
    }
}
