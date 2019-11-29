using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueLehrsaal : MonoBehaviour
{
    public int AnzahlLehrsaal = 0;
	public int studKapazitätLehr = 200;
    public int AktPreisL = 1000;

    public GameObject lehr1;
    public GameObject lehr2;
    public GameObject lehr3;
    public GameObject lehr4;
    public GameObject lehr5;
    public GameObject lehr6;
    public GameObject lehr7;
    public GameObject lehr8;

    void Update()
    {

    }
    public void NeuerLehrsaal()
    {
        switch (AnzahlLehrsaal)
        {
            case 0:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr1.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                }
                break;
            case 1:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                    lehr2.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
				GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
				AktPreisL = AktPreisL * 2;
                break;
            case 2:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr3.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                }
                break;
            case 3:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr4.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                }
                break;
            case 4:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr5.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                }
                break;
            case 5:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr6.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                }
                break;
            case 6:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr7.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = AktPreisL * 2;
                }
                break;
            case 7:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisL)
                {
                    lehr8.SetActive(true);
                    AnzahlLehrsaal++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätLehr;
                    AktPreisL = int.MaxValue;
                }
                break;
            default:
                break;
        }
    }
}
