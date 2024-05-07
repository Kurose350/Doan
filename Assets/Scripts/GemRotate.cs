using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemRotate : MonoBehaviour
{
    public GameObject ScoreBox;
    public AudioController audioController;
    private int scoreValue = 1000;
    public static int currentScore = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * (Mathf.Cos(Time.time) * 0.003f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentScore += scoreValue;
            FindObjectOfType<GameUI>().UpdateScore();
            ScoreBox.GetComponent<Text>().text = currentScore.ToString();
            audioController.PlayItemCollected();
            Destroy(gameObject);
            if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
            {
                PlayerPrefs.SetInt("BestScore", currentScore);
            }
        }
    }
}
