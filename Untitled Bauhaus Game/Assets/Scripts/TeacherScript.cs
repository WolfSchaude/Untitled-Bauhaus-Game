﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherScript : MonoBehaviour
{
	public GameObject prefab;
	public GameObject parent;
	public GameObject hiredParent;
	public GameObject Ticker;

	public static List<GameObject> Bewerbungen = new List<GameObject>();
	public static List<GameObject> Eingestellte = new List<GameObject>();

	//public static bool eingestellter1active = false;
	//public static bool eingestellter2active = false;
	//public static bool eingestellter3active = false;


	// Start is called before the first frame update
	void Start()
	{
		{
			//	//for (int i = 0; i < TeacherLoader.tb.Buffer.Count - 1; i++)
			//	//{

			//	//	if (TeacherLoader.tb.Buffer[i].Hireable)
			//	//	{
			//	//		bewerbungen.Add(Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform));
			//	//		eingestellter.Add(Instantiate(bewerbung, parent.transform));
			//	//		eingestellter[i].SetActive(true);
			//	//		bewerbungen[i].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[i].TeacherBeruf;
			//	//		bewerbungen[i].name = "Bewerber " + (i + 1);
			//	//		bewerbungen[i].GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[i].Picture;
			//	//		bewerbungen[i].GetComponent<ID_Storage>().ID = TeacherLoader.tb.Buffer[i].ID;
			//	//		bewerbungen[i].GetComponent<ID_Storage>().Kopie = TeacherLoader.tb.Buffer[i];
			//	//		Debug.Log("Anzahl der HiredTeacher vor der schleife: " + TeacherLoader.HiredTeachers.Count);
			//	//		bewerbungen[i].GetComponent<Button>().onClick.AddListener(() => { TeacherLoader.HiredTeachers.Add(TeacherLoader.tb.GetBufferTeacher(i)); Debug.Log(i + "Is Hireable: " + TeacherLoader.tb.Buffer[i].Hireable); TeacherLoader.tb.Buffer[i].NowHired(); Debug.Log(i + "Is Hireable2: " + TeacherLoader.tb.Buffer[i].Hireable); });
			//	//		bewerbungen[i].GetComponent<Button>().onClick.AddListener(() =>
			//	//		{
			//	//			/*eingestellter[i].SetActive(true);*/
			//	//			eingestellter[i].GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[i].Picture; eingestellter[i].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[i].TeacherBeruf; bewerbungen[i].SetActive(false); eingestellter1active = true;
			//	//		});
			//			//for (int j = 0; j < TeacherLoader.HiredTeachers.Count; j++)
			//			//{ eingestellter1.SetActive(true); eingestellter1.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[0].Picture; eingestellter1.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[0].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[0].TeacherBeruf; bewerbung1.SetActive(false); eingestellter1active = true;
			//			//	bewerbungen[i].GetComponent<Button>().onClick.AddListener(() =>
			//			//	{
			//			//		Debug.Log("Anzahl der HiredTeacher: " + TeacherLoader.HiredTeachers.Count);
			//			//		eingestellter.Add(Instantiate(bewerbung, parent.transform));
			//			//		TeacherLoader.tb.Buffer[i].NowHired();
			//			//		eingestellter[j].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.HiredTeachers[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.HiredTeachers[i].TeacherBeruf;
			//			//		eingestellter[j].GetComponent<Image>().sprite = TeacherLoader.HiredTeachers[i].Picture;
			//			//		eingestellter[j].GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Du willst einen Angestellten zuweisen?"); });
			//			//		TeacherLoader.HiredTeachers[i].IsAdded = true;
			//			//	});
			//			//}
			//			//bewerbungen[i].GetComponent<Button>().onClick.AddListener(() => { TeacherLoader.tb.Buffer[i].NowHired(); });
			//			//Debug.Log(i + ": " + TeacherLoader.tb.Buffer[i].Hireable);
			//		}
			//		//if (TeacherLoader.tb.Buffer[i].Hireable == false)
			//		//{
			//		//	bewerbungen[i].SetActive(false);
			//		//}

			//	}




		}
		//for (int i = 0; i < TeacherLoader.tb.Buffer.Count; i++)
		{ 
		/*
		{
			#region Bewerbung1
			GameObject bewerbung1 = Instantiate(prefab, GameObject.Find("ContentEinstellen").transform);
			GameObject eingestellter1 = Instantiate(prefab, parent.transform);
			Instantiate(DropdownGebaeude, transform.position - new Vector3(-200, 67, 0), Quaternion.identity, eingestellter1.transform);
			eingestellter1.SetActive(false);
			bewerbung1.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[0].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[0].Interessen;
			bewerbung1.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[0].Name;
			bewerbung1.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[0].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[0].FortlaufendeKosten;
			bewerbung1.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[0].Picture;
			bewerbung1.GetComponent<Button>().onClick.AddListener(() => 
			{
				eingestellter1.SetActive(true);
				eingestellter1.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[0].Picture;
				eingestellter1.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[0].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[0].Interessen;
				eingestellter1.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[0].Name;
				eingestellter1.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[0].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[0].FortlaufendeKosten;
				eingestellter1.GetComponentsInChildren<Text>()[3].text = "";
				bewerbung1.SetActive(false);
				eingestellter1active = true;
			});
			#endregion

			#region Bewerbung2
			GameObject bewerbung2 = Instantiate(prefab, GameObject.Find("ContentEinstellen").transform);
			GameObject eingestellter2 = Instantiate(prefab, parent.transform);
			Instantiate(DropdownGebaeude, transform.position - new Vector3(-200, 67, 0), Quaternion.identity, eingestellter2.transform);
			eingestellter2.SetActive(false);
			bewerbung2.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[1].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[1].Interessen;
			bewerbung2.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[1].Name;
			bewerbung2.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[1].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[1].FortlaufendeKosten;
			bewerbung2.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[1].Picture;
			bewerbung2.GetComponent<Button>().onClick.AddListener(() =>
			{
				eingestellter2.SetActive(true);
				eingestellter2.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[1].Picture;
				eingestellter2.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[1].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[1].Interessen;
				eingestellter2.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[1].Name;
				eingestellter2.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[1].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[1].FortlaufendeKosten;
				eingestellter2.GetComponentsInChildren<Text>()[3].text = "";
				TeacherLoader.tb.Buffer[1].ChangeStatus(Teacher.Status.Employed);
				//bewerbung2.GetComponent<Button>().onClick.AddListener(() =>
				//{
				//	Instantiate(DropdownGebaeude, eingestellter2.transform);
				//});
				bewerbung2.SetActive(false);
				eingestellter1active = true;
			});
			#endregion

			#region Bewerbung3
			GameObject bewerbung3 = Instantiate(prefab, GameObject.Find("ContentEinstellen").transform);
			GameObject eingestellter3 = Instantiate(prefab, parent.transform);
			Instantiate(DropdownGebaeude, transform.position - new Vector3(-200, 67, 0), Quaternion.identity, eingestellter3.transform);
			eingestellter3.SetActive(false);
			bewerbung3.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[2].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[2].Interessen;
			bewerbung3.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[2].Name;
			bewerbung3.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[2].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[2].FortlaufendeKosten;
			bewerbung3.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[2].Picture;
			bewerbung3.GetComponent<Button>().onClick.AddListener(() =>
			{
				eingestellter3.SetActive(true);
				eingestellter3.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[2].Picture;
				eingestellter3.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[2].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[2].Interessen;
				eingestellter3.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[2].Name;
				eingestellter3.GetComponentsInChildren<Text>()[2].text = "Einstellungskosten: " + TeacherLoader.tb.Buffer[2].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[2].FortlaufendeKosten;
				eingestellter3.GetComponentsInChildren<Text>()[3].text = "";
				bewerbung3.SetActive(false);
				eingestellter1active = true;
			});
			#endregion
		}
		*/
		}

		Bewerbungen = new List<GameObject>();
		Eingestellte = new List<GameObject>();

		for (int i = 0; i < TeacherLoader.tb.Buffer.Count; i++)
		{
			var x = Instantiate(prefab, parent.transform);

			x.GetComponent<Teacher_Memory>().SetMemory(TeacherLoader.tb.Buffer[i], hiredParent, Ticker);
			x.GetComponentsInChildren<Text>()[0].text = "Geboren: " + TeacherLoader.tb.Buffer[i].Geburtsdatum + Environment.NewLine + "Interessen: " + TeacherLoader.tb.Buffer[i].Interessen;
			x.GetComponentsInChildren<Text>()[1].text = "Formmeister: " + TeacherLoader.tb.Buffer[i].Name;
			x.GetComponentsInChildren<Text>()[2].text = "EInstellungskosten: " + TeacherLoader.tb.Buffer[i].Einstellungskosten + Environment.NewLine + "Fortlaufende Kosten: " + TeacherLoader.tb.Buffer[i].FortlaufendeKosten;
			x.GetComponentsInChildren<Image>()[1].sprite = TeacherLoader.tb.Buffer[i].Picture;

			Bewerbungen.Add(x);
		}
	}
	// Update is called once per frame
	void Update()
	{
		foreach (var item in Eingestellte)
		{
			if (!item.activeSelf)
			{
				item.SetActive(true);
			}
		}

		//for (int i = 0; i < TeacherLoader.tb.Buffer.Count - 1; i++)
		//{
		//	for (int j = 0; j < TeacherLoader.HiredTeachers.Count; j++)
		//	{
		//		if (TeacherLoader.tb.Buffer[i].Hireable == false)
		//		{
		//			bewerbungen[i].GetComponent<Button>().onClick.AddListener(() =>
		//			{
		//				Debug.Log("Anzahl der HiredTeacher: " + TeacherLoader.HiredTeachers.Count);
		//				eingestellter.Add(Instantiate(bewerbung, parent.transform));
		//				TeacherLoader.tb.Buffer[i].NowHired();
		//				eingestellter[j].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.HiredTeachers[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.HiredTeachers[i].TeacherBeruf;
		//				eingestellter[j].GetComponent<Image>().sprite = TeacherLoader.HiredTeachers[i].Picture;
		//				eingestellter[j].GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Du willst einen Angestellten zuweisen?"); });
		//				TeacherLoader.HiredTeachers[i].IsAdded = true;
		//			});
		//		}
		//		if(i >= 3) { i = 0; }
		//		//TeacherLoader.tb.Buffer[i].Hireable = false;
		//		//bewerbungen[i].SetActive(false);
		//	}

		//}

		//for (int j = 0; j < TeacherLoader.tb.Buffer.Count - 1; j++)
		//{
		//	for (int i = 0; i < TeacherLoader.HiredTeachers.Count; i++)
		//	{
		//		if (!TeacherLoader.HiredTeachers[i].IsAdded)
		//		{
		//			eingestellter.Add(Instantiate(bewerbung, parent.transform));
		//			eingestellter[i].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[j].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[j].TeacherBeruf;
		//			eingestellter[i].GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[j].Picture;
		//			eingestellter[i].GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Du willst einen Angestellten zuweisen?" + j); });
		//			TeacherLoader.HiredTeachers[j].IsAdded = true;
		//		}
		//	}
		//}

		//for (int i = 0; i < TeacherLoader.tb.Buffer.Count - 1; i++)
		//{
		//	for (int j = 0; j < TeacherLoader.HiredTeachers.Count; j++)
		//	{
		//		//Debug.Log(TeacherLoader.tb.Buffer[i].Hireable);
		//		if (TeacherLoader.tb.Buffer[i].Hireable == false)
		//		{
		//			bewerbungen[i].SetActive(false);
		//		}

		//		if (!TeacherLoader.HiredTeachers[j].IsAdded)
		//		{
		//			eingestellter.Add(Instantiate(bewerbung, parent.transform));
		//			eingestellter[i].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.HiredTeachers[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.HiredTeachers[i].TeacherBeruf;
		//			eingestellter[i].GetComponent<Image>().sprite = TeacherLoader.HiredTeachers[i].Picture;
		//			eingestellter[i].GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Du willst einen Angestellten zuweisen?"); });
		//			TeacherLoader.HiredTeachers[i].IsAdded = true;
		//		}
		//	}

		//}
	}
}



