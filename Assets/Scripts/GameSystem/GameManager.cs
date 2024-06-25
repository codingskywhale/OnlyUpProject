using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Intro,
    GameStart,
    GamePause,
    GameClear
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
    

    public Player_tmp player;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;

            Application.targetFrameRate = 60;
            // TODO : 테스트용으로 Start 상태에서 시작. 추후 인트로씬 만들면 intro에서 시작토록
            //currentGameState = GameState.Intro;
            currentGameState = GameState.GameStart;

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
        if(currentGameState == GameState.GameStart)
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
        if (currentGameState == GameState.GameStart)
        {
            currentGameState = GameState.GamePause;
            player.movementController.TogglePlayerInput();
            UIManager.Instance.GamePauseUI.SetActive(true);
        }
    }

    public void GameResume()
    {
        if (currentGameState == GameState.GamePause)
        {
            currentGameState = GameState.GameStart;
            player.movementController.TogglePlayerInput();
            UIManager.Instance.GamePauseUI.SetActive(false);
        }
    }
   

    // State : 게임 클리어
    public void GameClear()
    {
        currentGameState = GameState.GameClear;
        //SceneManager.LoadScene("EndingScene");
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        currentGameState = GameState.GameStart;
        // TODO : 나중에 buildindex로 수정
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
