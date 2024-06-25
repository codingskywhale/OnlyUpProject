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
        if(currentGameState == GameState.GameStart)
        {
            playTime += Time.deltaTime;
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
        currentGameState = GameState.GamePause;
        player.movementController.TogglePlayerInput();
        UIManager.Instance.GamePauseUI.SetActive(true);
    }

    public void GameResume()
    {
        currentGameState = GameState.GameStart;
        player.movementController.TogglePlayerInput();
        UIManager.Instance.GamePauseUI.SetActive(false);
    }
   

    // State : ���� Ŭ����
    public void GameClear()
    {
        currentGameState = GameState.GameClear;
        // TODO : ���߿� buildindex�� ����
        SceneManager.LoadScene("EndingScene");
        //SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        currentGameState = GameState.GameStart;
        // TODO : ���߿� buildindex�� ����
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


    // TODO : �Ʒ� �ڵ�� CharacterController������ �ű� ��.
    // ĳ���� �� �ڵ� ��� �Ǿ��ִ� ���� ���� �ӽ÷� ���⿡ ��
    /*
    public void TogglePlayerInput()
    {
        bool toggle = currentGameState == GameState.GamePause;
        Cursor.visible = toggle ? true : false;
        //playerInput.enabled = toggle ? false : true;
        ToggleCursor();
    }



    public void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        //canLook = !toggle;
    }
    */
    //
}
