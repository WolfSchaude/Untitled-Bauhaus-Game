using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
 
public class TimeKeeper : MonoBehaviour
{

	public int StartYear;
	public int StartMonth;
	public int StartDay;
	public int StartHour;
	public int StartMinute;
	public int StartSecond;

	public int currentYear;
    public int currentMonth;
    public int currentDay;

	public Text DateDisplay;

	private float gameTime;
	private const float MinToSec = 60;
	private const float HourToSec = 60 * 60;
	private const float DayToSec = 60 * 60 * 24;
	private const float MonthToSec = 60 * 60 * 24 * 31;
	private const float YearToSec = 60 * 60 * 24 * 31 * 13;

	void Awake()
	{

		gameTime += StartSecond;
		gameTime += StartMinute * MinToSec;
		gameTime += StartHour * HourToSec;
		gameTime += StartDay * DayToSec;
		gameTime += StartMonth * MonthToSec;
		gameTime += StartYear * YearToSec;

		currentDay = StartDay;
		currentMonth = StartMonth;
		currentYear = StartYear;

		InvokeRepeating("AddTimeTic", 0.1f, 2);
	}

	public void AddYear(int years)
	{
		AddTime((float)years * YearToSec);
	}

	public void AddMonth(int months)
	{
		AddTime((float)months * MonthToSec);
	}

	public void AddDay(int Days)
	{
		AddTime((float)Days * DayToSec);
	}
	public void AddTime(float sec)
	{
		gameTime += sec;
	}
	public void AddTimeTic()
	{
		AddTime((float)1 * DayToSec);
	}
	public string[] GetTime()
	{
		float currentTime = gameTime;

		currentYear = (int)(gameTime / YearToSec);
		currentTime -= currentYear * YearToSec;

		currentMonth = (int)(currentTime / MonthToSec);
		currentTime -= currentMonth * MonthToSec;

		currentDay = (int)(currentTime / DayToSec);
		currentTime -= currentMonth * DayToSec;

		int currentHour = (int)(currentTime / HourToSec);
		currentTime -= currentHour * HourToSec;

		int currentMinute = (int)(currentTime / MinToSec);
		currentTime -= currentMinute * MinToSec;

		int currentSecond = (int)gameTime;

        if (currentDay == 0)
        {
            currentDay = 1;
        }

        if (currentMonth == 0)
        {
            currentMonth = 1;
        }
        
		string[] times = new string[3];
		times[0] = currentYear.ToString();
		times[1] = currentMonth.ToString();
		times[2] = currentDay.ToString();

		return times;
	}

	void Update()
	{
		string[] times = GetTime();

		DateDisplay.text = times[2] + " . " + times[1] + " . " + times[0];

		//StopCoroutine("AddTimeTic");
	}
}
