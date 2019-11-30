using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWerkstatt : MonoBehaviour
{
    public int AnzahlWerkstaette = 0;
	public int studKapazitätWerk = 200;
	public int AktPreis = 1000;
    public int werkBuildTimeInMonths = 2;

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
        MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
    }

    void Update()
    {
        buildStructure();
    }

    public void checkMonth() //Wird bei Monatswechsel ausgeführt
    {
        if (buildInProgress)
        {
            werkBuildTimeInMonths--;
        }
    }

    public void buildStructure() //Baut die Struktur, nachdem die Bauzeit abgelaufen ist.
    {
        if (buildInProgress && werkBuildTimeInMonths == 0)
        {
            if (werk6.activeSelf)
            {
                werk7.SetActive(true);
            }
            if (werk5.activeSelf)
            {
                werk6.SetActive(true);
            }
            if (werk4.activeSelf)
            {
                werk5.SetActive(true);
            }
            if (werk3.activeSelf)
            {
                werk4.SetActive(true);
            }
            if (werk2.activeSelf)
            {
                werk3.SetActive(true);
            }
            if (werk1.activeSelf)
            {
                werk2.SetActive(true);
            }
            werk1.SetActive(true);

            GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
            if (werk2.activeSelf) //wird erst ab werk2 ausgeführt
            {
                GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
            }
            GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
            MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);

            AnzahlWerkstaette++;
            werkBuildTimeInMonths = 2;
            buildInProgress = false;
        }
    }

    public void NeueWerkstatt()
    {
        if (!buildInProgress)
        {
            switch (AnzahlWerkstaette)
            {
                case 0:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk1.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 1:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk2.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;

                    }
                    break;
                case 2:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk3.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 3:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk4.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 4:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk5.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 5:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk6.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 6:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
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
