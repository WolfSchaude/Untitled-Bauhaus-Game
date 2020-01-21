using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] FeedbackScript FeedbackTicker;
    /// <summary>
    /// Reference to: AnimationsStarter-Script on ExponateInventar, necessary for collapsing the Inventory
    /// </summary>
    [SerializeField] AnimationStarter ExponatInventory;
    /// <summary>
    /// Reference to: AnimationsStarter-Script on EventMenu-Scrollview, necessary for controlling the overview
    /// </summary>
    [SerializeField] AnimationStarter EventOverview;
    void Start()
    {
        if (IOpenedAWindow != null)
        {
            IOpenedAWindow.AddListener(() => {CountUpWindows(); });
        }
        else
        {
            IOpenedAWindow = new UnityEvent();
            IOpenedAWindow.AddListener(() => {CountUpWindows(); });
        }

        if (IClosedAWindow != null)
        {
            IClosedAWindow.AddListener(() => {CountDownWindows(); });
        }
        else
        {
            IClosedAWindow = new UnityEvent();
            IClosedAWindow.AddListener(() => {CountDownWindows(); });
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //Baumenue oeffnen
        {

        }
        if (Input.GetKeyDown(KeyCode.E)) //Exponat herstellen
        {

        }
        if (Input.GetKeyDown(KeyCode.H)) //Buerogebaeude anzeigen / Statistiken
        {

        }
        if (Input.GetKeyDown(KeyCode.I)) //Inventar oeffnen
        {
            if (NumberOfOpenedWindows > 0)
            {
                CloseAllWindows.Invoke();
            }
            ExponatInventory.OpenMenu();
        }
        if (Input.GetKeyDown(KeyCode.T)) //Ticker oeffnen / schliessen
        {
            FeedbackTicker.ToggleFeedback();
        }
        if (Input.GetKeyDown(KeyCode.U)) //Eventmenue oeffnen
        {
            if (NumberOfOpenedWindows > 0)
            {
                CloseAllWindows.Invoke();
            }
            EventOverview.OpenMenu();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) //Tempo auf Pause
        {
            TimeKeeper.SetPause();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Tempo auf Normal
        {
            TimeKeeper.SetNormal();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Tempo auf Fast
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
                CloseAllWindows.Invoke();
                NumberOfOpenedWindows = 0;
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
    }
    /// <summary>
    /// Counts NumberOfOpenedWindows down
    /// </summary>
    public void CountDownWindows()
    {
        NumberOfOpenedWindows--;
    }
}
