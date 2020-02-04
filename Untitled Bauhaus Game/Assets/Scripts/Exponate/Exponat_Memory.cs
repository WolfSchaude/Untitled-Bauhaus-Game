using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponat_Memory : MonoBehaviour
{
	public float Qualitaet;
	public int Politik;
	public GameObject Playervariables;

	void Start()
    {
		Playervariables = GameObject.Find("PlayerVariables");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// Sells the exponat
	/// </summary>
	public void SellDis()
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(1); //Ansehen +
		Ticker.NewTick.Invoke("Dein Exponat hat dein Ansehen um 1 verbessert.");

		int i = (int)(15000 * Qualitaet);
		Playervariables.GetComponent<Money>().Spende(i);
		Ticker.NewTick.Invoke("Dein Exponat hat dir " + i.ToString("0") + " RM eingebracht.");
		Exponate._ExponatSellEvent.Invoke(i);

		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics((int)((Politik - 100) / 10 * Qualitaet));
		Ticker.NewTick.Invoke("Dein Exponat hat die Politische Position deiner Hochschule verschoben.");
	}
}
