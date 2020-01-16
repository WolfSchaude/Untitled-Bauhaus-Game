using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bausystem : MonoBehaviour
{
    private Money ManipulateMoney;
    private Studenten ManipulateStudents;

    public FeedbackScript FeedbackFromBuildings;

    public GameObject SaveGameKeeper;

    private List<GameObject> Structures = new List<GameObject>();

    public bool CheatActive;

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

        public void NoBuildTimeCheat()
        {
            TimeToBuild = 0;
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

        public int[] Structure1Cost;
        public int[] Structure2Cost;
        public int[] Structure3Cost;

        public float[] Structure1Quality;
        public float[] Structure2Quality;
        public float[] Structure3Quality;

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

            Structure1Cost = new int[MaxStructure1];
            Structure2Cost = new int[MaxStructure2];
            Structure3Cost = new int[MaxStructure3];
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
        UsableStyles[0].Structure1Cost[0] = 10000;
        //UsableStyles[0].Structure1Positions[0] = new Vector3(10, 10, 10);

        StyleToBuild = 0;
    }

    public void BuildTime()
    {
        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].CheckStatus())
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

        int NumberOfStructures = Structures.Count;

        List<GameObject> PotentialFreeStructures = new List<GameObject>();

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == MainTypeToBuild && Structures[i].GetComponent<Struktur>().IsPlaced == false)
            {
                PotentialFreeStructures.Add(Structures[i]);
            }
        }

        Debug.Log("PotentialFreeStructures: " + PotentialFreeStructures.Count);

        if (PotentialFreeStructures.Count == 0)
        {
            BuildingPipeline[FreePipelineNumber].SetZero();
            return;
        }

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
                Debug.Log("Free Pipeline found: " + FreePipelineFound + " " + FreePipelineNumber);
                break;
            }
        }
        
        if (FreePipelineFound == false)
        {
            return;
        }

        if (FreePipelineFound == true)
        {
            if (!CheatActive)
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, 0, 60);
            }
            else
            {
                Debug.Log("Fúnction Build Called");
                BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, 0, 0);
                BuildStructure(FreePipelineNumber);
            }
        }
    }

    public void BuildStructure(int PipelineNumber)
    {
        int NumberOfStructures = Structures.Count;

        List<GameObject> PotentialFreeStructures = new List<GameObject>();

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == BuildingPipeline[PipelineNumber].MainTypeToBuild && Structures[i].GetComponent<Struktur>().IsPlaced == false)
            {
                PotentialFreeStructures.Add(Structures[i]);
            }
        }

        Debug.Log("PotentialFreeStructures: " + PotentialFreeStructures.Count);

        if (PotentialFreeStructures.Count == 0)
        {
            BuildingPipeline[PipelineNumber].SetZero();
            return;
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

        int FreeStructure = 0;

        for (int i = 0; i < NumberOfPotentialFreeStructures; i++)
        {
            if (PotentialFreeStructures[i].GetComponent<Struktur>().TypeID == LowestFreeID)
            {
                FreeStructure = i;
                break;
            }
        }

        PotentialFreeStructures[FreeStructure].SetActive(true);

        PotentialFreeStructures[FreeStructure].GetComponent<Struktur>().SetStructure(BuildingPipeline[PipelineNumber].StyleToBuild, BuildingPipeline[PipelineNumber].MainTypeToBuild, BuildingPipeline[PipelineNumber].TypeToBuild);

        switch (BuildingPipeline[PipelineNumber].MainTypeToBuild)
        {
            case 1:
                //PotentialFreeStructures[buffer].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count];
                ManipulateMoney.Bezahlen(UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Cost[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count]);
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count++;
                break;
            case 2:
                //PotentialFreeStructures[buffer].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count];
                ManipulateMoney.Bezahlen(UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Cost[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count]);
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count++;
                break;
            case 3:
                //PotentialFreeStructures[buffer].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count];
                ManipulateMoney.Bezahlen(UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Cost[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count]);
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count++;
                break;
        }

        BuildingPipeline[PipelineNumber].SetZero();

        FeedbackFromBuildings.NewTick("Gebäude fertiggestellt. Die Studentenkapazität hat sich um 100 erhöht");

        ManipulateStudents.studKapazitaet += 100;
    }

    public void Save()
    {
        int NumberOfStructures = Structures.Count;
        int NumberOfStyles = UsableStyles.Length;

        int[,] ActiveBuilding = new int[NumberOfStructures, 4];
        int[,] StyleCounter = new int[NumberOfStyles, 3];
        int[,] StructuresInBuild = new int[MaxBuildPipelines, 5];

        for (int i = 0; i < NumberOfStructures; i++) 
        {
            if (Structures[i].activeSelf)
            {
                ActiveBuilding[i, 0] = 1;
            }

            if (!Structures[i].activeSelf)
            {
                ActiveBuilding[i, 0] = 0;
            }

            ActiveBuilding[i, 1] = Structures[i].GetComponent<Struktur>().OwnStyle;
            ActiveBuilding[i, 2] = Structures[i].GetComponent<Struktur>().OwnMainTypeInt;
            ActiveBuilding[i, 3] = Structures[i].GetComponent<Struktur>().OwnTypeInt;
        }

        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.ActiveBuildings = ActiveBuilding;

        for (int i = 0; i < NumberOfStyles; i++)
        {
            StyleCounter[i, 0] = UsableStyles[i].Structure1Count;
            StyleCounter[i, 1] = UsableStyles[i].Structure2Count;
            StyleCounter[i, 2] = UsableStyles[i].Structure3Count;
        }

        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.StyleCounter = StyleCounter;

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].IsSlotUsed)
            {
                StructuresInBuild[i, 0] = 1;
            }
            
            if (!BuildingPipeline[i].IsSlotUsed)
            {
                StructuresInBuild[i, 0] = 0;
            }

            StructuresInBuild[i, 1] = BuildingPipeline[i].TimeToBuild;
            StructuresInBuild[i, 2] = BuildingPipeline[i].StyleToBuild;
            StructuresInBuild[i, 3] = BuildingPipeline[i].MainTypeToBuild;
            StructuresInBuild[i, 4] = BuildingPipeline[i].TypeToBuild;
        }
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.StructuresInBuild = StructuresInBuild;

        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[6] = true;
    }

    public void Load(Save save)
    {
        int NumberOfStructures = save.ActiveBuildings.GetLength(0);
        int NumberOfStyles = 2;

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (save.ActiveBuildings[i, 0] == 1)
            {
                Structures[i].SetActive(true);
                Structures[i].GetComponent<Struktur>().SetStructure(save.ActiveBuildings[i, 1], save.ActiveBuildings[i, 2], save.ActiveBuildings[i, 3]);
            }
        }

        for (int i = 0; i < NumberOfStyles; i++)
        {
            UsableStyles[i].Structure1Count = save.StyleCounter[i, 0];
            UsableStyles[i].Structure2Count = save.StyleCounter[i, 1];
            UsableStyles[i].Structure3Count = save.StyleCounter[i, 2];
        }

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (save.StructuresInBuild[i, 0] == 1)
            {
                BuildingPipeline[i].SetBuilding(save.StructuresInBuild[i, 4], save.StructuresInBuild[i, 3], save.StructuresInBuild[i, 2], save.StructuresInBuild[i, 1]);
            }

            if (!BuildingPipeline[i].IsSlotUsed)
            {
                BuildingPipeline[i].SetZero();
            }
        }
    }
}