using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politikmeter : MonoBehaviour
{
	private int Politiklevel = 0;
	public Text PolitikText;


    void Update()
    {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			ManipulatePolitics(10);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			ManipulatePolitics(-10);
		}

		PolitikText.text = "Aktuelle Politische Ausrichtung: " + Politiklevel;
    }

	public void ManipulatePolitics(int manipulator)
	{
		Politiklevel += manipulator;
		if (Politiklevel <= -100)
		{
			Politiklevel = -100;
		}
		if (Politiklevel >= 100)
		{
			Politiklevel = 100;
		}
	}
}
