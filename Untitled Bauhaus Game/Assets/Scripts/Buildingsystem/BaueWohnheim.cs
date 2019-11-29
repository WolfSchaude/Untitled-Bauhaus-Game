using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWohnheim : MonoBehaviour
{
    public int AnzahlWohnheime = 0;
	public int studKapazitätWohn = 200;
	public int AktPreisW = 1000;

    public float MinQualität;
    public float MaxQualitaet;
    private float Qualität;

    public GameObject heim1;
    public GameObject heim2;
    public GameObject heim3;

    void Start()
    {
        MaxQualitaet = 1.5f;
        MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);
    }

    public void NeuesWohnheim()
    {
        switch (AnzahlWohnheime)
        {
            case 0:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWohnheime * 0.05f), 1.5f);
                    heim1.SetActive(true);
                    AnzahlWohnheime++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
                    AktPreisW = AktPreisW * 2;
                    MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);
                }
				break;
            case 1:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWohnheime * 0.05f), 1.5f);
                    heim2.SetActive(true);
                    AnzahlWohnheime++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
                    AktPreisW = AktPreisW * 2;
                    MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);
                }
                break;
            case 2:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWohnheime * 0.05f), 1.5f);
                    heim3.SetActive(true);
                    AnzahlWohnheime++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
                    AktPreisW = int.MaxValue;
                    MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);
                }
                break;
            default:
                break;
        }
    }
}
