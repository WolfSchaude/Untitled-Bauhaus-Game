using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuickAccesskeys : MonoBehaviour
{
    /// <summary>
    /// Event used for closing all windows, all Scripts opening a Window should subscribe to this
    /// </summary>
    public UnityEvent CloseAllWindows;
    /// <summary>
    /// Static UnityEvent to count up the number of opened Windows
    /// </summary>
    public static UnityEvent IOpenedAWindow;
    /// <summary>
    /// Statuc UnityEvent to count down the number of opened Windows
    /// </summary>
    public static UnityEvent IClosedAWindow;
    /// <summary>
    /// Saves the number of opened Windows
    /// </summary>
    [SerializeField] int NumberOfOpenedWindows = 0;

    /// <summary>
    /// Reference to: NewTimeKeeper-Script on Playervariables, necessary fpr changing TimeModes
    /// </summary>
    [SerializeField] NewTimeKeeper TimeKeeper;
    /// <summary>
    /// Reference to: PauseMenu-Script on UI, necessary for displaying the Pause-Menu on Escape press with no windows opened
    /// </summary>
    [SerializeField] PauseMenu Pausemenu;
    /// <summary>
    /// Reference to: AnimationsStarter-Script on Feedback-Scrollview (atm), necessary for collapsing the Tickerpanel
    /// </summary>
    [SerializeField] AnimationStarter FeedbackTicker;
    /// <summary>
    /// Reference to: Button of Create-Exponat-Funktion, needed to Start a new Expoante on A button click
    /// </summary>
    [SerializeField] Exponate ExponateStarter;
    /// <summary>
    /// Reference to: Button of Sidebar-Statistiken, needed to open / close the Statistics panel (Subject to changes as Statistics will need to improve
    /// </summary>
    [SerializeField] AnimationStarter Statistics;
    /// <summary>
    /// Reference to: Button on the Bottom, needed to open / close Baumenue
    /// </summary>
    [SerializeField] Button Baumenue;
    void Awake()
    {
        if (IOpenedAWindow == null)
        {
            IOpenedAWindow = new UnityEvent();
        }
        IOpenedAWindow.AddListener(CountUpWindows);

        if (IClosedAWindow == null)
        {
            IClosedAWindow = new UnityEvent();
        }
        IClosedAWindow.AddListener(CountDownWindows);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //Baumenue oeffnen
        {
            CloseAllWindows.Invoke();
            Baumenue.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E)) //Exponat herstellen
        {
            if (ExponateStarter.IsAllowedToMakeExpo)
            {
                ExponateStarter.StartExponat();
            }
        }
        if (Input.GetKeyDown(KeyCode.H)) //Buerogebaeude anzeigen / Statistiken //Hacky ATM
        {
            CloseAllWindows.Invoke();
            Statistics.ToggleOpened();
        }
        if (Input.GetKeyDown(KeyCode.T)) //Ticker oeffnen / schliessen
        {
            FeedbackTicker.ToggleOpened();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Tempo auf Pause
        {
            TimeKeeper.SetPause();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Tempo auf Normal
        {
            TimeKeeper.SetNormal();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Tempo auf Fast
        {
            TimeKeeper.SetFastforward();
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Pausieren oder Tempo durchschalten
        {
            TimeKeeper.CycleTimeModes();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //Alle Fenster schließen, wenn schon alle zu, dann Pause-Menü öffnen
        {
            if (NumberOfOpenedWindows != 0)
            {
                InvokeCloseAllWindows();
            }
            else if (NumberOfOpenedWindows == 0)
            {
                if (PauseMenu.GamePaused)
                {
                    Pausemenu.Resume();
                }
                else
                {
                    Pausemenu.Pause();
                }
            }
        }
    }

    /// <summary>
    /// Counts NumberOfOpenedWindows up
    /// </summary>
    public void CountUpWindows()
    {
        NumberOfOpenedWindows++;

        print("Number of Windows just got increased. Now : " + NumberOfOpenedWindows);
    }
    /// <summary>
    /// Counts NumberOfOpenedWindows down
    /// </summary>
    public void CountDownWindows()
    {
        NumberOfOpenedWindows--;
        if (NumberOfOpenedWindows < 0) NumberOfOpenedWindows = 0;

        print("Number of Windows just got decreased. Now : " + NumberOfOpenedWindows);
    }

    /// <summary>
    /// A small function for being able to invoke CloseAllWindows from a Button
    /// </summary>
    public void InvokeCloseAllWindows()
    {
        CloseAllWindows.Invoke();
        NumberOfOpenedWindows = 0;
        Kamera.FreeCameraMovement.Invoke();
    }
}
