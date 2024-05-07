using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLoad : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadSceneWithLoading("Menu"));
    }
    public void LoadLevel()
    {
        StartCoroutine(LoadSceneWithLoading("Level"));
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("LevelSaved"))
        {
            levelToLoad = PlayerPrefs.GetString("LevelSaved");
            StartCoroutine(LoadSceneWithLoading(levelToLoad));
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneWithLoading(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
