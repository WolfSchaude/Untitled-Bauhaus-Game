using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bausystem : MonoBehaviour
{
    private Money ManipulateMoney;
    private Studenten ManipulateStudents;

    public FeedbackScript FeedbackFromBuildings;

    private List<GameObject> Structures;

    public Vector3[,,,] StructureData;

    [SerializeField] private bool SomethingIsBuilded;

    public int NumberOfStyles;
    public int NumberOfBuildingTypes;
    public int NumberOfBuildingsPerType;
    public int TypeToBuild;
    public int StyleToBuild;

    private int DaysSinceStartedBuilding;
    private int TypeToBuildInternal;
    private int StyleToBuildInternal;
    private int MainTypeToBuildInternal;

    public int[,] StructureCost;

    private int[] BuildedTypes;


    void Start()
    {
        List<GameObject> Structures = new List<GameObject>();

        Structures.Add(GameObject.Find("Abteil_1"));
        Structures.Add(GameObject.Find("Abteil_2"));
        Structures.Add(GameObject.Find("Abteil_3"));
        Structures.Add(GameObject.Find("Abteil_4"));
        Structures.Add(GameObject.Find("Abteil_5"));
        Structures.Add(GameObject.Find("Abteil_6"));
        Structures.Add(GameObject.Find("Abteil_7"));
        Structures.Add(GameObject.Find("Abteil_9"));
        Structures.Add(GameObject.Find("Abteil_10"));
        Structures.Add(GameObject.Find("Abteil_11"));
        Structures.Add(GameObject.Find("Abteil_12"));
        Structures.Add(GameObject.Find("Abteil_13"));
        Structures.Add(GameObject.Find("Abteil_14"));
        Structures.Add(GameObject.Find("Abteil_15"));
        Structures.Add(GameObject.Find("Abteil_16"));
        Structures.Add(GameObject.Find("Abteil_17"));
        Structures.Add(GameObject.Find("Abteil_18"));

        for (int i = 0; i < Structures.Count; i++)
        {
            Structures[i].AddComponent<Struktur>();
        }

        for (int i = 0; i <= 6; i++)
        {
            Structures[i].GetComponent<Struktur>().OwnMainTypeInt = 1;
        }

        for (int i = 9; i <= 11; i++)
        {
            Structures[i].GetComponent<Struktur>().OwnMainTypeInt = 2;
        }

        for (int i = 12; i <= 17; i++)
        {
            Structures[i].GetComponent<Struktur>().OwnMainTypeInt = 3;
        }

        NumberOfStyles = 2;
        NumberOfBuildingTypes = 3;
        NumberOfBuildingsPerType = 7;

        int[] BuildedTypes = new int[NumberOfBuildingTypes];

        Vector3[,,,] StructureData = new Vector3[NumberOfStyles, NumberOfBuildingTypes, NumberOfBuildingsPerType, 2];

        int[,] StructureCost = new int[NumberOfBuildingTypes, NumberOfBuildingsPerType];

        for(int i = 0; i < NumberOfBuildingTypes; i++)
        {
            for(int j = 0; j < NumberOfBuildingsPerType; j++)
            {
                StructureCost[i, j] = j * 1000;
            }
        }

        DaysSinceStartedBuilding = 0;

        TypeToBuild = 0;
        SomethingIsBuilded = false;

        ManipulateMoney = gameObject.GetComponent<Money>();
        ManipulateStudents = gameObject.GetComponent<Studenten>();
    }

    public void BuildTime()
    {
        if (SomethingIsBuilded == true)
        {

            if (DaysSinceStartedBuilding >= 60)
            {
                BuildStructure();
            }
            else
            {
                DaysSinceStartedBuilding++;
            }
        }
    }

    public void StartBuilding()
    {
        if (SomethingIsBuilded == false)
        {
            TypeToBuildInternal = TypeToBuild;
            StyleToBuildInternal = StyleToBuild;
            ManipulateMoney.Bezahlen(StructureCost[TypeToBuild, BuildedTypes[TypeToBuild]]);
            SomethingIsBuilded = true;
        }
    }

    public void BuildStructure()
    {
        if (TypeToBuildInternal >= 1 && TypeToBuildInternal <= 5)
        {
            MainTypeToBuildInternal = 1;
        }

        if (TypeToBuildInternal == 6)
        {
            MainTypeToBuildInternal = 2;
        }

        if (TypeToBuildInternal == 7)
        {
            MainTypeToBuildInternal = 3;
        }

        Structures[BuildedTypes[TypeToBuildInternal]].SetActive(true);
        Structures[BuildedTypes[TypeToBuildInternal]].transform.position = StructureData[StyleToBuildInternal, TypeToBuildInternal, BuildedTypes[TypeToBuildInternal], 0];
        Structures[BuildedTypes[TypeToBuildInternal]].transform.localScale = StructureData[StyleToBuildInternal, TypeToBuildInternal, BuildedTypes[TypeToBuildInternal], 1];

        TypeToBuildInternal = 0;
        SomethingIsBuilded = false;

        FeedbackFromBuildings.NewTick("Gebäude fertiggestellt. Die Studentenkapazität hat sich um 100 erhöht");

        ManipulateStudents.studKapazitaet += 100;
    }
}
