using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politikmeter : MonoBehaviour, ISaveableInterface
{

	public int Politiklevel = 100;

    public Slider PolitikOutput;

	public GameObject SaveGameKeeper;

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

	public void Save()
	{
		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentPolitics = Politiklevel;
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[3] = true;
	}

	public void Load(Save save)
	{
		Politiklevel = save.CurrentPolitics;
		//SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasLoaded[3] = true;
	}
}
