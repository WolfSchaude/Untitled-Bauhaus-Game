using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsehenScript : MonoBehaviour
{
    public int Ansehen;

    public Text AnsehenText;

    public GameObject SaveGameKeeper;

    void Start()
    {
        Ansehen = 1;
    }

    // Update is called once per frame
    void Update()
    {
		if (Ansehen <= 1)
		{
			Ansehen = 1;
		}

		AnsehenText.text = "Ansehen: " + Ansehen;
    }

    public void ManipulateAnsehen(int wert)
    {
        Ansehen += wert;

        if (Ansehen < 0)
        {
            Ansehen = 0;
        }
    }

    public void Save()
    {
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentAnsehen = Ansehen;
        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[2] = true;
    }

    public void Load(Save save)
    {
        Ansehen = save.CurrentAnsehen;

        //SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasLoaded[2] = true;
    }
}
