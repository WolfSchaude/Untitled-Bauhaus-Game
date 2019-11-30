using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWohnheim : MonoBehaviour
{
    public int AnzahlWohnheime = 0;
	public int studKapazitätWohn = 200;
	public int AktPreisW = 1000;
    public int wohnBuildTimeInMonths = 2;

    public float MinQualität;
    public float MaxQualitaet;
    private float Qualität;

    public GameObject heim1;
    public GameObject heim2;
    public GameObject heim3;

    public bool buildInProgress = false;

    void Start()
    {
        MaxQualitaet = 1.5f;
        MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);
    }

    void Update()
    {
        buildStructure();
    }

    public void checkMonth() //Wird bei Monatswechsel ausgeführt
    {
        if (buildInProgress)
        {
            wohnBuildTimeInMonths--;
        }
    }

    public void buildStructure() //Baut die Struktur, nachdem die Bauzeit abgelaufen ist.
    {
        if (buildInProgress && wohnBuildTimeInMonths == 0)
        {
            if (heim1.activeSelf && heim2.activeSelf)
            {
                heim3.SetActive(true);
            }
            if (heim1.activeSelf)
            {
                heim2.SetActive(true);
            }
            heim1.SetActive(true);

            GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
            GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
            MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);

            AnzahlWohnheime++;
            wohnBuildTimeInMonths = 2;
            buildInProgress = false;
        }
    }

    public void NeuesWohnheim()
    {
        if (!buildInProgress)
        {
            switch (AnzahlWohnheime)
            {
                case 0:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWohnheime * 0.05f), 1.5f);
                        buildInProgress = true;
                        //heim1.SetActive(true);
                        //AnzahlWohnheime++;
                        AktPreisW = AktPreisW * 2;
                    }
                    break;
                case 1:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWohnheime * 0.05f), 1.5f);
                        buildInProgress = true;
                        //heim2.SetActive(true);
                        //AnzahlWohnheime++;
                        AktPreisW = AktPreisW * 2;
                    }
                    break;
                case 2:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWohnheime * 0.05f), 1.5f);
                        buildInProgress = true;
                        //heim3.SetActive(true);
                        //AnzahlWohnheime++;
                        AktPreisW = int.MaxValue;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
