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
    public int BauStil;

    public int[] BauStilePosnum = new int[2];

    public Vector3[,,] StilNum0Pos1Scal = new Vector3[2, 3, 2];

    public float MinQualität;
    public float MaxQualitaet;
    private float Qualität;

    public GameObject heim1;
    public GameObject heim2;
    public GameObject heim3;

    public bool buildInProgress = false;
	public bool teacherAssigned = false;

    void Start()
    {
        BauStilePosnum[0] = 0;
        BauStilePosnum[1] = 0;

        StilNum0Pos1Scal[0, 0, 0] = new Vector3(6.75f, 1.5f, -7.5f);
        StilNum0Pos1Scal[0, 0, 1] = new Vector3(8f, 1.75f, 5f);

        StilNum0Pos1Scal[0, 1, 0] = new Vector3(12.75f, 2.4f, -6.5f);
        StilNum0Pos1Scal[0, 1, 1] = new Vector3(4f, 3.5f, 7f);

        StilNum0Pos1Scal[0, 2, 0] = new Vector3(12.75f, 5.6f, -6.5f);
        StilNum0Pos1Scal[0, 2, 0] = new Vector3(4f, 3.5f, 7f);

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
            switch (AnzahlWohnheime)
            {
                case 2:
                    heim3.SetActive(true);
                    break;

                case 1:
                    heim2.SetActive(true);
                    break;

                case 0:
                    heim1.SetActive(true);
                    break;
            }

            GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
            MinQualität = 0.5f + (AnzahlWohnheime * 0.05f);

            GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Das Wohnheim wurde fertiggestellt!");
			GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn++;
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
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                        //heim1.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //heim1.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                        //heim2.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //heim2.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                        //heim3.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //heim3.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
            BauStilePosnum[BauStil]++;
        }
    }
}
