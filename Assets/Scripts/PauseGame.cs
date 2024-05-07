using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public AudioSource levelMusic;
    public Sprite pauseIcon;
    public Sprite playIcon;
    public Image buttonImage;

    private bool isPaused = false;

    public void PauseUnpauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            levelMusic.Pause();
            buttonImage.sprite = playIcon; 
            isPaused = true; 
        }
    }

    public void UnpauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            levelMusic.UnPause();
            buttonImage.sprite = pauseIcon; 
            isPaused = false; 
        }
    }
}
