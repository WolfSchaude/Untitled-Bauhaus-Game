using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UntitledBauhausGame;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;

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
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
