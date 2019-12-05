using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{

	public Politikmeter politikmeterSkript;
	public Money moneySkript;
	public Studenten studentenSkript;
	public int tage;

	public int StartMonth;
	public int StartDay;
	public int StartHour;
	public int StartMinute;
	public int StartSecond;

	private float gameTime;
	private const float MinToSec = 60;
	private const float HourToSec = 60 * 60;
	private const float DayToSec = 60 * 60 * 24;
	private const float MonthToSec = 60 * 60 * 24 * 31;

	// Start is called before the first frame update
	void Start()
    {
		politikmeterSkript = GameObject.Find("Politikmeter").GetComponent<Politikmeter>();
		moneySkript = GameObject.Find("Money Display").GetComponent<Money>();
		studentenSkript = GameObject.Find("Studenten Counter").GetComponent<Studenten>();

		gameTime += StartSecond;
		gameTime += StartMinute * MinToSec;
		gameTime += StartHour * HourToSec;
		gameTime += StartDay * DayToSec;
		gameTime += StartMonth * MonthToSec;
	}

    // Update is called once per frame
    void Update()
    {
        if(politikmeterSkript.Politiklevel >= 200)
		{
			Application.Quit();
			Debug.Log("Bruh exit");
		}
		if(politikmeterSkript.Politiklevel <= 0)
		{
			Application.Quit();
			Debug.Log("also bruh exit");
		}
		if(moneySkript.money < 0)
		{
			//Bruh muss ich noch machen
		}
		//if(studentenSkript.StudentenAnzahl <= 0)
		//{
		//	Application.Quit();
		//	Debug.Log("bruh exit again");
		//}

    }
}
