using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politikmeter : MonoBehaviour
{

	public int Politiklevel = 100;

    public Slider PolitikOutput;

	void Start()
	{
		PolitikOutput.maxValue = 200;
		PolitikOutput.minValue = 0;
	}

    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.UpArrow))
		//{
		//	ManipulatePolitics(10);
		//}
		//if (Input.GetKeyDown(KeyCode.DownArrow))
		//{
		//	ManipulatePolitics(-10);
		//}

		PolitikOutput.value = Politiklevel;
    }

	public void ManipulatePolitics(int manipulator)
	{
		Politiklevel += manipulator;

		if (Politiklevel <= 0)
		{
			Politiklevel = 0;
		}
		if (Politiklevel >= 200)

		if (Politiklevel <= PolitikOutput.minValue)
		{
			Politiklevel = 0;
		}
		if (Politiklevel >= PolitikOutput.maxValue)

		{
			Politiklevel = 200;
		}
	}
}
