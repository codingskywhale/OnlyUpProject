using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Intro,
    GameStart,
    GameClear
}

public enum GameMode
{
    Single,
    Multi
}


public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _Instance;
        }
    }

    public GameState currentGameState { get; private set; }

    private float playTime = 0f;
    public bool IsGamePause { get; private set; } = false;

    public Player_tmp player;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            Application.targetFrameRate = 60;
            currentGameState = GameState.Intro;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_Instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (currentGameState == GameState.GameStart && IsGamePause == false)
        {
            playTime += Time.deltaTime;
        }
    }


    // State : 시작화면
    public void IntroState()
    {
        currentGameState = GameState.Intro;
        SceneManager.LoadScene(0);
    }


    public void GameStart()
    {
        currentGameState = GameState.GameStart;
        SceneManager.LoadScene(1);
    }

    public void GamePause()
    {
        if (IsGamePause == false)
        {
            IsGamePause = true;
            player.movementController.TogglePlayerInput();
            UIManager.Instance.GamePauseUI.SetActive(true);
        }
    }

    public void GameResume()
    {
        if (IsGamePause == true)
        {
            IsGamePause = false;
            player.movementController.TogglePlayerInput();
            UIManager.Instance.GamePauseUI.SetActive(false);
        }
    }


    // State : 게임 클리어
    public void GameClear()
    {
        currentGameState = GameState.GameClear;
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        currentGameState = GameState.GameStart;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public float GetPlayTime()
    {
        return playTime;
    }

    public string TimerFormat()
    {
        string result;

        int intPlayTime = (int)playTime;
        string hour = (intPlayTime / 3600).ToString("D2");
        string minute = ((intPlayTime % 3600) / 60).ToString("D2");
        string second = (intPlayTime % 60).ToString("D2");

        result = $"{hour}:{minute}:{second}";
        return result;
    }

}
