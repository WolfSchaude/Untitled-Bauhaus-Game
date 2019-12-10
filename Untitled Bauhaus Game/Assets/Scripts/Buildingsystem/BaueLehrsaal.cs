using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueLehrsaal : MonoBehaviour
{
    public int AnzahlLehrsaal = 0;
	public int studKapazitätLehr = 200;
    public int AktPreisL = 1000;
    public int lehrBuildTimeInMonths = 2;

    public float MinQualität;
    public float MaxQualitaet;
    private float Qualität;

    public GameObject lehr1;
    public GameObject lehr2;
    public GameObject lehr3;
    public GameObject lehr4;
    public GameObject lehr5;
    public GameObject lehr6;
    public GameObject lehr7;
    public GameObject lehr8;

    public bool buildInProgress = false;

    void Start()
    {
        MaxQualitaet = 1.5f;
        MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
    }

    void Update()
    {
        buildStructure();
    }

    public void checkMonth() //Wird bei Monatswechsel ausgeführt
    {
        if (buildInProgress)
        {
            lehrBuildTimeInMonths--;
        }
    }

    public void buildStructure() //Baut die Struktur, nachdem die Bauzeit abgelaufen ist.
    {
        if (buildInProgress && lehrBuildTimeInMonths == 0)
        {
            if (lehr7.activeSelf)
            {
                lehr8.SetActive(true);
            }
            if (lehr6.activeSelf)
            {
                lehr7.SetActive(true);
            }
            if (lehr5.activeSelf)
            {
                lehr6.SetActive(true);
            }
            if (lehr4.activeSelf)
            {
                lehr5.SetActive(true);
            }
            if (lehr3.activeSelf)
            {
                lehr4.SetActive(true);
            }
            if (lehr2.activeSelf)
            {
                lehr3.SetActive(true);
            }
            if (lehr1.activeSelf)
            {
                lehr2.SetActive(true);
            }
            lehr1.SetActive(true);

            GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
            MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);

            GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Der Lehrsaal wurde fertiggestellt!");
			GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr++;
			AnzahlLehrsaal++;
            lehrBuildTimeInMonths = 2;
            buildInProgress = false;
        }
    }

    public void NeuerLehrsaal()
    {
        if (!buildInProgress)
        {
            switch (AnzahlLehrsaal)
            {
                case 0:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr1.transform.position = new Vector3(1f, 3.15f, -8f);
                        lehr1.transform.localScale = new Vector3(3.75f, 5f, 4f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr1.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 1:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr2.transform.position = new Vector3(1f, 3.15f, 10.5f);
                        lehr2.transform.localScale = new Vector3(3.75f, 5f, 3f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr2.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 2:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr3.transform.position = new Vector3(1f, 3.15f, 14f);
                        lehr3.transform.localScale = new Vector3(3.75f, 5f, 4f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr3.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 3:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr4.transform.position = new Vector3(-2.5f, 3.15f, 12.5f);
                        lehr4.transform.localScale = new Vector3(3.25f, 5f, 7f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr4.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 4:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr5.transform.position = new Vector3(-7.1f, 3.15f, 11f);
                        lehr5.transform.localScale = new Vector3(6f, 5f, 4f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr5.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 5:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr6.transform.position = new Vector3(-6.6f, 3.15f, 14.5f);
                        lehr6.transform.localScale = new Vector3(5f, 5f, 3f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr6.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 6:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr7.transform.position = new Vector3(-11.1f, 3.15f, 14.5f);
                        lehr7.transform.localScale = new Vector3(4f, 5f, 3f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr7.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                case 7:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                        lehr8.transform.position = new Vector3(-11.6f, 3.15f, 11f);
                        lehr8.transform.localScale = new Vector3(3f, 5f, 4f);
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr8.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = AktPreisL * 2;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
