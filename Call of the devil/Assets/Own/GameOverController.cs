using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    static GameOverController singleton;

    [SerializeField]
    GameObject GameOverWindow;

    [SerializeField]
    GameObject PauseMenuWindow;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Awake()
    {
        singleton = this;
    }

    public static void GameOverScreen()
    {
        Time.timeScale = 0;
        singleton.StartCoroutine(singleton.showGameOverMenu());
    }


    public void PauseGame()
    {
        if (Time.timeScale < 1f)
            return;
        PauseMenuWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PauseMenuWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator showGameOverMenu()
    {
        Time.timeScale = 0.75f;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0;
        GameOverWindow.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
    public void NextLevel()
    {
        

        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.buildIndex + " : " + SceneManager.sceneCountInBuildSettings);
        if (scene.buildIndex+1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(scene.buildIndex+1);
        else
            SceneManager.LoadScene(0);
    }


    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
