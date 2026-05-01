using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textGameOver;
    public TextMeshProUGUI textTargets;

    public Button nextLevel;
    public Button restartBtn;
    public Button exitBtn;

    private void Start()
    {
        // Suscribirse al evento del GameManager
        GameManager.Instance.OnStateChanged += ActualizarUI;
        GameManager.Instance.OnTimerChanged += ActualizarTimer;
        GameManager.Instance.OnGameOver += ShowGameOver;

        if (nextLevel != null)
            nextLevel.onClick.AddListener(() => GameManager.Instance.NextLevel());

        if (restartBtn != null)
            restartBtn.onClick.AddListener(() => GameManager.Instance.RestartLevel());

        if (exitBtn != null)
            exitBtn.onClick.AddListener(() => GameManager.Instance.QuitGame());

        textGameOver.enabled = false;
        textTargets.enabled = false;

        if (nextLevel != null) nextLevel.gameObject.SetActive(false);
        if (restartBtn != null) restartBtn.gameObject.SetActive(false);
        if (exitBtn != null) exitBtn.gameObject.SetActive(false);

        ActualizarUI();
    }
    void Update()
    {
        
    }

    void ActualizarTimer(float t)
    {
        if (GameManager.Instance.State == GameState.Menu) return;
        if (GameManager.Instance.State == GameState.Ready)
            textTime.text = "Ready?";
        else
            textTime.text = Mathf.CeilToInt(t).ToString() + "s";
    }

    void ActualizarUI()
    {
        textScore.text = $"Score: {GameManager.Instance.Score}";
    }

    void ShowGameOver()
    {
        int eliminados = GameManager.Instance.Patos + GameManager.Instance.Verduras;
        textTargets.text = $"Patos: {GameManager.Instance.Patos}     " +
                           $"Verduras: {GameManager.Instance.Verduras}\n" +
                           $"Total Targets: {eliminados}/{GameManager.Instance.TotalTargets}";
        textTargets.enabled = true;
        textGameOver.enabled = true;

        if (nextLevel != null) nextLevel.gameObject.SetActive(true);
        if (restartBtn != null) restartBtn.gameObject.SetActive(true);
        if (exitBtn != null) exitBtn.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnStateChanged -= ActualizarUI;
            GameManager.Instance.OnTimerChanged -= ActualizarTimer;  
            GameManager.Instance.OnGameOver -= ShowGameOver;         
    }
}
