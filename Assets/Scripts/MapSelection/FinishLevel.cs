using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public void Finish()
    {
        PlayerPrefs.SetInt("currentScene", PlayerPrefs.GetInt("currentScene") + 2);
    
    }
}