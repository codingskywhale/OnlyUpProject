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

    bool isPlaying;

    public Text playTimeText;
    private float playTime = 0f;

    //public Player player;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;

            Application.targetFrameRate = 60;
            // TODO : �׽�Ʈ������ Start ���¿��� ����. ���� ��Ʈ�ξ� ����� intro���� �������
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
        if(currentGameState == GameState.GamePause)
        {
            playTime += Time.deltaTime;
            if (playTimeText != null)
            {
                playTimeText.text = TimerFormat();
            }
        }
    }


    // State : ����ȭ��
    public void IntroState()
    {
        currentGameState = GameState.Intro;
        SceneManager.LoadScene(0);
    }

    // State : ���� ����
    public void GameStartState()
    {
        currentGameState = GameState.GameStart;
        //UIManager.Instance.ActiveUI(GameState.GameStart);
    }

    public void GameStart()
    {
        currentGameState = GameState.GameStart;
        SceneManager.LoadScene(1);
    }

    public void GamePause()
    {
        
        switch (currentGameState)
        {
            case GameState.GameStart:
                currentGameState = GameState.GamePause;
                break;
            case GameState.GamePause:
                currentGameState = GameState.GameStart;
                break;
        }
        //UIManager.Instance.ToggleUI(GameState.GamePause);
    }

    

    // State : ���� Ŭ����
    public void GameClear()
    {
        currentGameState = GameState.GameClear;
        // TODO : ���߿� buildindex�� ����
        SceneManager.LoadScene("ClearScene");
        //SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        currentGameState = GameState.GameStart;
        // TODO : ���߿� buildindex�� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string TimerFormat()
    {
        int intPlayTime = (int)playTime;
        string hour = (intPlayTime / 3600).ToString("D2");
        string minute = ((intPlayTime % 3600) / 60).ToString("D2");
        string second = (intPlayTime % 60).ToString("D2");

        return $"{hour}:{minute}:{second}";
    }
}
