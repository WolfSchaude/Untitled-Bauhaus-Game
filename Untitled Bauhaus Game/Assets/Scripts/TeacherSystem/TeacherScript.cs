using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class TeacherMovementEvent : UnityEvent<Teacher>
{
}

[System.Serializable]
public class TeacherSave
{
	public int[] Avail;
	public int[] Hire;
	public int[] Assig;

	public TeacherSave(int[] avail, int[] hire, int[] assig)
	{
		Avail = avail;
		Hire = hire;
		Assig = assig;
	}
}

public class TeacherScript : MonoBehaviour, ISaveableInterface
{
	private int GesammeleteGehälter;

	public int zugewiesenenCounter = 0;

	//------------------------------( Teacher Organisation Overhaul )------------------------------//
	/// <summary>
	/// Reference to: Savegamemanager GO
	/// </summary>
	[SerializeField] GameObject SaveGameKeeper;
	/// <summary>
	/// The PreFab which gets cloned to instantiate the different Teachers in the various lists
	/// </summary>
	[SerializeField] GameObject _Formmeister_PreFab;

	/// <summary>
	///  Reference to: Transform to generate / subordinate the Cards in the scrollviews available
	/// </summary>
	[SerializeField] Transform _Transform_Available;
	/// <summary>
	/// Reference to: Transform to generate / subordinate the Cards in the scrollviews Hired BUT NOT assigned
	/// </summary>
	[SerializeField] Transform _Transform_Hired;
	/// <summary>
	/// Reference to: Transform to generate / subordinate the Cards in the scrollviews Hired AND assigned
	/// </summary>
	[SerializeField] Transform _Transform_Assigned;

	/// <summary>
	/// All the teachers available for hiring
	/// </summary>
	public List<Teacher> _Teachers_Available = new List<Teacher>();
	/// <summary>
	/// All the hired but not assigned teachers
	/// </summary>
	public List<Teacher> _Teachers_Hired = new List<Teacher>();
	/// <summary>
	/// All the hired AND assigned teachers
	/// </summary>
	public List<Teacher> _Teachers_Assigned = new List<Teacher>();

	/// <summary>
	/// GameObject version of _Teachers_Available, holds references to the GO in the Scrollview
	/// </summary>
	public List<GameObject> Teachers_Available = new List<GameObject>();
	/// <summary>
	/// GameObject version of _Teachers_Hired, holds references to the GO in the Scrollview
	/// </summary>
	public List<GameObject> Teachers_Hired = new List<GameObject>();
	/// <summary>
	/// GameObject version of _Teachers_Assigned, holds references to the GO in the Scrollview, old version
	/// </summary>
	public List<GameObject> Teachers_Assigned = new List<GameObject>();

	public static TeacherMovementEvent TeacherHired;

	public static TeacherMovementEvent TeacherAssigned;

	public static TeacherMovementEvent TeacherDeAssigned;

	const string _Zuweisen = "assign";

	const string _Einstellen = "hire";

	const string _DeZuweisen = "deassign";

	private void Awake()
	{
		if (TeacherHired == null)
			TeacherHired = new TeacherMovementEvent();
		if (TeacherAssigned == null)
			TeacherAssigned = new TeacherMovementEvent();
		if (TeacherDeAssigned == null)
			TeacherDeAssigned = new TeacherMovementEvent();

		TeacherHired.AddListener((x) => { print("Invoked Hired by : " + x.Name); HireTeacher(x); });
		TeacherAssigned.AddListener((x) => { print("Invoked Assigned by: " + x.Name); AssignTeacher(x); });
		TeacherDeAssigned.AddListener((x) => { print("Invoked DeAssigned by: " + x.Name); DeAssignTeacher(x); });
	}

	public GameObject NewTeacher(Teacher teacher, Transform parent, string buttonFunction)
	{
		var x = Instantiate(_Formmeister_PreFab, parent);

		x.GetComponent<Teacher_Memory>().SetMemory(teacher, gameObject.GetComponent<NewTimeKeeper>());

		x.GetComponentsInChildren<Text>()[0].text = teacher.Name;
		x.GetComponentsInChildren<Text>()[1].text = teacher.Geburtsdatum;
		x.GetComponentsInChildren<Text>()[2].text = teacher.Interessen;
		x.GetComponentsInChildren<Text>()[3].text = "Gehalt: " + teacher.FortlaufendeKosten;

		if (buttonFunction == _Einstellen)
		{
			x.GetComponent<Teacher_Memory>().SetButtonHire();
		}
		else if (buttonFunction == _Zuweisen)
		{
			x.GetComponent<Teacher_Memory>().SetButtonAssign();
		}
		else if (buttonFunction == _DeZuweisen)
		{
			x.GetComponent<Teacher_Memory>().SetButtonDeAssign();
		}

		return x;
	}

	public void LaufendeKosten()
	{
		GesammeleteGehälter = 0;

		for (int i = 0; i < _Teachers_Hired.Count; i++)
		{
			GesammeleteGehälter += _Teachers_Hired[i].Gehalt;
		}
		for (int i = 0; i < _Teachers_Assigned.Count; i++)
		{
			GesammeleteGehälter += _Teachers_Assigned[i].Gehalt;
		}

		if (GesammeleteGehälter > 0)
		{
			gameObject.GetComponent<Money>().Bezahlen(GesammeleteGehälter);
			Ticker.NewTick.Invoke("Gehälter in Höhe von " + GesammeleteGehälter + " RM bezahlt.");
		}
	}

	#region ISaveableInterface Methods
	public void Save()
	{
		int[] avail = new int[_Teachers_Available.Count];
		int[] hire = new int[_Teachers_Hired.Count];
		int[] assig = new int[_Teachers_Assigned.Count];

		for (int i = 0; i < _Teachers_Available.Count; i++)
		{
			avail[i] = _Teachers_Available[i].ID;
		}

		for (int i = 0; i < _Teachers_Hired.Count; i++)
		{
			hire[i] = _Teachers_Hired[i].ID;
		}

		for (int i = 0; i < _Teachers_Assigned.Count; i++)
		{
			assig[i] = _Teachers_Assigned[i].ID;
		}

		TeacherSave x = new TeacherSave(avail, hire, assig);

		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentTeacherState = x;
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[5] = true;
	}

	public void Load(Save save)
	{
		for (int i = 0; i < save.CurrentTeacherState.Avail.Length; i++)
		{
			_Teachers_Available.Add(TeacherLoader.tb.Buffer.Find(j => j.ID == save.CurrentTeacherState.Avail[i]));
		}

		for (int i = 0; i < save.CurrentTeacherState.Hire.Length; i++)
		{
			_Teachers_Hired.Add(TeacherLoader.tb.Buffer.Find(j => j.ID == save.CurrentTeacherState.Hire[i]));
			_Teachers_Hired[i].Hired = true;
		}

		for (int i = 0; i < save.CurrentTeacherState.Assig.Length; i++)
		{
			_Teachers_Assigned.Add(TeacherLoader.tb.Buffer.Find(j => j.ID == save.CurrentTeacherState.Assig[i]));
		}

		GenerateAllTeacherGOs();
	}

	public void LoadStart()
		{
			foreach (var fm in TeacherLoader.tb.Buffer)
			{
				_Teachers_Available.Add(fm);
			}

			GenerateAllTeacherGOs();
		}

	#endregion

	private void GenerateAllTeacherGOs()
	{
		foreach (var go in Teachers_Available)
		{
			Destroy(go);
		}
		foreach (var go in Teachers_Assigned)
		{
			Destroy(go);
		}
		foreach (var go in Teachers_Hired)
		{
			Destroy(go);
		}

		Teachers_Available.Clear();
		Teachers_Assigned.Clear();
		Teachers_Hired.Clear();


		foreach (var fm in _Teachers_Available)
		{
			Teachers_Available.Add(NewTeacher(fm, _Transform_Available, _Einstellen));
		}

		foreach (var fm in _Teachers_Hired)
		{
			Teachers_Hired.Add(NewTeacher(fm, _Transform_Hired, _Zuweisen));
		}

		foreach (var fm in _Teachers_Assigned)
		{
			Teachers_Assigned.Add(NewTeacher(fm, _Transform_Assigned, _DeZuweisen));
		}

		zugewiesenenCounter = _Teachers_Assigned.Count;
	}

	private void HireTeacher(Teacher teacher)
	{
		gameObject.GetComponent<Money>().Bezahlen(teacher.Einstellungskosten);

		teacher.Hired = true;

		_Teachers_Available.Remove(teacher);

		var buffer = Teachers_Available.Find(j => j.GetComponent<Teacher_Memory>().Memory.ID == teacher.ID);
		Teachers_Available.Remove(buffer);
		Destroy(buffer);

		_Teachers_Hired.Add(teacher);
		Teachers_Hired.Add(NewTeacher(teacher, _Transform_Hired, _Zuweisen));

		Ticker.NewTick.Invoke("Du hast den Formmeister " + teacher.Name + " eingestellt.");
	}

	private void AssignTeacher(Teacher teacher)
	{
		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().GetGesamtAnzahl() > zugewiesenenCounter)
		{
			_Teachers_Hired.Remove(teacher);

			var buffer = Teachers_Hired.Find(j => j.GetComponent<Teacher_Memory>().Memory.ID == teacher.ID);
			Teachers_Hired.Remove(buffer);
			Destroy(buffer);

			_Teachers_Assigned.Add(teacher);
			Teachers_Assigned.Add(NewTeacher(teacher, _Transform_Assigned, _DeZuweisen));

			zugewiesenenCounter++;
		}
		else
		{
			Ticker.NewTick.Invoke("Du hast momentan keine Posten zu besetzen.");
		}
	}

	private void DeAssignTeacher(Teacher teacher)
	{
		_Teachers_Assigned.Remove(teacher);

		var buffer = Teachers_Assigned.Find(j => j.GetComponent<Teacher_Memory>().Memory.ID == teacher.ID);
		Teachers_Assigned.Remove(buffer);
		Destroy(buffer);

		_Teachers_Available.Add(teacher);
		Teachers_Available.Add(NewTeacher(teacher, _Transform_Available, _Zuweisen));

		zugewiesenenCounter--;
	}
}