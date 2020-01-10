using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bausystem : MonoBehaviour
{
    public NewTimeKeeper TimeHandler;

    private List<GameObject> Structures;

    public Vector3[,,,] StructureData;

    private bool SomethingIsBuilded;

    public int NumberOfStyles;
    public int NumberOfBuildingTypes;
    public int NumberOfBuildingsPerType;
    public int TypeToBuild;

    private int DaysSinceStartedBuilding;

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

        NumberOfStyles = 2;
        NumberOfBuildingTypes = 3;
        NumberOfBuildingsPerType = 7;

        Vector3[,,,] StructureData = new Vector3[NumberOfStyles, NumberOfBuildingTypes, NumberOfBuildingsPerType, 2];

        DaysSinceStartedBuilding = 0;

        TypeToBuild = 0;
        SomethingIsBuilded = false;
    }


    void Update()
    {
        BuildTime();
    }

    private void BuildTime()
    {
        if (DaysSinceStartedBuilding < 60)
        {
            
        }
    }

    public void StartBuilding()
    {
        if (SomethingIsBuilded == true)
        {

        }
    }

    public void BuildStructure()
    {
        TypeToBuild = 0;
        SomethingIsBuilded = false;
    }
}
