using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UntitledBauhausGame;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;

    public GameObject OptionMenu;

    public GameObject SaveGamemanager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1;

        GamePaused = false;
        Kamera.AbleToMove = true;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0;

        GamePaused = true;
        Kamera.AbleToMove = false;
    }

    public void LoadMenu()
    {
        GamePaused = false;
        Destroy(GameObject.Find("SceneSwitcher"));
        StartCoroutine(LoadInBackground("Main_Menu"));
    }

    public void ShowOptions()
    {
        Time.timeScale = 0f;
        GamePaused = true;

        OptionMenu.SetActive(true);
    }

    public void HideOptions()
    {
        Time.timeScale = 1f;

        GamePaused = false;

        OptionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadInBackground(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone && !SaveGamemanager.GetComponent<SaveGameManager>().SavingATM)
        {
            yield return null;
        }
    }
}
