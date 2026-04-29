using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float MAX_GAME_TIMER = 35f;
    public static GameManager Instance { get; private set; }

    public AudioSource audioSrc_start = null;
    public float GameTimer = MAX_GAME_TIMER;

    public event Action<int> OnScoreChanged;
    public event Action<int> OnCantElotesChanged;
    public event Action<int> OnCantPatosChanged;

    [SerializeField] int score = 0;
    [SerializeField] int cantTargets = 1;

    public int Score
    {
        get => score;
        private set { if (score == value) return; score = value; OnScoreChanged?.Invoke(score); }
    }

    public int CantTargets
    {
        get => cantTargets;
        private set { if (cantTargets == value) return; cantTargets = value; OnCantElotesChanged?.Invoke(cantTargets); }
    }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start() => audioSrc_start?.Play();

    void Update()
    {
        GameTimer -= Time.deltaTime;
        if (GameTimer < 0) GameTimer = 0;
    }

    public void AddScore(int amount = 1) => Score += Mathf.Max(0, amount);
    public void AddTargets(int amount = 1) => CantTargets += Mathf.Max(0, amount);

    public void ResetGame()
    {
        Score = 0;
        CantTargets = 0;
        GameTimer = MAX_GAME_TIMER;

        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
