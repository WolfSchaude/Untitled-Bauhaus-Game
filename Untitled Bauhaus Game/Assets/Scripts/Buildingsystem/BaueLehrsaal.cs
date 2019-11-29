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

    void Start()
    {
        MaxQualitaet = 1.5f;
        MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
    }

    public void NeuerLehrsaal()
    {
        switch (AnzahlLehrsaal)
        {
            case 0:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr1.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 1:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr2.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 2:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr3.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 3:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr4.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 4:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr5.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 5:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr6.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 6:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr7.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            case 7:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                    lehr8.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = int.MaxValue;
                    MinQualität = 0.5f + (AnzahlLehrsaal * 0.05f);
                }
                break;
            default:
                break;
        }
    }
}
