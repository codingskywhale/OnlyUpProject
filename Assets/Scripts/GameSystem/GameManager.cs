using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro,
    GameStart,
    GameOver,
    GameClear
}

public enum GameStage
{
    Stage1,
    Stage2
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
    public GameStage currentStage { get; private set; }
    public void SetStage(GameStage newStage)
    {
        currentStage = newStage;
    }

    //public Player player;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;

            Application.targetFrameRate = 60;
            currentGameState = GameState.Intro;
            currentStage = GameStage.Stage1;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_Instance != null)
            {
                Destroy(gameObject);
            }
        }

        if(currentGameState == GameState.GameStart)
        {
            GameStartState();
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
        UIManager.Instance.ActiveUI(GameState.GameStart);
    }

    public void GameStart()
    {
        currentGameState = GameState.GameStart;
        SceneManager.LoadScene(1);
    }

    // State : ���� ����
    public void GameOver()
    {
        currentGameState = GameState.GameOver;
        //player.controller.DisablePlayerInput();
        UIManager.Instance.ActiveUI(GameState.GameOver);

    }

    // State : ���� Ŭ����
    public void GameClear()
    {
        currentGameState = GameState.GameClear;
        //player.controller.DisablePlayerInput();
        UIManager.Instance.ActiveUI(GameState.GameClear);
    }

    public void Restart()
    {
        currentGameState = GameState.GameStart;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* 
     * TODO :
     * �������� 1���� �ٲ�����Ƿ� �Ʒ� �ڵ�� �̻��
     * ���� �����丵�Ͽ� �������� �߰��� ���� ��� ��뿹��
     */

    public void StageSelect(GameStage newStage)
    {
        currentStage = newStage;
        currentGameState = GameState.GameStart;

        int buildIndexOfStage1 = 1;
        int newStageIndex = buildIndexOfStage1 + (int)currentStage;
        SceneManager.LoadScene(newStageIndex);
    }

    public void NextStage()
    {

        Debug.Log("NextStage!");

        int currentIndex = (int)currentStage;
        int lastStageIndex = GameStage.GetValues(typeof(GameStage)).Length - 1;
        if (currentIndex == lastStageIndex)
        {
            Debug.Log("���� ������ ���������̹Ƿ� ���� ���������� �����ϴ�!!");
        }
        else
        {
            currentGameState = GameState.GameStart;
            currentStage++;
            int buildIndexOfStage1 = 1;
            int nextStageIndex = buildIndexOfStage1 + currentIndex;
            SceneManager.LoadScene(nextStageIndex);
        }
    }
}
