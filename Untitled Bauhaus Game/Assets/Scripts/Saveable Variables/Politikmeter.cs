using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politikmeter : MonoBehaviour, ISaveableInterface
{
	public int Politiklevel { get; private set; } = 100;
		
    public Slider PolitikOutput;

	public GameObject SaveGameKeeper;

	void Start()
	{
		//Start replaced by LoadStart triggered by SaveGameManager
	}

    void Update()
    {
		PolitikOutput.value = Politiklevel;
    }

	public void ManipulatePolitics(int manipulator)
	{
		print("Vorheriges Level: " + Politiklevel);
		print("Manipulator: " + manipulator);

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

		print("Politiklevel jetzt: " + Politiklevel);
	}

	public void Save()
	{
		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentPolitics = Politiklevel;
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[3] = true;
	}

	public void Load(Save save)
	{
		PolitikOutput.maxValue = 200;
		PolitikOutput.minValue = 0;

		Politiklevel = save.CurrentPolitics;
	}

	public void LoadStart()
	{
		PolitikOutput.maxValue = 200;
		PolitikOutput.minValue = 0;
	}
}
