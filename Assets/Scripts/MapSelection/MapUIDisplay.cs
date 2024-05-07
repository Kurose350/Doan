using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapUIDisplay : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Text mapName;
    [SerializeField] private Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockedIcon;
    private int currentLevelIndex;

    public GameObject loadingScreen;
    public Slider loadingBar;

    public void UpdateMap(Map _newMap)
    {
        mapName.text = _newMap.mapName;
        mapName.color = _newMap.nameColor;
        mapDescription.text = _newMap.mapDescription;
        mapDescription.color = _newMap.nameColor;
        mapImage.sprite = _newMap.mapImage;

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 2) >= _newMap.levelIndex;

        if (mapUnlocked)
            mapImage.color = Color.white;
        else
            mapImage.color = Color.gray;

        playButton.interactable = mapUnlocked;
        lockedIcon.SetActive(!mapUnlocked);
        currentLevelIndex = _newMap.levelIndex + 1;
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadSceneWithLoading());
    }
    IEnumerator LoadSceneWithLoading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(currentLevelIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}