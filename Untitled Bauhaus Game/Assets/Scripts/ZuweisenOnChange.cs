using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZuweisenOnChange : MonoBehaviour
{

	public bewerbungvisible Script;
	public bool checkeingestellt = false;

	public int oldVal = 0;

	void Start()
	{
		Script = GameObject.Find("EventSystem").GetComponent<bewerbungvisible>();

	}

	void Update()
	{
		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur > 0)
		{
			GetComponent<DropDownController>().EnableOption("Architekturwerkstatt", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur == 0)
		{
			GetComponent<DropDownController>().EnableOption("Architekturwerkstatt", false);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMalerei > 0)
		{
			GetComponent<DropDownController>().EnableOption("Malerei", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMalerei == 0)
		{
			GetComponent<DropDownController>().EnableOption("Malerei", false);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlAustellung > 0)
		{
			GetComponent<DropDownController>().EnableOption("Ausstellungsgestaltung", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlAustellung == 0)
		{
			GetComponent<DropDownController>().EnableOption("Ausstellungsgestaltung", false);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMetall > 0)
		{
			GetComponent<DropDownController>().EnableOption("Metallwerkstatt", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMetall == 0)
		{
			GetComponent<DropDownController>().EnableOption("Metallwerkstatt", false);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch > 0)
		{
			GetComponent<DropDownController>().EnableOption("Tischlerei", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch == 0)
		{
			GetComponent<DropDownController>().EnableOption("Tischlerei", false);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr > 0)
		{
			GetComponent<DropDownController>().EnableOption("Lehrsaal", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr == 0)
		{
			GetComponent<DropDownController>().EnableOption("Lehrsaal", false);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn > 0)
		{
			GetComponent<DropDownController>().EnableOption("Wohnheim", true);
		}

		if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn == 0)
		{
			GetComponent<DropDownController>().EnableOption("Wohnheim", false);
		}
	}

	void HandleInputData(int val)
	{
		bool active1 = false;
		bool active2 = false;
		bool active3 = false;
		bool active4 = false;
		bool active5 = false;
		bool active6 = false;
		bool active7 = false;

				switch (val)
		{
			case 0:
				Debug.Log("Nicht zugewiesen");
				break;
			case 1:
				Debug.Log("Ist der Architekturwerkstatt zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur > 0 && !active1)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur--;
					active1 = true;
				}
				break;

			case 2:
				Debug.Log("Ist der Malerei zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMalerei > 0 && !active2)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMalerei--;
					active2 = true;
				}
				break;

			case 3:
				Debug.Log("Ist der Ausstellungsgestaltung zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlAustellung > 0 && !active3)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlAustellung--;
					active3 = true;
				}
				break;

			case 4:
				Debug.Log("Ist der Metallwerkstatt zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMetall > 0 && !active4)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMetall--;
					active4 = true;
				}
				break;

			case 5:
				Debug.Log("Ist der Tischlerei zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch > 0 && !active5)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch--;
					active5 = true;
				}
				break;

			case 6:
				Debug.Log("Ist dem Lehrsaal zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr > 0 && !active6)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr--;
					active6 = true;
				}
				break;

			case 7:
				Debug.Log("Ist dem Wohnheim zugewiesen");
				if (GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn > 0 && !active7)
				{
					GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn--;
					active7 = true;
				}
				break;

			default:
				Debug.Log("Nicht zugewiesen");
				break;

		}

		switch (oldVal)
		{
			case 0:
				Debug.Log("nicht zugewiesen");
				break;
			case 1:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur++;
				break;
			case 2:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMalerei++;
				break;
			case 3:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlAustellung++;
				break;
			case 4:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMetall++;
				break;
			case 5:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch++;
				break;
			case 6:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr++;
				break;
			case 7:
				GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn++;
				break;
		}

		oldVal = val; 

		if (val > 0 && !checkeingestellt)
		{
			Script.zugewiesenenCounter++;
			checkeingestellt = true;
		}
		if (val == 0 && checkeingestellt)
		{
			Script.zugewiesenenCounter--;
			checkeingestellt = false;
		}
	}
}