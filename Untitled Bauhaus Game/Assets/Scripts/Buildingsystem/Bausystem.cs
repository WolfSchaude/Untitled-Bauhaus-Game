using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bausystem : MonoBehaviour
{
    private Money ManipulateMoney;
    private Studenten ManipulateStudents;

    public FeedbackScript FeedbackFromBuildings;

    public GameObject SaveGameKeeper;

    /// <summary>
    /// All available structure prefabs/objects are saved in this list
    /// </summary>
    private List<GameObject> Structures = new List<GameObject>();

    /// <summary>
    /// When no build time cheat active, then this bool is true
    /// </summary>
    public bool CheatActive;

    /// <summary>
    /// Maximum number of pipelines, that can be used in game
    /// </summary>
    public int MaxBuildPipelines;

    /// <summary>
    /// Variable to temporary save the type of the future workshop
    /// </summary>
    public int TypeToBuild;
    public enum Type { Undefiniert, Architekturwerkstatt, Ausstellungsgestaltung, Malerei, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };
    public Type OwnTypeEnum;

    /// <summary>
    /// Variable to temporary save the main type of the future workshop
    /// </summary>
    public int MainTypeToBuild;

    /// <summary>
    /// Variable to temporary save the used style of the future workshop
    /// </summary>
    public int StyleToBuild;

    public int AnzahlWerkstaette = 0;
    public int AnzahlLehrsaal = 0;
    public int AnzahlWohnheime = 0;

    /// <summary>
    /// Number of pipes as text to print on detailed build menue
    /// </summary>
    [SerializeField] private Text Bauarbeiter;

    internal class BuildingOrder //Build pipeline objects
    {
        public int TypeToBuild { get; private set; }
        public int MainTypeToBuild { get; private set; }
        public int StyleToBuild { get; private set; }
        public int TimeToBuild { get; private set; }
        public bool IsSlotUsed { get; private set; }

        public BuildingOrder() //When initialized, the set everything to zero
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            IsSlotUsed = false;
        }
        public void SetBuilding(int type, int maintype, int style, int time) //Should be named SetPipeline or SetOrder, because it only sets the build order of the Player and the Pipeline itself to active
        {
            TypeToBuild = type;
            MainTypeToBuild = maintype;
            StyleToBuild = style;
            TimeToBuild = time;
            IsSlotUsed = true;
        }

        public void SetZero() //As suggested, it resets the pipeline
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            IsSlotUsed = false;
        }

        public void NoBuildTimeCheat() //For cheat mode: sets the build time to 0 (implemented as function because of security reasons)
        {
            TimeToBuild = 0;
        }

        public bool CheckStatus() //Checks if the build order is ready to build (build time is zero)...
        {

            if (IsSlotUsed == true) //...but only if the pipeline is active
            {
                if (TimeToBuild > 0) //But if the build time is over zero...
                {
                    TimeToBuild--; //Then it actualise the time until the structure is builded
                    return false;
                }
                else
                {
                    return true; //It returns true if the build time is zero
                }
            }
            else
            {
                return false; //If the build pipeline is not active, then it returns false as "not ready to build"
            }
        }
    }

    /// <summary>
    /// Array which contains all build pipelines
    /// </summary>
    private BuildingOrder[] BuildingPipeline;

    internal class BuildingStyle //Build styles
    {
        public int Structure1Count; //Maximum amount of main type structures, which are supported by this build style
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

        public float[] Structure1Quality; //Quality is not used yet
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
        Debug.Log("Hi, im Bertram the debug log. I help you if something goes wrong :D");
        Debug.Log("Im finaly in Unity ^^");

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

        Debug.Log("Building System: Structure objects loaded");

        int NumberOfStructures = Structures.Count;

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].AddComponent<Struktur>();
            Structures[i].GetComponent<Struktur>().Initialise();
        }

        Debug.Log("Building System: Scripts attached");

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

        Debug.Log("Building System: Values of object scripts set");

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].SetActive(false);
        }

        Debug.Log("Building System: Set objects to inactive");

        MaxBuildPipelines = 3;

        BuildingPipeline = new BuildingOrder[MaxBuildPipelines];
        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            BuildingPipeline[i] = new BuildingOrder();
        }

        Debug.Log("Building System: Generate build pipeline");

        ManipulateMoney = gameObject.GetComponent<Money>();
        ManipulateStudents = gameObject.GetComponent<Studenten>();

        UsableStyles = new BuildingStyle[2] { new BuildingStyle(), new BuildingStyle() };

        Debug.Log("Building System: Generate building styles");

        UsableStyles[0].SetBuildingStyle(7, 3, 7);

        UsableStyles[0].Structure1Cost[0] = 2500;
        UsableStyles[0].Structure1Cost[1] = 2500;
        UsableStyles[0].Structure1Cost[2] = 2500;
        UsableStyles[0].Structure1Cost[3] = 2500;
        UsableStyles[0].Structure1Cost[4] = 2500;
        UsableStyles[0].Structure1Cost[5] = 2500;
        UsableStyles[0].Structure1Cost[6] = 2500;
        UsableStyles[0].Structure2Cost[0] = 2500;
        UsableStyles[0].Structure2Cost[1] = 2500;
        UsableStyles[0].Structure2Cost[2] = 2500;
        UsableStyles[0].Structure3Cost[0] = 2500;
        UsableStyles[0].Structure3Cost[1] = 2500;
        UsableStyles[0].Structure3Cost[2] = 2500;
        UsableStyles[0].Structure3Cost[3] = 2500;
        UsableStyles[0].Structure3Cost[4] = 2500;
        UsableStyles[0].Structure3Cost[5] = 2500;
        UsableStyles[0].Structure3Cost[6] = 2500;
        //UsableStyles[0].Structure1Positions[0] = new Vector3(10, 10, 10);

        Debug.Log("Building System: Values of building styles set");

        StyleToBuild = 0;

        Debug.Log("Building System: System ready to take off!");
        Debug.Log("Okay, that system is ready, i gonna drink some Byte Cola, have fun comrade :D");
    }

    public void ShowPipelines()
    {
        int ActivePipelines = MaxBuildPipelines;

        Debug.Log("Building System: Function CalculateFreePipeline called");

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].IsSlotUsed)
            {
                ActivePipelines--;
            }
        }
        Bauarbeiter.text = ActivePipelines + "/" + MaxBuildPipelines;

        Debug.Log("Building System: Function CalculateFreePipeline ended");
    }
    public void BuildTime()
    {
        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].CheckStatus() || CheatActive)
            {
                BuildStructure(i);
            }
        }
    }

    public void Architektur()
    {
        Debug.Log("Building System: Architektur selected");
        MainTypeToBuild = 1;
        TypeToBuild = 1;
    }

    public void Ausstellungsgestaltung()
    {
        Debug.Log("Building System: Ausstellungsgestaltung selected");
        MainTypeToBuild = 1;
        TypeToBuild = 2;
    }

    public void Malerei()
    {
        Debug.Log("Building System: Malerei selected");
        MainTypeToBuild = 1;
        TypeToBuild = 3;
    }

    public void Metallwerkstatt()
    {
        Debug.Log("Building System: Metallwerkstatt selected");
        MainTypeToBuild = 1;
        TypeToBuild = 4;
    }

    public void Tischlerei()
    {
        Debug.Log("Building System: Tischlerei selected");
        MainTypeToBuild = 1;
        TypeToBuild = 5;
    }

    public void Wohnheim()
    {
        Debug.Log("Building System: Wohnheim selected");
        MainTypeToBuild = 2;
        TypeToBuild = 6;
    }

    public void Lehrsaal()
    {
        Debug.Log("Building System: Lehrsaal selected");
        MainTypeToBuild = 3;
        TypeToBuild = 7;
    }

    public void StartBuilding()
    {
        Debug.Log("Building System: Function StartBuilding called");
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

        Debug.Log("Building System: Search for number of free structures completed");

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

        Debug.Log("Building System: Build style maximum number of main type structures checked");

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].IsSlotUsed == false)
            {
                FreePipelineFound = true;
                FreePipelineNumber = i;
                break;
            }
        }

        Debug.Log("Building System: Free pipeline searched");

        if (FreePipelineFound == false)
        {
            return;
        }

        if (FreePipelineFound == true)
        {
            Type temp = (Type)TypeToBuild;

            FeedbackFromBuildings.NewTick(temp.ToString() + " in Auftrag gegeben");

            if (!CheatActive)
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, 0, 60);
                Debug.Log("Building System: Free pipeline found, ID: " + FreePipelineNumber);
            }
            else
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, 0, 0);
                BuildStructure(FreePipelineNumber);
            }

            switch (BuildingPipeline[FreePipelineNumber].MainTypeToBuild)
            {
                case 1:
                    ManipulateMoney.Bezahlen(UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].Structure1Cost[UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].Structure1Count]);
                    break;
                case 2:
                    ManipulateMoney.Bezahlen(UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].Structure2Cost[UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].Structure2Count]);
                    break;
                case 3:
                    ManipulateMoney.Bezahlen(UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].Structure3Cost[UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].Structure3Count]);
                    break;
            }
        }

        Debug.Log("Building System: Function StartBuilding ended");
    }

    public void BuildStructure(int PipelineNumber)
    {
        Debug.Log("Building System: Function BuildStructure called");

        int NumberOfStructures = Structures.Count;

        List<GameObject> PotentialFreeStructures = new List<GameObject>();

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == BuildingPipeline[PipelineNumber].MainTypeToBuild && Structures[i].GetComponent<Struktur>().IsPlaced == false)
            {
                PotentialFreeStructures.Add(Structures[i]);
            }
        }

        Debug.Log("Building System: Search for number of free structures completed");

        if (PotentialFreeStructures.Count == 0)
        {
            BuildingPipeline[PipelineNumber].SetZero();
            return;
        }

        Debug.Log("Building System: Searched for incorrect build pipelines");


        int NumberOfPotentialFreeStructures = PotentialFreeStructures.Count;
        int LowestFreeID = int.MaxValue;

        for (int i = 0; i < NumberOfPotentialFreeStructures; i++)
        {
            if (PotentialFreeStructures[i].GetComponent<Struktur>().TypeID <= LowestFreeID)
            {
                LowestFreeID = PotentialFreeStructures[i].GetComponent<Struktur>().TypeID;
            }
        }

        Debug.Log("Building System: Searched lowest main type ID");

        int FreeStructure = 0;

        for (int i = 0; i < NumberOfPotentialFreeStructures; i++)
        {
            if (PotentialFreeStructures[i].GetComponent<Struktur>().TypeID == LowestFreeID)
            {
                FreeStructure = i;
                break;
            }
        }

        Debug.Log("Building System: Set reference to object with lowest ID");

        PotentialFreeStructures[FreeStructure].SetActive(true);

        PotentialFreeStructures[FreeStructure].GetComponent<Struktur>().SetStructure(BuildingPipeline[PipelineNumber].StyleToBuild, BuildingPipeline[PipelineNumber].MainTypeToBuild, BuildingPipeline[PipelineNumber].TypeToBuild);
        PotentialFreeStructures[FreeStructure].GetComponent<Struktur>().InformCounter();

        Debug.Log("Building System: Set structure and counter");

        switch (BuildingPipeline[PipelineNumber].MainTypeToBuild)
        {
            case 1:
                //PotentialFreeStructures[buffer].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count];
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure1Count++;
                AnzahlWerkstaette++;

                break;
            case 2:
                //PotentialFreeStructures[buffer].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count];
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure2Count++;
                AnzahlWohnheime++;
                break;
            case 3:
                //PotentialFreeStructures[buffer].transform.position = UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Positions[UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count];
                UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].Structure3Count++;
                AnzahlLehrsaal++;
                break;
        }

        Debug.Log("Building System: Used style actualised");

        BuildingPipeline[PipelineNumber].SetZero();

        Debug.Log("Building System: Used build pipeline reset");

        FeedbackFromBuildings.NewTick(PotentialFreeStructures[FreeStructure].GetComponent<Struktur>().OwnTypeEnum.ToString() + " fertiggestellt. Die Studentenkapazität hat sich um 100 erhöht");

        ManipulateStudents.studKapazitaet += 100;

        Debug.Log("Building System: Student capacity actualised");
        Debug.Log("Building System: Function BuildStructure ended");
    }

    public void Save()
    {
        Debug.Log("Building System: Function Save called");

        int NumberOfStructures = Structures.Count;
        int NumberOfStyles = UsableStyles.Length;

        int[,] ActiveBuilding = new int[NumberOfStructures, 4];
        int[,] StyleCounter = new int[NumberOfStyles, 3];
        int[,] StructuresInBuild = new int[MaxBuildPipelines, 5];

        Debug.Log("Building System: Save arrays initialized");

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

        Debug.Log("Building System: Active buildings and values saved");

        for (int i = 0; i < NumberOfStyles; i++)
        {
            StyleCounter[i, 0] = UsableStyles[i].Structure1Count;
            StyleCounter[i, 1] = UsableStyles[i].Structure2Count;
            StyleCounter[i, 2] = UsableStyles[i].Structure3Count;
        }

        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.StyleCounter = StyleCounter;

        Debug.Log("Building System: Style count saved");

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

        Debug.Log("Building System: Active build pipelines saved");

        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[6] = true;

        Debug.Log("Building System: Inform SaveGameManager, building system saved");
        Debug.Log("Building System: Fucntion Save ended");
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
                Structures[i].GetComponent<Struktur>().InformCounter();
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