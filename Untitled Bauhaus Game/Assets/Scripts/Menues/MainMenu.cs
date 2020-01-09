using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Open1;
    public GameObject Open2;

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

    public void OpenSecondaryMenu()
    {
        Open1.SetActive(true);
        Open2.SetActive(true);
    }


}
