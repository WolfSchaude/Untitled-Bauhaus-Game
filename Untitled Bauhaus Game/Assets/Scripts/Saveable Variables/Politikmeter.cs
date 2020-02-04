using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politikmeter : MonoBehaviour, ISaveableInterface
{
	public float Politiklevel { get; private set; } = 100;
		
    public Slider PolitikOutput;

	[SerializeField] Image _Eisernes_Kreuz;
	[SerializeField] Image _HammerUndSichel;

	public GameObject SaveGameKeeper;

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

		float temp = Politiklevel / 200;

		_HammerUndSichel.fillAmount = temp;
		_Eisernes_Kreuz.fillAmount = 1 - temp;

		print(temp);
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
