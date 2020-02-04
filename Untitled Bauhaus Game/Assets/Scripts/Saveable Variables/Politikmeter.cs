using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Politikmeter : MonoBehaviour, ISaveableInterface
{
	public float Politiklevel { get; private set; } = 100;

	[SerializeField] const float politikMaximum = 200;
	[SerializeField] const float politikMinimum = 0;

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

		if (Politiklevel <= politikMinimum)
		{
			Politiklevel = 0;
		}
		if (Politiklevel >= politikMaximum)

		{
			Politiklevel = 200;
		}

		float temp = Politiklevel / 200;

		_HammerUndSichel.fillAmount = temp;
		_Eisernes_Kreuz.fillAmount = 1 - temp;
	}

	public void Save()
	{
		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentPolitics = Politiklevel;
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[3] = true;
	}

	public void Load(Save save)
	{
		Politiklevel = save.CurrentPolitics;
	}

	public void LoadStart()
	{
	}
}
