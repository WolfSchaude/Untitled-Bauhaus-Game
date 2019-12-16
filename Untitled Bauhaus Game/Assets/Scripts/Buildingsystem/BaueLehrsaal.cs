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
    public int BauStil;

    public int[] BauStilePosnum = new int[2];

    public Vector3[,,] StilNum0Pos1Scal = new Vector3[2, 8, 2];

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
        BauStilePosnum[0] = 0;
        BauStilePosnum[1] = 0;

        StilNum0Pos1Scal[0, 0, 0] = new Vector3(1f, 3.15f, -8f);
        StilNum0Pos1Scal[0, 0, 1] = new Vector3(3.75f, 5f, 4f);

        StilNum0Pos1Scal[0, 1, 0] = new Vector3(1f, 3.15f, 10.5f);
        StilNum0Pos1Scal[0, 1, 1] = new Vector3(3.75f, 5f, 3f);

        StilNum0Pos1Scal[0, 2, 0] = new Vector3(1f, 3.15f, 14f);
        StilNum0Pos1Scal[0, 2, 1] = new Vector3(3.75f, 5f, 4f);

        StilNum0Pos1Scal[0, 3, 0] = new Vector3(-2.5f, 3.15f, 12.5f);
        StilNum0Pos1Scal[0, 3, 1] = new Vector3(3.25f, 5f, 7f);

        StilNum0Pos1Scal[0, 4, 0] = new Vector3(-7.1f, 3.15f, 11f);
        StilNum0Pos1Scal[0, 4, 1] = new Vector3(6f, 5f, 4f);

        StilNum0Pos1Scal[0, 5, 0] = new Vector3(-6.6f, 3.15f, 14.5f);
        StilNum0Pos1Scal[0, 5, 1] = new Vector3(5f, 5f, 3f);

        StilNum0Pos1Scal[0, 6, 0] = new Vector3(-11.1f, 3.15f, 14.5f);
        StilNum0Pos1Scal[0, 6, 1] = new Vector3(4f, 5f, 3f);

        StilNum0Pos1Scal[0, 7, 0] = new Vector3(-11.6f, 3.15f, 11f);
        StilNum0Pos1Scal[0, 7, 1] = new Vector3(4f, 5f, 3f);

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
            switch (AnzahlLehrsaal)
            {
                case 7:
                    lehr8.SetActive(true);
                    break;

                case 6:
                    lehr7.SetActive(true);
                    break;

                case 5:
                    lehr6.SetActive(true);
                    break;

                case 4:
                    lehr5.SetActive(true);
                    break;

                case 3:
                    lehr4.SetActive(true);
                    break;

                case 2:
                    lehr3.SetActive(true);
                    break;

                case 1:
                    lehr2.SetActive(true);
                    break;

                case 0:
                    lehr1.SetActive(true);
                    break;
            }

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
                        //lehr1.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr1.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                        //lehr2.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                       // lehr2.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                        //lehr3.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr3.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                       // lehr4.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr4.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                        //lehr5.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr5.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                       // lehr6.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr6.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                        //lehr7.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr7.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
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
                       // lehr8.transform.position = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 0];
                        //lehr8.transform.localScale = StilNum0Pos1Scal[BauStil, BauStilePosnum[BauStil], 1];
                        Qualität = Random.Range(0.5f + (AnzahlLehrsaal * 0.05f), 1.5f);
                        buildInProgress = true;
                        //lehr8.SetActive(true);
                        //AnzahlLehrsaal++;
                        AktPreisL = int.MaxValue;
                    }
                    break;
                default:
                    break;
            }
            BauStilePosnum[BauStil]++;
        }
    }
}
