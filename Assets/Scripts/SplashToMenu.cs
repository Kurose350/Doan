using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{
    public GameObject theLogo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RunSplash());
    }
    IEnumerator RunSplash()
    {
        yield return new WaitForSeconds(0.5f);
        theLogo.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(1);
    }
}
