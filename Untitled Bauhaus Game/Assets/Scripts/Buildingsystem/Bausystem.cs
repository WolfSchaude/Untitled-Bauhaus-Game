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

    public GameObject PipelinePrefab;
    public GameObject PipelineParent;

    public List<GameObject> Pipelines = new List<GameObject>();

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
    public enum MainType { Undefiniert, Werkstätten, Wohnheime, Lehrsäle };

    /// <summary>
    /// Variable to temporary save the main type of the future workshop
    /// </summary>
    public int MainTypeToBuild;

    /// <summary>
    /// Variable to temporary save the used style of the future workshop
    /// </summary>
    public int StyleToBuild;

    public int ActualCosts;
    public int ActualBuildTime;
    public int ActualCapacity;

    public int[] StructuresCounter;

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
        private int WholeTime;
        public bool IsSlotUsed { get; private set; }

        public BuildingOrder() //When initialized, the set everything to zero
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            WholeTime = 0;
            IsSlotUsed = false;
        }
        public void SetBuilding(int type, int maintype, int style, int time) //Should be named SetPipeline or SetOrder, because it only sets the build order of the Player and the Pipeline itself to active
        {
            TypeToBuild = type;
            MainTypeToBuild = maintype;
            StyleToBuild = style;
            TimeToBuild = time;
            WholeTime = time;
            IsSlotUsed = true;
        }

        public void SetZero() //As suggested, it resets the pipeline
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            WholeTime = 0;
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

        public float CalculateProgress()
        {
            if ((WholeTime - TimeToBuild) == 0)
            {
                return 0;
            }
            else
            {
                return Mathf.Round((float)(WholeTime - TimeToBuild) / WholeTime * 100f);
            }

            //(WholeTime - TimeToBuild) == 0 ? return 0 : return (WholeTime - TimeToBuild) / WholeTime;
        }
    }

    /// <summary>
    /// Array which contains all build pipelines
    /// </summary>
    private BuildingOrder[] BuildingPipeline;

    internal class BuildingStyle //Build styles
    {
        public int[] StructureCount; //Maximum amount of main type structures, which are supported by this build style

        public int[] MaxStructures { get; private set; }

        public Vector3[,] StructurePositions;

        public int[,] StructureCost;

        public int[,] StructureCapacity;

        public float[,] StructureQuality; //Quality is not used yet

        public int[,] StructureBuildTime;

        public BuildingStyle()
        {

        }

        public void SetBuildingStyle(int MS1, int MS2, int MS3)
        {
            MaxStructures = new int[4];

            MaxStructures[0] = 0;
            MaxStructures[1] = MS1;
            MaxStructures[2] = MS2;
            MaxStructures[3] = MS3;

            StructureCount = new int[4];
            StructureCount[0] = 0;
            StructureCount[1] = 0;
            StructureCount[2] = 0;
            StructureCount[3] = 0;

            int Temp = 0;

            for (int i = 0; i < MaxStructures.Length; i++)
            {
                if (Temp < MaxStructures[i])
                {
                    Temp = MaxStructures[i];
                }
            }

            StructureCapacity = new int[4, Temp];

            StructurePositions = new Vector3[4, Temp];

            StructureCost = new int[4, Temp];

            StructureBuildTime = new int[4, Temp];

        }
    }

    private BuildingStyle[] UsableStyles;

    void Start()
    {
        Debug.Log("Hi, im Bertram the debug log. I help you if something goes wrong :D");
        Debug.Log("Im finally in Unity ^^");

        #region FindStructures
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
        #endregion

        Debug.Log("Building System: Structure objects loaded");

        int NumberOfStructures = Structures.Count;

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].AddComponent<Struktur>();
            Structures[i].GetComponent<Struktur>().Initialise();
        }

        Debug.Log("Building System: Scripts attached");

        #region StructuresInit
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
        #endregion

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


        #region Style0Init
        UsableStyles[0].StructureCapacity[3, 0] = 100;
        UsableStyles[0].StructureCapacity[3, 1] = 100;
        UsableStyles[0].StructureCapacity[3, 2] = 100;
        UsableStyles[0].StructureCapacity[3, 3] = 100;
        UsableStyles[0].StructureCapacity[3, 4] = 100;
        UsableStyles[0].StructureCapacity[3, 5] = 100;
        UsableStyles[0].StructureCapacity[3, 6] = 100;
        UsableStyles[0].StructureCapacity[2, 0] = 100;
        UsableStyles[0].StructureCapacity[2, 1] = 100;
        UsableStyles[0].StructureCapacity[2, 2] = 100;
        UsableStyles[0].StructureCapacity[1, 0] = 100;
        UsableStyles[0].StructureCapacity[1, 1] = 100;
        UsableStyles[0].StructureCapacity[1, 2] = 100;
        UsableStyles[0].StructureCapacity[1, 3] = 100;
        UsableStyles[0].StructureCapacity[1, 4] = 100;
        UsableStyles[0].StructureCapacity[1, 5] = 100;
        UsableStyles[0].StructureCapacity[1, 6] = 100;

        UsableStyles[0].StructureCost[3, 0] = 2500;
        UsableStyles[0].StructureCost[3, 1] = 3000;
        UsableStyles[0].StructureCost[3, 2] = 3500;
        UsableStyles[0].StructureCost[3, 3] = 4000;
        UsableStyles[0].StructureCost[3, 4] = 4500;
        UsableStyles[0].StructureCost[3, 5] = 5000;
        UsableStyles[0].StructureCost[3, 6] = 5500;
        UsableStyles[0].StructureCost[2, 0] = 2500;
        UsableStyles[0].StructureCost[2, 1] = 4000;
        UsableStyles[0].StructureCost[2, 2] = 5500;
        UsableStyles[0].StructureCost[1, 0] = 2500;
        UsableStyles[0].StructureCost[1, 1] = 3000;
        UsableStyles[0].StructureCost[1, 2] = 3500;
        UsableStyles[0].StructureCost[1, 3] = 4000;
        UsableStyles[0].StructureCost[1, 4] = 4500;
        UsableStyles[0].StructureCost[1, 5] = 5000;
        UsableStyles[0].StructureCost[1, 6] = 5500;

        UsableStyles[0].StructureBuildTime[3, 0] = 30;
        UsableStyles[0].StructureBuildTime[3, 1] = 35;
        UsableStyles[0].StructureBuildTime[3, 2] = 40;
        UsableStyles[0].StructureBuildTime[3, 3] = 45;
        UsableStyles[0].StructureBuildTime[3, 4] = 50;
        UsableStyles[0].StructureBuildTime[3, 5] = 55;
        UsableStyles[0].StructureBuildTime[3, 6] = 60;
        UsableStyles[0].StructureBuildTime[2, 0] = 30;
        UsableStyles[0].StructureBuildTime[2, 1] = 45;
        UsableStyles[0].StructureBuildTime[2, 2] = 60;
        UsableStyles[0].StructureBuildTime[1, 0] = 30;
        UsableStyles[0].StructureBuildTime[1, 1] = 35;
        UsableStyles[0].StructureBuildTime[1, 2] = 40;
        UsableStyles[0].StructureBuildTime[1, 3] = 45;
        UsableStyles[0].StructureBuildTime[1, 4] = 50;
        UsableStyles[0].StructureBuildTime[1, 5] = 55;
        UsableStyles[0].StructureBuildTime[1, 6] = 60;

        //UsableStyles[0].Structure1Positions[0] = new Vector3(10, 10, 10);
        #endregion

        Debug.Log("Building System: Values of building styles set");

        StyleToBuild = 0;

        StructuresCounter = new int[4];
        StructuresCounter[0] = 0;
        StructuresCounter[1] = 0;
        StructuresCounter[2] = 0;
        StructuresCounter[3] = 0;

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            Pipelines.Add(Instantiate(PipelinePrefab, PipelineParent.transform));
        }

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            Pipelines[i].SetActive(false);
        }

        Debug.Log("Building System: System ready to take off!");
        Debug.Log("Okay, that system is ready, i gonna drink some Byte Cola, have fun comrade :D");
    }

    private void Update()
    {
        if (CheatActive) {
            for (int i = 0; i < MaxBuildPipelines; i++)
            {
                BuildingPipeline[i].NoBuildTimeCheat();
            }
        }

        if (UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild] >= UsableStyles[StyleToBuild].MaxStructures[MainTypeToBuild])
        {
            ActualBuildTime = int.MaxValue;
            ActualCapacity = int.MaxValue;
            ActualCosts = int.MaxValue;
        }
        else
        {
            ActualBuildTime = UsableStyles[StyleToBuild].StructureBuildTime[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]];
            ActualCapacity = UsableStyles[StyleToBuild].StructureCapacity[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]];
            ActualCosts = UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]];
        }
        ShowPipelines();
    }

    public void ShowPipelines()
    {
        int ActivePipelines = MaxBuildPipelines;

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].IsSlotUsed)
            {
                ActivePipelines--;
            }
        }
        Bauarbeiter.text = "Bauarbeiter: " + ActivePipelines + "/" + MaxBuildPipelines;
    }

    public void BuildTime()
    {
        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (BuildingPipeline[i].CheckStatus() || (CheatActive && BuildingPipeline[i].CheckStatus()))
            {
                BuildStructure(i);
            }
        }

        int temp = Pipelines.Count;
        for (int i = 0; i < temp; i++)
        {
            Pipelines[i].GetComponentInChildren<Slider>().value = BuildingPipeline[i].CalculateProgress();
            Pipelines[i].GetComponentsInChildren<Text>()[2].text = (int)BuildingPipeline[i].CalculateProgress() + "%";
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
            FeedbackFromBuildings.NewTick("Maximale Anzahl an " + (MainType)MainTypeToBuild + " gebaut");
            BuildingPipeline[FreePipelineNumber].SetZero();
            return;
        }

        if (UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild] >= UsableStyles[StyleToBuild].MaxStructures[MainTypeToBuild])
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

        if (ActualCosts > ManipulateMoney.money)
        {
            FeedbackFromBuildings.NewTick("Nicht genug Geld um " + (Type)TypeToBuild + " zu bauen");
            return;
        }

        if (FreePipelineFound == true)
        {
            Type temp = (Type)TypeToBuild;

            FeedbackFromBuildings.NewTick(temp.ToString() + " in Auftrag gegeben. Kosten: " + UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]] + " RM");
           
            Debug.Log("Building System: Free pipeline found, ID: " + FreePipelineNumber);
            
            if (CheatActive)
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, 0, 0);
                ManipulateMoney.Bezahlen(UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]]);
                BuildStructure(FreePipelineNumber);
                UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].StructureCount[BuildingPipeline[FreePipelineNumber].MainTypeToBuild]++;
                BuildingPipeline[FreePipelineNumber].SetZero();
                return;
            }
            else
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(TypeToBuild, MainTypeToBuild, StyleToBuild, UsableStyles[StyleToBuild].StructureBuildTime[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]]);
                ManipulateMoney.Bezahlen(UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]]);
                UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].StructureCount[BuildingPipeline[FreePipelineNumber].MainTypeToBuild]++;
            }
            Pipelines[FreePipelineNumber].SetActive(true);
            Pipelines[FreePipelineNumber].GetComponentsInChildren<Text>()[0].text = ((Type)TypeToBuild).ToString();
            Pipelines[FreePipelineNumber].GetComponentsInChildren<Text>()[2].text = "0%";
            Pipelines[FreePipelineNumber].GetComponentInChildren<Button>().onClick.AddListener(() => StopBuilding(FreePipelineNumber));
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

        StructuresCounter[BuildingPipeline[PipelineNumber].MainTypeToBuild]++;

        Debug.Log("Building System: Used style actualised");

        ManipulateStudents.MehrKapazitaet(UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].StructureCapacity[BuildingPipeline[PipelineNumber].MainTypeToBuild, UsableStyles[BuildingPipeline[PipelineNumber].StyleToBuild].StructureCount[BuildingPipeline[PipelineNumber].MainTypeToBuild]]);

        Debug.Log("Building System: Student capacity actualised");

        if (!CheatActive)
        {
            BuildingPipeline[PipelineNumber].SetZero();
        }

        Debug.Log("Building System: Used build pipeline reset");

        FeedbackFromBuildings.NewTick(PotentialFreeStructures[FreeStructure].GetComponent<Struktur>().OwnTypeEnum.ToString() + " fertiggestellt. Die Studentenkapazität hat sich um 100 erhöht");

        Debug.Log("Building System: Function BuildStructure ended");
    }

    public void StopBuilding(int PipelineNumber)
    {
        BuildingPipeline[PipelineNumber].SetZero();
        Pipelines[PipelineNumber].SetActive(false);
    }

    public void Save()
    {
        Debug.Log("Building System: Function Save called");

        int NumberOfStructures = Structures.Count;
        int NumberOfStyles = UsableStyles.Length;

        int[,] ActiveBuilding = new int[NumberOfStructures, 4];
        int[,] StyleCounter = new int[NumberOfStyles, 4];
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
            StyleCounter[i, 1] = UsableStyles[i].StructureCount[1];
            StyleCounter[i, 2] = UsableStyles[i].StructureCount[2];
            StyleCounter[i, 3] = UsableStyles[i].StructureCount[3];
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

                StructuresCounter[Structures[i].GetComponent<Struktur>().OwnMainTypeInt]++;
            }
        }

        for (int i = 0; i < NumberOfStyles; i++)
        {
            UsableStyles[i].StructureCount[1] = save.StyleCounter[i, 1];
            UsableStyles[i].StructureCount[2] = save.StyleCounter[i, 2];
            UsableStyles[i].StructureCount[3] = save.StyleCounter[i, 3];
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