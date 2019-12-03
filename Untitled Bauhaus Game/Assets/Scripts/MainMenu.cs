using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void Quit()
    {
        
            Application.Quit();

        

    }
}
