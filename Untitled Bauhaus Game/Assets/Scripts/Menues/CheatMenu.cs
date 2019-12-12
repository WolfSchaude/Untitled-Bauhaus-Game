using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
	public GameObject CheatMenuWindow;
    void Start()
    {
        
    }

    void Update()
    {
		showWindow();
    }

	public void showWindow()
	{
		if (Input.GetKeyDown(KeyCode.F1) && !CheatMenuWindow.activeSelf)
		{
			CheatMenuWindow.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.F1) && CheatMenuWindow.activeSelf)
		{
			CheatMenuWindow.SetActive(false);
		}
	}
}
