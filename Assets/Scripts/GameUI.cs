using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public TextMeshProUGUI victoryPanelTimerLabel;
    public TextMeshProUGUI hudTimerLabel;
    public GameObject theScore;
    public GameObject theScore2;

    private float timeLeft;
    private float maxTime = 600;
    private bool isPaused;

    void Start()
    {
        timeLeft = maxTime;
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;

        isPaused = true;
        UpdateTimerLabel(victoryPanelTimerLabel);
    }

    void Update()
    {
        if (isPaused)
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        UpdateTimerLabel(hudTimerLabel);
        if (timeLeft <= 0f) 
        {
            timeLeft = 0f; 
            ShowGameOverPanel();
        }
    }
    private void UpdateTimerLabel(TextMeshProUGUI label)
    {
        var minutes =  Mathf.FloorToInt(timeLeft / 60);
        var seconds = Mathf.FloorToInt(timeLeft % 60);
        var fraction = timeLeft * 100 % 100;

        label.text = $"{minutes:00} : {seconds:00} : {fraction:000}";
    }
    public void UpdateScore()
    {
        theScore.GetComponent<Text>().text = "Point: " + GemRotate.currentScore;
        theScore2.GetComponent<Text>().text = "Point: " + GemRotate.currentScore;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
