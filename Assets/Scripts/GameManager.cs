using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public AudioSource audioSrc_start = null;
    public float GameTimer = 35f;

    public event Action<int> OnScoreChanged;
    public event Action<int> OnCantElotesChanged;
    public event Action<int> OnCantPatosChanged;

    [SerializeField] int score = 0;
    [SerializeField] int cantElotes = 1;
    [SerializeField] int cantPatos = 0;

    public int Score
    {
        get => score;
        private set { if (score == value) return; score = value; OnScoreChanged?.Invoke(score); }
    }

    public int CantElotes
    {
        get => cantElotes;
        private set { if (cantElotes == value) return; cantElotes = value; OnCantElotesChanged?.Invoke(cantElotes); }
    }

    public int CantPatos
    {
        get => cantPatos;
        private set { if (cantPatos == value) return; cantPatos = value; OnCantPatosChanged?.Invoke(cantPatos); }
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
    public void AddElotes(int amount = 1) => CantElotes += Mathf.Max(0, amount);
    public void AddPatos(int amount = 1) => CantPatos += Mathf.Max(0, amount);

    public void ResetGame()
    {
        Score = 0;
        CantElotes = 0;
        GameTimer = 35f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
