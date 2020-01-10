using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueArchitekturwerkstatt : MonoBehaviour
{
	public int AnzahlWerkstaette = 0;
	public int studKapazitätArch = 200;
	public int AktPreis = 1000;
	public int archBuildTimeInMonths = 2;
	public int BauStil;

	public int[] BauStilePosnum = new int[2]; 

	public Vector3[,,] StilNum0Pos1Scal = new Vector3[2,7,2];

	public float MinQualität;
	public float MaxQualitaet;
	private float Qualität;

	public GameObject werk1;
	public GameObject werk2;
	public GameObject werk3;
	public GameObject werk4;
	public GameObject werk5;
	public GameObject werk6;
	public GameObject werk7;

	public GameObject Playervariables;

	public bool buildInProgress = false;

	void Start()
	{
		BauStilePosnum[0] = 0;
		BauStilePosnum[1] = 0;

		StilNum0Pos1Scal[0, 0, 0] = new Vector3(-2.5f, 3.15f, -6.25f);
		StilNum0Pos1Scal[0, 0, 1] = new Vector3(3.5f, 5f, 6.5f);

		StilNum0Pos1Scal[0, 1, 0] = new Vector3(-7.25f, 3.15f, -4.5f);
		StilNum0Pos1Scal[0, 1, 1] = new Vector3(6f, 5f, 3.5f);

		StilNum0Pos1Scal[0, 2, 0] = new Vector3(-7.25f, 3.15f, -8.125f);
		StilNum0Pos1Scal[0, 2, 1] = new Vector3(6f, 5f, 3.75f);

		StilNum0Pos1Scal[0, 3, 0] = new Vector3(-7.25f, 3.15f, -11.75f);
		StilNum0Pos1Scal[0, 3, 1] = new Vector3(6f, 5f, 3.5f);

		StilNum0Pos1Scal[0, 4, 0] = new Vector3(-7.25f, 3.15f, -15.25f);
		StilNum0Pos1Scal[0, 4, 1] = new Vector3(6f, 5f, 3.5f);

		StilNum0Pos1Scal[0, 5, 0] = new Vector3(-7.25f, 3.15f, -18.75f);
		StilNum0Pos1Scal[0, 5, 1] = new Vector3(6f, 5f, 3.5f);

		StilNum0Pos1Scal[0, 6, 0] = new Vector3(-7.25f, 3.15f, -22.1f);
		StilNum0Pos1Scal[0, 6, 1] = new Vector3(6f, 5f, 3.5f);

		MaxQualitaet = 1.5f;
		MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);

		//Event_Memory.FindInActiveObjectByName("InsertNameHere");

	}

	void Update()
	{
		buildStructure();
	}

	public void checkMonth() //Wird bei Monatswechsel ausgeführt
	{
		if (buildInProgress)
		{
			archBuildTimeInMonths--;
		}
	}

	public void buildStructure() //Baut die Struktur, nachdem die Bauzeit abgelaufen ist.
	{
		if (buildInProgress && archBuildTimeInMonths == 0)
		{
			switch (AnzahlWerkstaette) {
				case 6:
					werk7.SetActive(true);
					werk7.GetComponent<Werkstatt>().SetType(1);
					break;
				case 5:
					werk6.SetActive(true);
					werk6.GetComponent<Werkstatt>().SetType(1);
					break;
				case 4:
					werk5.SetActive(true);
					werk5.GetComponent<Werkstatt>().SetType(1);
					break;
				case 3:
					werk4.SetActive(true);
					werk4.GetComponent<Werkstatt>().SetType(1);
					break;
				case 2:
					werk3.SetActive(true);
					werk3.GetComponent<Werkstatt>().SetType(1);
					break;
				case 1:
					werk2.SetActive(true);
					werk2.GetComponent<Werkstatt>().SetType(1);
					break;
				case 0:
					werk1.SetActive(true);
					werk1.GetComponent<Werkstatt>().SetType(1);
					break;
				default:
					break;
			}

			if (werk2.activeSelf) //wird erst ab werk2 ausgeführt
			{
				Playervariables.GetComponent<Studenten>().studKapazitaet += studKapazitätArch;
			}
			Playervariables.GetComponent<Studenten>().studKapazitaet += (int)((float)studKapazitätArch * (float)Qualität);
			MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);

            GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Die Architekturwerkstatt wurde fertiggestellt!");
            AnzahlWerkstaette++;
			GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur++;
			archBuildTimeInMonths = 2;
			buildInProgress = false;
		}
	}

	public void NeueArchitekturwerkstatt()
	{
		if (!buildInProgress)
		{
			if (Playervariables.GetComponent<Money>().money >= AktPreis)
			{
				switch (BauStilePosnum[BauStil])
				{
					case 0:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk1.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk1.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk1.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
						break;
					
					case 1:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk2.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk2.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk2.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
						break;
					
					case 2:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk3.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk3.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk3.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
						break;
					
					case 3:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk4.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk4.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk4.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
						break;
					
					case 4:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk5.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk5.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk5.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
						break;
					
					case 5:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk6.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk6.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk6.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
						break;
					
					case 6:
						Playervariables.GetComponent<Money>().Bezahlen(AktPreis);
						//werk7.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
						//werk7.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
						Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk7.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = int.MaxValue;
						break;
					
					default:
						break;
				}
				BauStilePosnum[BauStil]++;
			}
		}
	}

	public List<int> SaveBuildings()
	{
		List<int> SaveBuildingsList = new List<int>();

		SaveBuildingsList.Add(werk1.GetComponent<Werkstatt>().WerkstattTypInt);
		SaveBuildingsList.Add(werk2.GetComponent<Werkstatt>().WerkstattTypInt);
		SaveBuildingsList.Add(werk3.GetComponent<Werkstatt>().WerkstattTypInt);
		SaveBuildingsList.Add(werk4.GetComponent<Werkstatt>().WerkstattTypInt);
		SaveBuildingsList.Add(werk5.GetComponent<Werkstatt>().WerkstattTypInt);
		SaveBuildingsList.Add(werk6.GetComponent<Werkstatt>().WerkstattTypInt);
		SaveBuildingsList.Add(werk7.GetComponent<Werkstatt>().WerkstattTypInt);

		GameObject.Find("UI").GetComponent<BaueWohnheim>().SaveBuildings(SaveBuildingsList);
		GameObject.Find("UI").GetComponent<BaueLehrsaal>().SaveBuildings(SaveBuildingsList);


		return SaveBuildingsList;
	}

	public bool LoadBuildings(List<int> LoadBuildingsList)
	{
		GameObject Temp = new GameObject();

		for (int i = 0; i < LoadBuildingsList.Count; i++)
		{
			switch (i)
			{
				case 0:
					Temp = werk1;
					break;
				case 1:
					Temp = werk2;
					break;
				case 2:
					Temp = werk3;
					break;
				case 3:
					Temp = werk4;
					break;
				case 4:
					Temp = werk5;
					break;
				case 5:
					Temp = werk6;
					break;
				case 6:
					Temp = werk7;
					break;
				case 7:
					Temp = GameObject.Find("UI").GetComponent<BaueWohnheim>().heim1;
					break;
				case 8:
					Temp = GameObject.Find("UI").GetComponent<BaueWohnheim>().heim2;
					break;
				case 9:
					Temp = GameObject.Find("UI").GetComponent<BaueWohnheim>().heim3;
					break;
				case 10:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr1;
					break;
				case 11:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr2;
					break;
				case 12:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr3;
					break;
				case 13:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr4;
					break;
				case 14:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr5;
					break;
				case 15:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr6;
					break;
				case 16:
					Temp = GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehr7;
					break;
				default:
					return false;
			}

			switch (LoadBuildingsList[i])
			{
				case 0:
					Temp.SetActive(false);
					break;
				case 1:
					Temp.GetComponent<Werkstatt>().WerkstattTypInt = 1;
					Temp.GetComponent<Werkstatt>().SetType(1);
					break;
				case 2:
					Temp.GetComponent<Werkstatt>().WerkstattTypInt = 2;
					Temp.GetComponent<Werkstatt>().SetType(2);
					break;
				case 3:
					Temp.GetComponent<Werkstatt>().WerkstattTypInt = 3;
					Temp.GetComponent<Werkstatt>().SetType(3);
					break;
				case 4:
					Temp.GetComponent<Werkstatt>().WerkstattTypInt = 4;
					Temp.GetComponent<Werkstatt>().SetType(4);
					break;
				case 5:
					Temp.GetComponent<Werkstatt>().WerkstattTypInt = 5;
					Temp.GetComponent<Werkstatt>().SetType(5);
					break;
				case 6:
					Temp.SetActive(true);
					break;
				case 7:
					Temp.SetActive(true);
					break;
			}
		}

		return true;
	}
}