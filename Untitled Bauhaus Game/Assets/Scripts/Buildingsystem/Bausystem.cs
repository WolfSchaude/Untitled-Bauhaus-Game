using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class BauZuEndeEvent : UnityEvent<int, int, int, int>
{ }

public class Bausystem : MonoBehaviour, ISaveableInterface
{
    public BauZuEndeEvent _BauZuEndeEvent;

    private Money ManipulateMoney;
    private Studenten ManipulateStudents;

    public FeedbackScript FeedbackFromBuildings;

    public GameObject SaveGameKeeper;

    /// <summary>
    /// All available structure prefabs/objects are saved in this list
    /// </summary>
    public List<GameObject> Structures = new List<GameObject>();

    public GameObject PipelinePrefab;
    public GameObject PipelineParent;

    public GameObject ConstructionWithParticle;

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
    public int MainTypeToBuild = 1;

    /// <summary>
    /// Variable to temporary save the used style of the future workshop
    /// </summary>
    public int StyleToBuild;

    public int NumberOfStructures;

    public int[] LowestMainTypeID;

    public string ActualCosts;
    public string ActualBuildTime;
    public string ActualCapacity;

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
        public int WholeTime { get; private set; }
        public bool IsSlotUsed { get; private set; }
        public int StyleID { get; private set; }

        public BuildingOrder() //When initialized, the set everything to zero
        {
            TypeToBuild = 0;
            MainTypeToBuild = 0;
            StyleToBuild = 0;
            TimeToBuild = 0;
            WholeTime = 0;
            IsSlotUsed = false;
        }
        public void SetBuilding(int ID, int type, int maintype, int style, int time) //Should be named SetPipeline or SetOrder, because it only sets the build order of the Player and the Pipeline itself to active
        {
            TypeToBuild = type;
            MainTypeToBuild = maintype;
            StyleToBuild = style;
            TimeToBuild = time;
            WholeTime = time;
            StyleID = ID;
            IsSlotUsed = true;
        }

        public void SetBuilding2(int wholetime, int ID, int type, int maintype, int style, int time)
        {
            TypeToBuild = type;
            MainTypeToBuild = maintype;
            StyleToBuild = style;
            TimeToBuild = time;
            WholeTime = wholetime;
            StyleID = ID;
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
        public int HighestNumberOfStrutures { get; private set; }

        public int[] StructureCount;

        public int[] MaxStructures { get; private set; } //Maximum amount of main type structures, which are supported by this build style

        public bool[,] StructuresOrder;

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
            HighestNumberOfStrutures = Temp;

            StructuresOrder = new bool[4, Temp];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Temp; j++)
                {
                    StructuresOrder[i, j] = true;
                }
            }

            StructureCapacity = new int[4, Temp];

            StructurePositions = new Vector3[4, Temp];

            StructureCost = new int[4, Temp];

            StructureBuildTime = new int[4, Temp];

        }
    }

    private BuildingStyle[] UsableStyles;

    void Awake()
    {
        if (_BauZuEndeEvent == null)
        {
           _BauZuEndeEvent = new BauZuEndeEvent();
        }

    }

    public void LoadStart()
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
        Structures.Add(GameObject.Find("Abteil_8"));
        #endregion

        Debug.Log("Building System: Structure objects loaded");

        NumberOfStructures = Structures.Count;

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
        Structures[17].GetComponent<Struktur>().OwnMainTypeInt = 0;

        Structures[0].GetComponent<Struktur>().TypeID = 6;
        Structures[1].GetComponent<Struktur>().TypeID = 5;
        Structures[2].GetComponent<Struktur>().TypeID = 4;
        Structures[3].GetComponent<Struktur>().TypeID = 3;
        Structures[4].GetComponent<Struktur>().TypeID = 2;
        Structures[5].GetComponent<Struktur>().TypeID = 1;
        Structures[6].GetComponent<Struktur>().TypeID = 0;
        Structures[7].GetComponent<Struktur>().TypeID = 0;
        Structures[8].GetComponent<Struktur>().TypeID = 0;
        Structures[9].GetComponent<Struktur>().TypeID = 1;
        Structures[10].GetComponent<Struktur>().TypeID = 2;
        Structures[11].GetComponent<Struktur>().TypeID = 1;
        Structures[12].GetComponent<Struktur>().TypeID = 2;
        Structures[13].GetComponent<Struktur>().TypeID = 3;
        Structures[14].GetComponent<Struktur>().TypeID = 4;
        Structures[15].GetComponent<Struktur>().TypeID = 5;
        Structures[16].GetComponent<Struktur>().TypeID = 6;
        Structures[17].GetComponent<Struktur>().TypeID = 0;

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].GetComponent<Struktur>().OwnContructionPrefab = Instantiate(ConstructionWithParticle);
            Structures[i].GetComponent<Struktur>().Bausystem = this.gameObject;
            Structures[i].GetComponent<Struktur>().SetContructionPrefab();
        }
        #endregion

        Debug.Log("Building System: Values of object scripts set");

        for (int i = 0; i < NumberOfStructures; i++)
        {
            Structures[i].SetActive(false);
        }
        Structures[17].SetActive(true);

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

        UsableStyles = new BuildingStyle[1] { new BuildingStyle() };

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

        LowestMainTypeID = new int[4];
        LowestMainTypeID[0] = 0;
        LowestMainTypeID[1] = 0;
        LowestMainTypeID[2] = 0;
        LowestMainTypeID[3] = 0;

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

    void Update()
    {
        if (CheatActive) {
            for (int i = 0; i < MaxBuildPipelines; i++)
            {
                BuildingPipeline[i].NoBuildTimeCheat();

                if (BuildingPipeline[i].CheckStatus())
                {
                    BuildStructure(i);
                    UsableStyles[BuildingPipeline[i].StyleToBuild].StructureCount[BuildingPipeline[i].MainTypeToBuild]++;
                    BuildingPipeline[i].SetZero();
                }
            }
        }

        //if (UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild] >= UsableStyles[StyleToBuild].MaxStructures[MainTypeToBuild])
        //{
        //    ActualBuildTime = "Max. Anzahl";
        //    ActualCapacity = "Max. Anzahl";
        //    ActualCosts = "Max. Anzahl";
        //}
        //else
        //{
        //    ActualBuildTime = UsableStyles[StyleToBuild].StructureBuildTime[MainTypeToBuild, LowestMainTypeID[MainTypeToBuild]].ToString() + " Tage";
        //    ActualCapacity = UsableStyles[StyleToBuild].StructureCapacity[MainTypeToBuild, LowestMainTypeID[MainTypeToBuild]].ToString() + " Studenten";
        //    ActualCosts = UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, LowestMainTypeID[MainTypeToBuild]].ToString() + " RM";
        //}
        ShowPipelines();
    }

    public void ManualUpdate()
    {
        int MaxNumberOfTypeStructures = UsableStyles[StyleToBuild].HighestNumberOfStrutures;
        int FreeID = int.MaxValue;
        bool StyleSupportsNextStructure = false;

        for (int i = 0; i < MaxNumberOfTypeStructures; i++)
        {
            if (UsableStyles[StyleToBuild].StructuresOrder[MainTypeToBuild, i] == true && i < UsableStyles[StyleToBuild].MaxStructures[MainTypeToBuild])
            {
                FreeID = i;
                StyleSupportsNextStructure = true;
                break;
            }
        }

        if (StyleSupportsNextStructure)
        {
            ActualBuildTime = UsableStyles[StyleToBuild].StructureBuildTime[MainTypeToBuild, FreeID].ToString();
            ActualCapacity = UsableStyles[StyleToBuild].StructureCapacity[MainTypeToBuild, FreeID].ToString();
            ActualCosts = UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, FreeID].ToString();
        }
        else
        {
            ActualBuildTime = "Max. Anzahl";
            ActualCapacity = "Max. Anzahl";
            ActualCosts = "Max. Anzahl";
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
        if (!CheatActive)
        {
            for (int i = 0; i < MaxBuildPipelines; i++)
            {
                if (BuildingPipeline[i].CheckStatus())
                {
                    BuildStructure(i);
                }
            }

            for (int i = 0; i < MaxBuildPipelines; i++)
            {
                Pipelines[i].GetComponentInChildren<Slider>().value = BuildingPipeline[i].CalculateProgress();
                Pipelines[i].GetComponentsInChildren<Text>()[2].text = (int)BuildingPipeline[i].CalculateProgress() + "%";
            }
        }
    }

    public void Werkstatt()
    {
        MainTypeToBuild = 1;
        TypeToBuild = 1;
        ManualUpdate();
    }

    public void Wohnheim()
    {
        MainTypeToBuild = 2;
        TypeToBuild = 6;
        ManualUpdate();
    }

    public void Lehrsaal()
    {
        MainTypeToBuild = 3;
        TypeToBuild = 7;
        ManualUpdate();
    }

    public void SetType(int Type)
    {
        TypeToBuild = Type + 1;
    }

    public void StartBuilding()
    {
        Debug.Log("Building System: Function StartBuilding called");
        bool FreePipelineFound = false;
        int FreePipelineNumber = 0;

        int NumberOfStructures = Structures.Count;
        int MaxNumberOfTypeStructures = UsableStyles[StyleToBuild].HighestNumberOfStrutures;
        int FreeID = int.MaxValue;

        bool StyleSupportsNextStructure = false;

        List<GameObject> PotentialFreeStructures = new List<GameObject>();

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == MainTypeToBuild && Structures[i].GetComponent<Struktur>().IsPlaced == false && Structures[i].GetComponent<Struktur>().IsInBuild == false)
            {
                PotentialFreeStructures.Add(Structures[i]);
            }
        }

        Debug.Log("Building System: Search for number of free structures completed");

        if (PotentialFreeStructures.Count == 0)
        {
            FeedbackFromBuildings.NewTick("Maximale Anzahl an " + (MainType)MainTypeToBuild + " gebaut");
            return;
        }

        for (int i = 0; i < MaxNumberOfTypeStructures; i++) //New
        {
            if (UsableStyles[StyleToBuild].StructuresOrder[MainTypeToBuild, i] == true && i < UsableStyles[StyleToBuild].MaxStructures[MainTypeToBuild])
            {
                StyleSupportsNextStructure = true;
                FreeID = i;
                break;
            }
        } //New

        Debug.Log("FreeID: " + FreeID);

        LowestMainTypeID[MainTypeToBuild] = FreeID;

        if (StyleSupportsNextStructure == false) //New
        {
            FeedbackFromBuildings.NewTick("Dieser Baustil unterstützt keine weiteren Gebäude vom Typ " + (Type)TypeToBuild);
            return;
        } //New

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
            FeedbackFromBuildings.NewTick("Du kannst gerade kein weiteres Gebäude in auftrag geben. Warte bis ein anderer Auftrag abgeschlossen wurde");
            return;
        }

        if (UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, LowestMainTypeID[MainTypeToBuild]] > ManipulateMoney.money)
        {
            FeedbackFromBuildings.NewTick("Nicht genug Geld um " + (Type)TypeToBuild + " zu bauen");
            return;
        }

        if (FreePipelineFound == true)
        {
            Type temp = (Type)TypeToBuild;

            FeedbackFromBuildings.NewTick(temp.ToString() + " in Auftrag gegeben. Kosten: " + UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, FreeID] + " RM");
           
            Debug.Log("Building System: Free pipeline found, ID: " + FreePipelineNumber);

            if (CheatActive)
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(FreeID ,TypeToBuild, MainTypeToBuild, 0, 0);
                ManipulateMoney.Bezahlen(UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, FreeID]);
                UsableStyles[StyleToBuild].StructuresOrder[MainTypeToBuild, FreeID] = false;
                BuildStructure(FreePipelineNumber);
                UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].StructureCount[BuildingPipeline[FreePipelineNumber].MainTypeToBuild]++;
                BuildingPipeline[FreePipelineNumber].SetZero();
                return;
            }
            else
            {
                BuildingPipeline[FreePipelineNumber].SetBuilding(FreeID, TypeToBuild, MainTypeToBuild, StyleToBuild, UsableStyles[StyleToBuild].StructureBuildTime[MainTypeToBuild, UsableStyles[StyleToBuild].StructureCount[MainTypeToBuild]]);
                ManipulateMoney.Bezahlen(UsableStyles[StyleToBuild].StructureCost[MainTypeToBuild, FreeID]);
                UsableStyles[StyleToBuild].StructuresOrder[MainTypeToBuild, FreeID] = false;
                UsableStyles[BuildingPipeline[FreePipelineNumber].StyleToBuild].StructureCount[BuildingPipeline[FreePipelineNumber].MainTypeToBuild]++;

                for (int i = 0; i < NumberOfStructures; i++)
                {
                    if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == MainTypeToBuild && Structures[i].GetComponent<Struktur>().TypeID == FreeID)
                    {
                        Structures[i].GetComponent<Struktur>().StartBuilding();
                        break;
                    }
                }
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

        Debug.Log("Building System: Set reference to object with lowest ID"); //\n environment.newline

        for (int i = 0; i < NumberOfStructures; i++) //New
        {
            if (!Structures[i].GetComponent<Struktur>().IsPlaced)
            {
                if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == BuildingPipeline[PipelineNumber].MainTypeToBuild && Structures[i].GetComponent<Struktur>().TypeID == BuildingPipeline[PipelineNumber].StyleID)
                {
                    Structures[i].SetActive(true);

                    Structures[i].GetComponent<Struktur>().SetStructure(BuildingPipeline[PipelineNumber].StyleToBuild, BuildingPipeline[PipelineNumber].MainTypeToBuild, BuildingPipeline[PipelineNumber].TypeToBuild, BuildingPipeline[PipelineNumber].StyleID);
                    Structures[i].GetComponent<Struktur>().InformCounter();

                    _BauZuEndeEvent.Invoke(i, BuildingPipeline[PipelineNumber].MainTypeToBuild, BuildingPipeline[PipelineNumber].TypeToBuild, BuildingPipeline[PipelineNumber].StyleID);

                    if (!CheatActive)
                    {
                        BuildingPipeline[PipelineNumber].SetZero();
                    }

                    Pipelines[PipelineNumber].SetActive(false);

                    FeedbackFromBuildings.NewTick(Structures[i].GetComponent<Struktur>().OwnTypeEnum.ToString() + " fertiggestellt. Die Studentenkapazität hat sich um 100 erhöht");

                    return;
                }
            }
        } 
        Debug.Log("Building System: Function BuildStructure ended");
    }

    public void StopBuilding(int PipelineNumber)
    {
        FeedbackFromBuildings.NewTick("Bau von " + (Type)BuildingPipeline[PipelineNumber].TypeToBuild + " abgebrochen");
        BuildingPipeline[PipelineNumber].SetZero();
        Pipelines[PipelineNumber].SetActive(false);
    }

    public void Save()
    {
        Debug.Log("Building System: Function Save called");

        int NumberOfStructures = Structures.Count;
        int NumberOfStyles = UsableStyles.Length;

        int[,] ActiveBuilding = new int[NumberOfStructures, 5];
        int[,] StructuresInBuild = new int[MaxBuildPipelines, 7];

        int HighestNumberOfStructuresOverStyles = 0;

        for (int i = 0; i < NumberOfStyles; i++)
        {
            if (HighestNumberOfStructuresOverStyles < UsableStyles[i].HighestNumberOfStrutures)
            {
                HighestNumberOfStructuresOverStyles = UsableStyles[i].HighestNumberOfStrutures;
            }
        }

        bool[,,] StyleOrder = new bool[NumberOfStyles, 4, HighestNumberOfStructuresOverStyles];

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
            ActiveBuilding[i, 4] = Structures[i].GetComponent<Struktur>().OwnStyleMainTypeID;
        }

        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.ActiveBuildings = ActiveBuilding;

        Debug.Log("Building System: Active buildings and values saved");

        for (int h = 0; h < UsableStyles.Length; h++)
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j < UsableStyles[h].HighestNumberOfStrutures; j++)
                {
                    StyleOrder[h, i, j] = UsableStyles[h].StructuresOrder[i, j];
                }
            }
        }

        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.StyleOrder = StyleOrder;

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
            StructuresInBuild[i, 5] = BuildingPipeline[i].WholeTime;
            StructuresInBuild[i, 6] = BuildingPipeline[i].StyleID;
        }

        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.StructuresInBuild = StructuresInBuild;

        Debug.Log("Building System: Active build pipelines saved");

        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[6] = true;

        Debug.Log("Building System: Inform SaveGameManager, building system saved");
        Debug.Log("Building System: Fucntion Save ended");
    }

    public void Load(Save save)
    {
        Debug.Log("Building System: Function Load called");

        int NumberOfStructures = save.ActiveBuildings.GetLength(0);
        int NumberOfStyles = save.StyleOrder.GetLength(0);
        int NumberOfMaximalStructuresOnStyles = save.StyleOrder.GetLength(1);

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (save.ActiveBuildings[i, 0] == 1)
            {
                Structures[i].SetActive(true);
                Structures[i].GetComponent<Struktur>().SetStructure(save.ActiveBuildings[i, 1], save.ActiveBuildings[i, 2], save.ActiveBuildings[i, 3], save.ActiveBuildings[i, 4]);
                Structures[i].GetComponent<Struktur>().InformCounter();

                StructuresCounter[Structures[i].GetComponent<Struktur>().OwnMainTypeInt]++;
            }
        }

        Debug.Log("Building System: Active structures loaded");

        for (int h = 0; h < NumberOfStyles; h++)
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j < NumberOfMaximalStructuresOnStyles; j++)
                {
                    UsableStyles[h].StructuresOrder[i, j] = save.StyleOrder[h, i, j];
                }
            }
        }

        Debug.Log("Building System: Style counter set");

        for (int i = 0; i < MaxBuildPipelines; i++)
        {
            if (save.StructuresInBuild[i, 0] == 1)
            {
                BuildingPipeline[i].SetBuilding2(save.StructuresInBuild[i,5] ,save.StructuresInBuild[i, 6] ,save.StructuresInBuild[i, 4], save.StructuresInBuild[i, 3], save.StructuresInBuild[i, 2], save.StructuresInBuild[i, 1]);
                Pipelines[i].SetActive(true);
                Pipelines[i].GetComponentsInChildren<Text>()[0].text = ((Type)TypeToBuild).ToString();
                Pipelines[i].GetComponentInChildren<Slider>().value = BuildingPipeline[i].CalculateProgress();
                Pipelines[i].GetComponentsInChildren<Text>()[2].text = (int)BuildingPipeline[i].CalculateProgress() + "%";
                Pipelines[i].GetComponentInChildren<Button>().onClick.AddListener(() => StopBuilding(i));
            }

            if (!BuildingPipeline[i].IsSlotUsed)
            {
                BuildingPipeline[i].SetZero();
            }
        }

        Debug.Log("Building System: Pipelines load and UI pipelines activated");

        Debug.Log("Building System: Function Load ended");
    }

    //public string ActiveStructuresName()
    //{
    //    string Temp;
    //    int NumberOfStructures = Structures.Count;

    //    Temp = "Strukturen: \n";

    //    for (int i = 0; i < NumberOfStructures; i++)
    //    {
    //        if (Structures[i].GetComponent<Struktur>().IsPlaced)
    //        {
    //            switch (Structures[i].GetComponent<Struktur>().OwnMainTypeInt)
    //            {
    //                case 1:
    //                    Temp = Temp + (Type)Structures[i].GetComponent<Struktur>().OwnTypeInt + "(Werkstatt)\n";
    //                    break;
    //                case 2:
    //                    Temp = Temp + (Type)Structures[i].GetComponent<Struktur>().OwnTypeInt + "(Wohnheim)\n";
    //                    break;
    //                case 3:
    //                    Temp = Temp + (Type)Structures[i].GetComponent<Struktur>().OwnTypeInt + "(Lehrsaal)\n";
    //                    break;
    //            }
    //        }
    //    }
    //    return Temp;
    //}

    public int StructureTest(int NumberOfStructure)
    {
        if (!Structures[NumberOfStructure].GetComponent<Struktur>().IsPlaced)
        {
            return Structures[NumberOfStructure].GetComponent<Struktur>().OwnMainTypeInt;
        }
        else
        {
            return 0;
        }
    }

    public List<int> PlacedMainTypeStructures(int MainTypeToSearch)
    {
        List<int> TempUniqueID = new List<int>();

        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().IsPlaced)
            {
                if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == MainTypeToSearch)
                {
                    TempUniqueID.Add(i);
                }
            }
        }
        return TempUniqueID;
    }
    
    public void DestroyStructure(int MainType, int TypeID, int Style, int StyleID)
    {
        for (int i = 0; i < NumberOfStructures; i++)
        {
            if (Structures[i].GetComponent<Struktur>().OwnMainTypeInt == MainType && Structures[i].GetComponent<Struktur>().TypeID == TypeID)
            {
                UsableStyles[Style].StructuresOrder[MainType, StyleID] = true;
                UsableStyles[Style].StructureCount[MainType]--;
                Structures[i].SetActive(false);
            }
        }
    }
}