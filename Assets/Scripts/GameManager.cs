using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Menu, 
    Ready,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State { get; private set; }

    public LevelConfig[] levelsConfig;
    public int currentLevelIndex;

    public LevelConfig currentLevelConfig;



    const float MAX_GAME_TIMER = 30f;
    

    public float GameTimer { get; private set; }
    public bool IsGameOver => GameTimer <= 0;


    public int Score => score;
    public int Patos => patosEliminados;
    public int Verduras => verdurasEliminadas;
    public int TotalTargets => cantTargets;

    [SerializeField] int score = 0;
    [SerializeField] int patosEliminados = 0;
    [SerializeField] int verdurasEliminadas = 0;
    [SerializeField] int cantTargets = 0;



    public event Action OnStateChanged;
    public event Action<float> OnTimerChanged;
    public event Action OnGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void Update()
    {
        if (IsGameOver) return;

        if (GameTimer > 0)
        {
            GameTimer -= Time.deltaTime;
            OnTimerChanged?.Invoke(GameTimer);

            if (GameTimer <= 0)
            {
                GameTimer = 0;
                OnStateChanged?.Invoke(); // Avisar que el tiempo acabó
            }
        }
    }

    public void AddScore(TargetType targetType, int points)
    {
        score += points;
        if (targetType == TargetType.Pato) patosEliminados++;
        else if (targetType == TargetType.Verdura) verdurasEliminadas++;

        OnStateChanged?.Invoke(); // Avisar a la UI que algo cambió
    }

    public void AddTargets(int amount = 1)
    {
        cantTargets += amount;
        OnStateChanged?.Invoke();
    }

    private void Reset()
    {
        score = patosEliminados = verdurasEliminadas = cantTargets = 0;
        GameTimer = 0;
        State = GameState.Ready;
    }

    public void StartLevel()
    {
        StartCoroutine(LevelRoutine());
    }

    public void PlayLevel(int index)
    {
        currentLevelIndex = index;
        currentLevelConfig = levelsConfig[currentLevelIndex - 1];

        Reset();
        SceneManager.LoadScene(index);
    }

    public void RestartLevel()
    {
        Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int next = currentLevelIndex + 1;

        if (next <= levelsConfig.Length)
        {
            PlayLevel(next);
        }
    }
    IEnumerator LevelRoutine()
    {
        State = GameState.Ready;
        OnStateChanged?.Invoke();
        yield return new WaitForSeconds(5f);

        State = GameState.Playing;
        GameTimer = MAX_GAME_TIMER;
        OnStateChanged?.Invoke();

        while (GameTimer > 0)
        {
            GameTimer -= Time.deltaTime;
            OnTimerChanged?.Invoke(GameTimer);

            yield return null;
        }

        GameTimer = 0;
        State = GameState.GameOver;
        OnStateChanged?.Invoke();
        OnGameOver?.Invoke();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            State = GameState.Menu;
            OnStateChanged?.Invoke();
            return;
        }

        // Cancelar cualquier coroutine anterior antes de iniciar una nueva
        StopAllCoroutines();
        Reset();
        StartCoroutine(LevelRoutine());
    }

    public void QuitGame() => Application.Quit();

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
