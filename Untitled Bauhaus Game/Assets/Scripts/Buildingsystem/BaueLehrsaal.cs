using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueLehrsaal : MonoBehaviour
{
    public int AnzahlLehrsaal = 0;
    public int AktPreisL = 1000;

    public Text PreisL;

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
        //PreisL.text = "Lehrsaal: " + AktPreisL + " RM";
    }
    public void NeuerLehrsaal()
    {
        switch (AnzahlLehrsaal)
        {
            case 0:
                lehr1.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 1:
                lehr2.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 2:
                lehr3.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 3:
                lehr4.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 4:
                lehr5.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 5:
                lehr6.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 6:
                lehr7.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = AktPreisL * 2;
                break;
            case 7:
                lehr8.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisL);
                AktPreisL = int.MaxValue;
                break;
            default:
                break;
        }
    }
}
