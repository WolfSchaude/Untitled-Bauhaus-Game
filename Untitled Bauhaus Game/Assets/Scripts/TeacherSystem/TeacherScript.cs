using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherScript : MonoBehaviour
{
	private int GesammeleteGehälter;

	public GameObject prefab;
	public GameObject HereIsNothingPrefab;
	public GameObject parent;
	public GameObject hiredParent;
	public GameObject Ticker;
	public GameObject EventSystem;
	public GameObject Playervariables;

	public static List<GameObject> Bewerbungen = new List<GameObject>();
	public static List<GameObject> Eingestellte = new List<GameObject>();

	private bool Once = true;

	void Start()
	{
		Bewerbungen = new List<GameObject>();
		Eingestellte = new List<GameObject>();

		for (int i = 0; i < TeacherLoader.tb.Buffer.Count; i++)
		{
			if (!EventSystem.GetComponent<TeacherLoader>().HiredTeachers[i].Hired)
			{
				var x = Instantiate(prefab, parent.transform);

				x.GetComponent<Teacher_Memory>().SetMemory(TeacherLoader.tb.Buffer[i], hiredParent, Ticker, Playervariables, gameObject);
				x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[i].Geburtsdatum + Environment.NewLine + "Fachgebiete: " + TeacherLoader.tb.Buffer[i].Interessen;
				x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[i].Name;
				x.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[i].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[i].FortlaufendeKosten;
				x.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[i].Picture;

				Bewerbungen.Add(x);
			}
		}

		if (Eingestellte.Count == 0)
		{
			Eingestellte.Add(Instantiate(HereIsNothingPrefab, hiredParent.transform));
		}
	}

	public void GenerateHiredTeachers()
	{
		DeleteSample();
		
		var y = EventSystem.GetComponent<TeacherLoader>().HiredTeachers;


		for (int i = 0; i < y.Count; i++)
		{
			if (y[i].Hired)
			{
				var x = Instantiate(prefab, hiredParent.transform);

				x.GetComponent<Teacher_Memory>().SetMemory(y[i], hiredParent, Ticker, Playervariables, gameObject);
				x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + y[i].Geburtsdatum + Environment.NewLine + "Fachgebiete: " + y[i].Interessen;
				x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + y[i].Name;
				x.GetComponentsInChildren<Text>()[2].text = "";
				x.GetComponentsInChildren<Text>()[3].text = "";
				x.GetComponentsInChildren<Image>()[1].sprite = y[i].Picture;
				x.GetComponent<Button>().interactable = false;
				x.transform.GetChild(5).gameObject.SetActive(true);

				Eingestellte.Add(x);
			}
		}
	}

	void Update()
	{
		foreach (var item in Eingestellte)
		{
			if (!item.activeSelf)
			{
				item.SetActive(true);
			}
		}
	}

	public void laufendeKosten()
	{
		if (GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter > 0)
		{
			GesammeleteGehälter = TeacherLoader.tb.Buffer[1].FortlaufendeKosten * GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter;
			Playervariables.GetComponent<Money>().Bezahlen(GesammeleteGehälter);
			GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Gehälter in Höhe von " + GesammeleteGehälter + " RM bezahlt.");
		}
	}

	public void DeleteSample()
	{
		Debug.Log("Called DeleteSample");
		if (Once)
		{
			Destroy(Eingestellte[0]);
			Eingestellte.Clear();
			Once = false;
			Debug.Log("has destroyed");
		}
	}
}