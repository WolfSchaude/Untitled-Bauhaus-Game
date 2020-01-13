using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Open1;
    public GameObject Open2;

    bool Opened = false;
    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void ChangeSceneNormal(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleSecondaryMenu()
    {
        if (Opened)
        {
            Open1.SetActive(false);
            Open2.SetActive(false);

            Opened = false;
        }
        else
        {
            Open1.SetActive(true);
            Open2.SetActive(true);

            Opened = true;
        }
    }

    public void OpenSecondaryMenu()
    {
        Open1.SetActive(true);
        Open2.SetActive(true);
    }

    public void CloseSecondaryMenu()
    {
        Open1.SetActive(false);
        Open2.SetActive(false);
    }
}
