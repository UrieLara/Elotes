using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textGameOver;

    public Button restartBtn;
    public Button exitBtn;

    string scoreString = "";
    string targetsString = "";

    bool gameOverShown = false;

    private void Start()
    {
        textGameOver.enabled = false;

        restartBtn.gameObject.SetActive(false);
        exitBtn.gameObject.SetActive(false);
    }
    void Update()
    {
        TextTime();
        TextScore();

        targetsString = GameManager.Instance.CantTargets.ToString();
        scoreString = GameManager.Instance.Score.ToString();

        if (GameManager.Instance.GameTimer <= 0 && !gameOverShown)
        {
            gameOverShown = true;

            Invoke(nameof(ShowGameOver), 2f);
        }
    }

    void ShowGameOver()
    {
        textGameOver.text = "Game Over " + scoreString + "/" + targetsString;
        textGameOver.enabled = true;

        restartBtn.gameObject.SetActive(true);
        exitBtn.gameObject.SetActive(true);
    }

    void TextTime()
    {
        if (GameManager.Instance.GameTimer > 31)
        { 
            textTime.text = "Ready?";
        }
        else
        {
            textTime.text = ((int)GameManager.Instance.GameTimer).ToString() + "s";
        }
            
    }

    void TextScore()
    {
        textScore.text = "Score: " + GameManager.Instance.Score.ToString();
    }
}
