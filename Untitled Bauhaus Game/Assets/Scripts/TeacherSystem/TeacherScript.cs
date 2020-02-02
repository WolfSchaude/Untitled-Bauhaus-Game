using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public GameObject prefab;
	public GameObject HereIsNothingPrefab;
	public GameObject parent;
	public GameObject hiredParent;
	public GameObject EventSystem;
	public GameObject Playervariables;

	//public static List<GameObject> Bewerbungen = new List<GameObject>();
	//public static List<GameObject> Eingestellte = new List<GameObject>();

	private bool Once = true;

	//------------------------------( Teacher Organisation Overhaul )------------------------------//
	/// <summary>
	/// Reference to: Savegamemanager GO
	/// </summary>
	[SerializeField] GameObject SaveGameKeeper;

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
	public static List<Teacher> _Teachers_Available = new List<Teacher>();
	/// <summary>
	/// All the hired but not assigned teachers
	/// </summary>
	public static List<Teacher> _Teachers_Hired = new List<Teacher>();
	/// <summary>
	/// All the hired AND assigned teachers
	/// </summary>
	public static List<Teacher> _Teachers_Assigned = new List<Teacher>();

	/// <summary>
	/// GameObject version of _Teachers_Available, holds references to the GO in the Scrollview
	/// </summary>
	public List<GameObject> Teachers_Available = new List<GameObject>();
	/// <summary>
	/// GameObject version of _Teachers_Hired, holds references to the GO in the Scrollview, old system
	/// </summary>
	public List<GameObject> Teachers_Hired_Old = new List<GameObject>();
	/// <summary>
	/// GameObject version of _Teachers_Hired, holds references to the GO in the Scrollview
	/// </summary>
	public List<GameObject> Teachers_Hired = new List<GameObject>();
	/// <summary>
	/// GameObject version of _Teachers_Assigned, holds references to the GO in the Scrollview, old version
	/// </summary>
	public List<GameObject> Teachers_Assigned = new List<GameObject>();


	void Start()
	{
		for (int i = 0; i < TeacherLoader.tb.Buffer.Count; i++)
		{
			Teachers_Available.Add(NewTeacher(TeacherLoader.tb.Buffer[i], parent.transform, false));

		}

		if (Teachers_Hired_Old.Count == 0)
		{
			Teachers_Hired_Old.Add(Instantiate(HereIsNothingPrefab, hiredParent.transform));
		}
	}

	void Update()
	{
	}

	public GameObject NewTeacher(Teacher y, Transform parent, bool hired)
	{
		var x = Instantiate(prefab, parent);

		if (hired)
		{
			x.GetComponent<Teacher_Memory>().SetMemory(y, hiredParent, Playervariables, gameObject.GetComponent<TeacherScript>());
			x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + y.Geburtsdatum + Environment.NewLine + "Fachgebiete: " + y.Interessen;
			x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + y.Name;
			x.GetComponentsInChildren<Text>()[2].text = "";
			x.GetComponentsInChildren<Text>()[3].text = "";
			x.GetComponentsInChildren<Image>()[1].sprite = y.Picture;
			x.GetComponent<Button>().interactable = false;
			x.transform.GetChild(5).gameObject.SetActive(true);

			return x;
		}
		else
		{
			x.GetComponent<Teacher_Memory>().SetMemory(y, hiredParent, Playervariables, gameObject.GetComponent<TeacherScript>());
			x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + y.Geburtsdatum + Environment.NewLine + "Fachgebiete: " + y.Interessen;
			x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + y.Name;
			x.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + y.Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + y.FortlaufendeKosten;
			x.GetComponentsInChildren<Image>()[1].sprite = y.Picture;

			return x;
		}
	}
	public GameObject NewTeacher(Teacher teacher, Transform parent)
	{
		var x = Instantiate(prefab, parent);

		if (teacher.Hired)
		{
			x.GetComponent<Teacher_Memory>().SetMemory(teacher, hiredParent, Playervariables, gameObject.GetComponent<TeacherScript>());
			x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + teacher.Geburtsdatum + Environment.NewLine + "Fachgebiete: " + teacher.Interessen;
			x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + teacher.Name;
			x.GetComponentsInChildren<Text>()[2].text = "";
			x.GetComponentsInChildren<Text>()[3].text = "";
			x.GetComponentsInChildren<Image>()[1].sprite = teacher.Picture;
			x.GetComponent<Button>().interactable = false;
			x.transform.GetChild(5).gameObject.SetActive(true);

			return x;
		}
		else
		{
			x.GetComponent<Teacher_Memory>().SetMemory(teacher, hiredParent, Playervariables, gameObject.GetComponent<TeacherScript>());
			x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + teacher.Geburtsdatum + Environment.NewLine + "Fachgebiete: " + teacher.Interessen;
			x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + teacher.Name;
			x.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + teacher.Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + teacher.FortlaufendeKosten;
			x.GetComponentsInChildren<Image>()[1].sprite = teacher.Picture;

			return x;
		}
	}
	/// <summary>
	/// Generates in hired
	/// </summary>
	/// <param name="teacher"></param>
	/// <returns></returns>
	public GameObject NewTeacher(Teacher teacher)
	{
		var x = Instantiate(prefab, hiredParent.transform);


		x.GetComponent<Teacher_Memory>().SetMemory(teacher, hiredParent, Playervariables, gameObject.GetComponent<TeacherScript>());
		x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + teacher.Geburtsdatum + Environment.NewLine + "Fachgebiete: " + teacher.Interessen;
		x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + teacher.Name;
		x.GetComponentsInChildren<Text>()[2].text = "";
		x.GetComponentsInChildren<Text>()[3].text = "";
		x.GetComponentsInChildren<Image>()[1].sprite = teacher.Picture;
		x.GetComponent<Button>().interactable = false;
		x.transform.GetChild(5).gameObject.SetActive(true);

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
			Playervariables.GetComponent<Money>().Bezahlen(GesammeleteGehälter);
			Ticker.NewTick.Invoke("Gehälter in Höhe von " + GesammeleteGehälter + " RM bezahlt.");
		}
	}

	public void DeleteSample()
	{
		Debug.Log("Called DeleteSample");
		if (Once)
		{
			Destroy(Teachers_Hired_Old[0]);
			Teachers_Hired_Old.Clear();
			Once = false;
			Debug.Log("Sample Teacher message got destroyed");
		}
	}

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
		foreach (var go in Teachers_Hired_Old)
		{
			Destroy(go);
		}

		Teachers_Available.Clear();
		Teachers_Assigned.Clear();
		Teachers_Hired_Old.Clear();


		foreach (var fm in _Teachers_Available)
		{
			Teachers_Available.Add(NewTeacher(fm, parent.transform));
		}

		foreach (var fm in _Teachers_Hired)
		{
			Teachers_Hired_Old.Add(NewTeacher(fm, hiredParent.transform));
			Teachers_Hired.Add(NewTeacher(fm, _Transform_Hired));
		}

		if (_Teachers_Hired.Count == 0)
		{
			Teachers_Hired_Old.Add(Instantiate(HereIsNothingPrefab, hiredParent.transform));
		}

		foreach (var fm in _Teachers_Assigned)
		{
			Teachers_Assigned.Add(NewTeacher(fm, _Transform_Assigned));
		}

		zugewiesenenCounter = _Teachers_Assigned.Count;
	}
}