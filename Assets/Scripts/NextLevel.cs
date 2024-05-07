using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public string scenename;
    public GameObject loadingScreen;
    public Slider loadingBar;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            ModeSelect();
        }
    }
    public void ModeSelect()
    {
        StartCoroutine(LoadSceneWithLoading());
    }
    IEnumerator LoadSceneWithLoading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
