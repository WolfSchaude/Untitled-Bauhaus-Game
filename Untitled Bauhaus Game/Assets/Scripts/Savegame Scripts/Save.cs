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
	public NewTimeKeeper.TimeMode CurrentMode;


	public float CurrentMoney;
	public int CurrentAnsehen;
	public int CurrentPolitics;
	public int StudentenAnzahl;
	public int MaxStudenten;

	public TeacherSave CurrentTeacherState;

	public EventSave CurrentEventState;

	public bool[] IsEventFinished;

	public int[,] ActiveBuildings;
	public int[,] StructuresInBuild;
	public bool[,,] StyleOrder;
	//public List<int> WhereIsTeacherHired = new List<int>();
	//public List<Exponat_Memory> ExponatesInInventory = new List<Exponat_Memory>();
	//public List<Event_Memory> CurrentEvents = new List<Event_Memory>();

}
