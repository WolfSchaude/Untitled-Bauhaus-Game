using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bausystem : MonoBehaviour
{
    private Money ManipulateMoney;
    private Studenten ManipulateStudents;

    public FeedbackScript FeedbackFromBuildings;

    private List<GameObject> Structures = new List<GameObject>();

    private List<int> BuildedTypes = new List<int>();

    public Vector3[,,,] StructureData; //Baustil, Haupttyp, Anzahl pro Haupttyp, 0/1 Scale/Position

    [SerializeField] private bool SomethingIsBuilded;

    public int MaxBuildPipelines;
    public int TypeToBuild;
    public int MainTypeToBuild;
    public int StyleToBuild;

    internal class BuildingOrder
    {
        public int TypeToBuild { get; private set; }
        public int MainTypeToBuild { get; private set; }
        public int StyleToBuild { get; private set; }
        public int TimeToBuild { get; private set; }
        public bool IsSlotUsed { get; private set; }

        public BuildingOrder()
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            IsSlotUsed = false;
        }
        public void SetBuilding(int type, int maintype, int style, int time)
        {
            TypeToBuild = type;
            MainTypeToBuild = maintype;
            StyleToBuild = style;
            TimeToBuild = time;
            IsSlotUsed = true;
        }

        public void SetZero()
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            IsSlotUsed = false;
        }

        public bool CheckStatus()
        {
            if (IsSlotUsed == true)
            {
                if (TimeToBuild != 0)
                {
                    TimeToBuild--;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }

    private BuildingOrder[] BuildingPipeline;

    internal class BuildingStyle
    {
        public int Structure1Count;
        public int Structure2Count;
        public int Structure3Count;

        public int MaxStructure1 { get; private set; }
        public int MaxStructure2 { get; private set; }
        public int MaxStructure3 { get; private set; }

        public Vector3[] Structure1Positions;
        public Vector3[] Structure2Positions;
        public Vector3[] Structure3Positions;

        public BuildingStyle()
        {
            Structure1Count = 0;
            Structure2Count = 0;
            Structure3Count = 0;

            MaxStructure1 = 0;
            MaxStructure2 = 0;
            MaxStructure3 = 0;
        }

        public void SetBuildingStyle(int MS1, int MS2, int MS3)
        {
            Structure1Count = 0;
            Structure2Count = 0;
            Structure3Count = 0;

            MaxStructure1 = MS1;
            MaxStructure2 = MS2;
            MaxStructure3 = MS3;

            Structure1Positions = new Vector3[MaxStructure1];
            Structure2Positions = new Vector3[MaxStructure2];
            Structure3Positions = new Vector3[MaxStructure3];
        }
    }

    private BuildingStyle[] UsableStyles;

    void Start()
    {
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

        int NumberOfStructures = Structures.Count;

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].AddComponent<Struktur>();
            Structures[i].GetComponent<Struktur>().Initialise();
        }

        Structures[0].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[1].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[2].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[3].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[4].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[5].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[6].GetComponent<Struktur>().OwnMainTypeInt = 3;
        Structures[7].GetComponent<Struktur>().OwnMainTypeInt = 1;
        Structures[8].GetComponent<Struktur>().OwnMainTypeInt = 2;
        Structures[9].GetComponent<Struktur>().OwnMainTypeInt = 2;
        Structures[10].GetComponent<Struktur>().OwnMainTypeInt = 2;
        Structures[11].GetComponent<Struktur>().OwnMainTypeInt = 1;
        Structures[12].GetComponent<Struktur>().OwnMainTypeInt = 1;
        Structures[13].GetComponent<Struktur>().OwnMainTypeInt = 1;
        Structures[14].GetComponent<Struktur>().OwnMainTypeInt = 1;
        Structures[15].GetComponent<Struktur>().OwnMainTypeInt = 1;
        Structures[16].GetComponent<Struktur>().OwnMainTypeInt = 1;

        Structures[0].GetComponent<Struktur>().TypeID = 7;
        Structures[1].GetComponent<Struktur>().TypeID = 6;
        Structures[2].GetComponent<Struktur>().TypeID = 5;
        Structures[3].GetComponent<Struktur>().TypeID = 4;
        Structures[4].GetComponent<Struktur>().TypeID = 3;
        Structures[5].GetComponent<Struktur>().TypeID = 2;
        Structures[6].GetComponent<Struktur>().TypeID = 1;
        Structures[7].GetComponent<Struktur>().TypeID = 1;
        Structures[8].GetComponent<Struktur>().TypeID = 1;
        Structures[9].GetComponent<Struktur>().TypeID = 2;
        Structures[10].GetComponent<Struktur>().TypeID = 3;
        Structures[11].GetComponent<Struktur>().TypeID = 2;
        Structures[12].GetComponent<Struktur>().TypeID = 3;
        Structures[13].GetComponent<Struktur>().TypeID = 4;
        Structures[14].GetComponent<Struktur>().TypeID = 5;
        Structures[15].GetComponent<Struktur>().TypeID = 6;
        Structures[16].GetComponent<Struktur>().TypeID = 7;

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].SetActive(false);
        }

        MaxBuildPipelines = 3;

        BuildingPipeline = new BuildingOrder[MaxBuildPipelines];
        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            BuildingPipeline[i] = new BuildingOrder();
        }

        ManipulateMoney = gameObject.GetComponent<Money>();
        ManipulateStudents = gameObject.GetComponent<Studenten>();

        UsableStyles = new BuildingStyle[2] { new BuildingStyle(), new BuildingStyle() };
        
        UsableStyles[0].SetBuildingStyle(7, 3, 7);

        StyleToBuild = 0;
    }

    public void BuildTime()
    {
        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].CheckStatus() == true)
            {
                BuildStructure(i);
            }
        }
    }

    public void Architektur()
    {
        MainTypeToBuild = 1;
        TypeToBuild = 1;
    }

    public void Ausstellungsgestaltung()
    {
        MainTypeToBuild = 1;
        TypeToBuild = 2;
    }

    public void Malerei()
    {
        MainTypeToBuild = 1;
        TypeToBuild = 3;
    }

    public void Metallwerkstatt()
    {
        MainTypeToBuild = 1;
        TypeToBuild = 4;
    }

    public void Tischlerei()
    {
        MainTypeToBuild = 1;
        TypeToBuild = 5;
    }

    public void Wohnheim()
    {
        MainTypeToBuild = 2;
        TypeToBuild = 6;
    }

    public void Lehrsaal()
    {
        MainTypeToBuild = 3;
        TypeToBuild = 7;
    }

    public void StartBuilding()
    {
        bool FreePipelineFound = false;
        int FreePipelineNumber = 0;

        if (UsableStyles[StyleToBuild].Structure1Count > UsableStyles[StyleToBuild].MaxStructure1 && MainTypeToBuild == 1)
        {
            return;
        }

        if (UsableStyles[StyleToBuild].Structure2Count > UsableStyles[StyleToBuild].MaxStructure2 && MainTypeToBuild == 2)
        {
            return;
        }

        if (UsableStyles[StyleToBuild].Structure3Count > UsableStyles[StyleToBuild].MaxStructure3 && MainTypeToBuild == 3)
        {
            return;
        }

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].IsSlotUsed == false)
            {
                FreePipelineFound = true;
                FreePipelineNumber = i;
                break;
            }
        }

        if (FreePipelineFound == false)
        {
            return;
        }

        if (FreePipelineFound == true)
        {
            BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, 0, 60);
        }

        Debug.Log(TypeToBuild + " " + MainTypeToBuild + " " + FreePipelineNumber);
    }

    public void BuildStructure(int PipelineNumber)
    {
        Debug.Log("Building...");

        int NumberOfStructures = Structures.Count;

        List<GameObject> PotentialFreeStructures = new List<GameObject>();

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == BuildingPipeline[PipelineNumber].MainTypeToBuild && Structures[i].GetComponent<Struktur>().IsPlaced == false)
            {
                PotentialFreeStructures.Add(Structures[i]);
            }
        }

        int NumberOfPotentialFreeStructures = PotentialFreeStructures.Count;
        int LowestFreeID = int.MaxValue;

        for (int i = 0; i < NumberOfPotentialFreeStructures; i++)
        {
            if (PotentialFreeStructures[i].GetComponent<Struktur>().TypeID <= LowestFreeID)
            {
                LowestFreeID = PotentialFreeStructures[i].GetComponent<Struktur>().TypeID;
            }
        }

        GameObject LowestFreeStructure = new GameObject();

        for (int i = 0; i < NumberOfPotentialFreeStructures; i++)
        {
            if (PotentialFreeStructures[i].GetComponent<Struktur>().TypeID == LowestFreeID)
            {
                LowestFreeStructure = PotentialFreeStructures[i];
                break;
            }
        }

        LowestFreeStructure.SetActive(true);
        LowestFreeStructure.GetComponent<Struktur>().SetStructure(BuildingPipeline[PipelineNumber].MainTypeToBuild, BuildingPipeline[PipelineNumber].TypeToBuild);

        switch (BuildingPipeline[PipelineNumber].MainTypeToBuild)
        {
            case 1:
                //Structures[i].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count];
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count++;
                break;
            case 2:
                // Structures[i].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count];
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count++;
                break;
            case 3:
                //Structures[i].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count];
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count++;
                break;
        }

        BuildingPipeline[PipelineNumber].SetZero();

        TypeToBuild = 0;
        MainTypeToBuild = 0;

        FeedbackFromBuildings.NewTick("Gebäude fertiggestellt. Die Studentenkapazität hat sich um 100 erhöht");

        ManipulateStudents.studKapazitaet += 100;
    }
}