using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ExponatSellEvent : UnityEvent<int>
{
}

public class Exponate : MonoBehaviour
{
    public static ExponatSellEvent _ExponatSellEvent;

    public int BisherVerkauftAnzahl { get; private set; }
    public int BisherGebautErloes { get; private set; }

    public GameObject Playervariables;
    public GameObject StartOrderButton;
    public GameObject EventSystem;

    NewTimeKeeper TimeIsImportant;
    [SerializeField] TeacherScript NumberOfHiredTeachers;

    [SerializeField] Button JaAbbrechen;
    [SerializeField] Button NeinNichtAbbrechen;
    [SerializeField] Button ExpoCreateButton;
    

    public UnityEvent exponatDone;
    public Slider expoSlider;
    public Text expoText;

    public List<float> exponatQualitaeten = new List<float>();
    public List<int> exponateStil = new List<int>();
    public int exponatCounter = 0;
    int exponatCreateTimer = -5000;
    private int textCooldown = 200;
    [SerializeField] private readonly int expoPrice = 7500; //Herstellungspreis

    private bool exponatInProgress;
    public static bool isExponatDone = false;


    //---------------------------------( Stuff to actually create an Exponat ) --------------------------------//

    /// <summary>
    /// Reference to: the TEacherscript to get the list of hired Teachers
    /// </summary>
    [SerializeField] TeacherScript _TeacherScript;
    /// <summary>
    /// Reference to: PreFab used to instantiante the new Exponat
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// Reference to: The Parent GameObject the new Exponat will be subordinated to
    /// </summary>
    public Transform parent; //ScrollView Content
    /// <summary>
    /// List to Save the GameObjects of the Exponates and to keep a reference to them
    /// </summary>
    [SerializeField] List<GameObject> Exponat = new List<GameObject>();

    /// <summary>
    /// Toggle to reference from QuickAcceskeys, if you can make an Exponate
    /// </summary>
    [SerializeField] public bool IsAllowedToMakeExpo { get; private set; }

    private void Awake()
    {
        if (_ExponatSellEvent ==  null)
        {
            _ExponatSellEvent = new ExponatSellEvent();
        }

        _ExponatSellEvent.AddListener((x) => { BisherGebautErloes += x; BisherVerkauftAnzahl++; });
    }

    void Start()
    {
        TimeIsImportant = Playervariables.GetComponent<NewTimeKeeper>();

        expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        expoSlider.minValue = exponatCreateTimer;
    }

    void Update()
    {
        expoSlider.value = exponatCreateTimer; //set slider value to int value

        CreateExponat();

        if (NumberOfHiredTeachers.zugewiesenenCounter == 0)
        {
            IsAllowedToMakeExpo = false;
        }
        else
        {
            IsAllowedToMakeExpo = true;
        }

        ExpoCreateButton.interactable = IsAllowedToMakeExpo;
    }

    public void StartExponat() //Herstellung mit Button
    {
        if (exponatInProgress)
        {
            TryToCancel();
        }
        else
        {
            if (Playervariables.GetComponent<Money>().money > expoPrice) //Exponate können nur hergestellt werden, wenn man das benötigte Geld dafür hat.
            {
                if (exponatCreateTimer == expoSlider.minValue)
                {
                    expoText.text = "Wird hergestellt...\n -Klicken zum abbrechen-";
                    Playervariables.GetComponent<Money>().Bezahlen(expoPrice);
                    exponatInProgress = true;
                }
            }
            else
            {
                Ticker.NewTick.Invoke("Du hast nicht genügend Geld um ein Exponat herzustellen");
            }
        }
    }

    public void CreateExponat()
    {
        if (exponatInProgress && (TimeIsImportant.Mode == NewTimeKeeper.TimeMode.Normal || TimeIsImportant.Mode == NewTimeKeeper.TimeMode.FastForward))
        {
            switch (TimeIsImportant.Mode)
            {
                case NewTimeKeeper.TimeMode.Pause:
                    break;
                case NewTimeKeeper.TimeMode.Normal:
                    exponatCreateTimer += (NumberOfHiredTeachers.zugewiesenenCounter);
                    break;
                case NewTimeKeeper.TimeMode.FastForward:
                    exponatCreateTimer += (NumberOfHiredTeachers.zugewiesenenCounter * 4);
                    break;
                default:
                    break;
            }

			if (exponatCreateTimer >= expoSlider.maxValue)
            {
                expoText.text = "Exponat hergestellt!";

				Ticker.NewTick.Invoke("Ein Exponat wurde dem Inventar hinzugefügt.");

                isExponatDone = true;
                exponatInProgress = false;

                exponatDone.Invoke();
            }
        }

        if (isExponatDone && !exponatInProgress) //set text to default after time is up.
        {
            textCooldown--;

			if (exponatCreateTimer != expoSlider.minValue)
			{
				if (TimeIsImportant.Mode == NewTimeKeeper.TimeMode.Normal)
				{
					exponatCreateTimer -= 2;
				}
				else if (TimeIsImportant.Mode == NewTimeKeeper.TimeMode.FastForward)
				{
					exponatCreateTimer -= 6;
				}
			}
			if (exponatCreateTimer < expoSlider.minValue)
			{
				exponatCreateTimer = (int)expoSlider.minValue;
			}
			if (exponatCreateTimer == expoSlider.minValue)
			{
				isExponatDone = false;
			}

            if (textCooldown <= 0)
            {
                expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
                textCooldown = 200;
            }
        }
    }

    public void AddToInventory() //Gebunden an Exponat Done Event
    {
        var x = Instantiate(prefab, parent);

        int images = Random.Range(1, 4);
        switch (images)
        {
            case 1:
                x.GetComponentsInChildren<Image>()[2].sprite = Resources.Load<Sprite>("Sprites/Exponat1");
                break;
            case 2:
                x.GetComponentsInChildren<Image>()[2].sprite = Resources.Load<Sprite>("Sprites/Exponat2");
                break;
            case 3:
                x.GetComponentsInChildren<Image>()[2].sprite = Resources.Load<Sprite>("Sprites/Exponat3");
                break;
        }
        int herstellerText = Random.Range(0, _TeacherScript._Teachers_Assigned.Count);

        x.GetComponentsInChildren<Text>()[1].text = "Hergestellt von:\n - " + _TeacherScript._Teachers_Assigned[herstellerText].Name;

        int stilText = _TeacherScript._Teachers_Assigned[herstellerText].Politik;


        if (stilText < 100)
        {
            x.GetComponentsInChildren<Text>()[2].text = "Stilrichtung: Links";
        }
        else if (stilText == 100)
        {
            x.GetComponentsInChildren<Text>()[2].text = "Stilrichtung: Neutral";
        }
        else if (stilText > 100)
        {
            x.GetComponentsInChildren<Text>()[2].text = "Stilrichtung: Rechts";
        }

        x.GetComponent<Exponat_Memory>().Politik = stilText;

        float Qualität = Random.Range(0.5f, 1.5f);
        x.GetComponentsInChildren<Text>()[3].text = "Qualität: " + Qualität.ToString("0.0");
        x.GetComponentInChildren<Exponat_Memory>().Qualitaet = Qualität;

        x.GetComponentInChildren<Button>().onClick.AddListener(() => { Destroy(x); });

        Exponat.Add(x);
        exponatQualitaeten.Add(Qualität);
        exponateStil.Add(stilText);
        exponatCounter++;

        Debug.Log("Exponate: " + exponatCounter);
    }

    #region Methods needed to do the cancel and cancel-check for exponates
    public void TryToCancel()
    {
        JaAbbrechen.gameObject.SetActive(true);
        NeinNichtAbbrechen.gameObject.SetActive(true);

        StartOrderButton.transform.localScale = Vector3.zero;
    }

    public void DontCancel()
    {
        JaAbbrechen.gameObject.SetActive(false);
        NeinNichtAbbrechen.gameObject.SetActive(false);

        StartOrderButton.transform.localScale = Vector3.one;
    }

    public void YesPleaseCancel()
    {
        CancelExponat();

        JaAbbrechen.gameObject.SetActive(false);
        NeinNichtAbbrechen.gameObject.SetActive(false);

        StartOrderButton.transform.localScale = Vector3.one;
    }

    public void CancelExponat()
    {
        if (exponatInProgress && !isExponatDone /*&& exponatCreateTimer >= -4970*/)
        {
            exponatInProgress = false;
            isExponatDone = false;
            exponatCreateTimer = -5000;
            Ticker.NewTick.Invoke("Exponat-Herstellung abgebrochen.");
            expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        }
    }
	#endregion
}
