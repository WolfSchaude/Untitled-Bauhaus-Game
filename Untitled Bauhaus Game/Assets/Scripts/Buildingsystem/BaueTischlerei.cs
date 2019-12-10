using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueTischlerei : MonoBehaviour
{
	public int studKapazitätTisch = 200;
	public int AktPreis = 1000;
	public int tischBuildTimeInMonths = 2;

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

	public bool buildInProgress = false;

	void Start()
	{
		MaxQualitaet = 1.5f;
		MinQualität = 0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f);
	}

	void Update()
	{
		buildStructure();
	}

	public void checkMonth() //Wird bei Monatswechsel ausgeführt
	{
		if (buildInProgress)
		{
			tischBuildTimeInMonths--;
		}
	}

	public void buildStructure() //Baut die Struktur, nachdem die Bauzeit abgelaufen ist.
	{
		if (buildInProgress && tischBuildTimeInMonths == 0)
		{
			switch (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette)
			{
				case 6:
					werk7.SetActive(true);
					werk7.GetComponent<Werkstatt>().SetType(5);
					break;
				case 5:
					werk6.SetActive(true);
					werk6.GetComponent<Werkstatt>().SetType(5);
					break;
				case 4:
					werk5.SetActive(true);
					werk5.GetComponent<Werkstatt>().SetType(5);
					break;
				case 3:
					werk4.SetActive(true);
					werk4.GetComponent<Werkstatt>().SetType(5);
					break;
				case 2:
					werk3.SetActive(true);
					werk3.GetComponent<Werkstatt>().SetType(5);
					break;
				case 1:
					werk2.SetActive(true);
					werk2.GetComponent<Werkstatt>().SetType(5);
					break;
				case 0:
					werk1.SetActive(true);
					werk1.GetComponent<Werkstatt>().SetType(5);
					break;
				default:
					break;
			}

			if (werk2.activeSelf) //wird erst ab werk2 ausgeführt
			{
				GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätTisch;
			}
			GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätTisch * (float)Qualität);
			MinQualität = 0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f);

            GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Die Tischlerei wurde fertiggestellt!");
			GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch++;
			GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette++;
			tischBuildTimeInMonths = 2;
			buildInProgress = false;
		}
	}

	public void NeueTischlerei()
	{
		if (!buildInProgress)
		{
			switch (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette)
			{
				case 0:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk1.transform.position = new Vector3(-2.5f, 3.15f, -6.25f);
						werk1.transform.localScale = new Vector3(3.5f, 5f, 6.5f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk1.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
					}
					break;
				case 1:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk2.transform.position = new Vector3(-7.25f, 3.15f, -4.5f);
						werk2.transform.localScale = new Vector3(6f, 5f, 3.5f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk2.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
					}
					break;
				case 2:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk3.transform.position = new Vector3(-7.25f, 3.15f, -8.125f);
						werk3.transform.localScale = new Vector3(6f, 5f, 3.75f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk3.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
					}
					break;
				case 3:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk4.transform.position = new Vector3(-7.25f, 3.15f, -11.75f);
						werk4.transform.localScale = new Vector3(6f, 5f, 3.5f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk4.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
					}
					break;
				case 4:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk5.transform.position = new Vector3(-7.25f, 3.15f, -15.25f);
						werk5.transform.localScale = new Vector3(6f, 5f, 3.5f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk5.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
					}
					break;
				case 5:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk6.transform.position = new Vector3(-7.25f, 3.15f, -18.75f);
						werk6.transform.localScale = new Vector3(6f, 5f, 3.5f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk6.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = AktPreis * 2;
					}
					break;
				case 6:
					if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
					{
						GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
						werk7.transform.position = new Vector3(-7.25f, 3.15f, -22.1f);
						werk7.transform.localScale = new Vector3(6f, 5f, 3.5f);
						Qualität = Random.Range(0.5f + (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette * 0.05f), 1.5f);
						buildInProgress = true;
						//werk7.SetActive(true);
						//AnzahlWerkstaette++;
						AktPreis = int.MaxValue;
					}
					break;
				default:
					break;
			}
		}
	}
}