using System;
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


	void Start()
	{
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
}