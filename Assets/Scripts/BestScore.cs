using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScore : MonoBehaviour
{
    public Text bestScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreDisplay.GetComponent<Text>().text = "Best Score: " + bestScore;
    }
    // Update is called once per frame
    public void UpdateBestScore(int newScore)
    {
        int currentBestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (newScore > currentBestScore)
        {
            PlayerPrefs.SetInt("BestScore", newScore);
            PlayerPrefs.Save();
            bestScoreDisplay.text = "Best Score: " + newScore;
        }
    }
}
