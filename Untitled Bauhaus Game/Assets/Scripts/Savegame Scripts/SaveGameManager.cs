using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SaveEvent : UnityEvent<Save>
{ }

public class SaveGameManager : MonoBehaviour
{
    public UnityEvent SaveGameEvent;
    public SaveEvent LoadGameEvent;

    public Save Savestate;

    public List<bool> WhoHasSaved = new List<bool>(6);

    enum WerSpeichert
    {
        Datum, Geld, Ansehen, Politik, Studentenanzahl, Gebäude, Lehrer, ZugewieseneLehrer, Exponate, LaufendeEvents
    }

    void Start()
    {
        //if (LoadGameEvent == null)
        //    LoadGameEvent = new SaveEvent();

        WhoHasSaved = new List<bool>(new bool[6]);

        if (GameObject.Find("SceneSwitcher").GetComponent<SaveGameLoader>().LoadSaveGame)
        {
            LoadSave();
            Debug.Log("Loaded Savegame");
        }
        else
        {
            LoadStart();
            Debug.Log("Loaded Start");
        }
    }
    void Update()
    {
        
    }

    private IEnumerator SaveGameInternal()
    {
        Debug.Log("Started Saving Process");
        Savestate = new Save();

        Debug.Log("Invoking Event");
        SaveGameEvent.Invoke();

        yield return new WaitUntil(() => WhoHasSaved.Count == WhoHasSaved.FindAll(i => i == true).Count);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.bhs");
        bf.Serialize(file, Savestate);

        file.Close();

        Debug.Log("Created Savefile at: " + Application.persistentDataPath + "/gameave.bhs");

        Savestate = null;
        WhoHasSaved = new List<bool>(new bool[5]);
    }

    public void LoadSave()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.bhs"))
        {
            //Maybe Clear rest

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.bhs", FileMode.Open);
            Save save = bf.Deserialize(file) as Save;
            file.Close();

            LoadGameEvent.Invoke(save);
        }
        else
        {
            Debug.Log("No Savegame Found!");
        }
    }

    public void LoadStart()
    {
        if (File.Exists(Application.persistentDataPath + "/PointBlank.bhs"))
        {
            //Maybe Clear rest

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PointBlank.bhs", FileMode.Open);
            Save save = bf.Deserialize(file) as Save;
            file.Close();

            LoadGameEvent.Invoke(save);
        }
        else
        {
            Debug.Log("No Savegame Found!");
        }
    }

    public void SaveGame()
    {
        Debug.Log("Clicked on Button, Starting CoRoutine");
        StartCoroutine(SaveGameInternal());
    }
}
