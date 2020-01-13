using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Save
{
	public int CurrentDay;
	public int CurrentMonth;
	public int CurrentYear;

	public float CurrentMoney;
	public int CurrentAnsehen;
	public int CurrentPolitics;
	public float StudentenAnzahl;

	public bool[] IsTeacherHired;

	//public List<int> BuiltBuildingParts = new List<int>();
	//public List<int> WhereIsTeacherHired = new List<int>();
	//public List<Exponat_Memory> ExponatesInInventory = new List<Exponat_Memory>();
	//public List<Event_Memory> CurrentEvents = new List<Event_Memory>();

}
