using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponat_Memory : MonoBehaviour
{
	public float Qualitaet;
	public int Politik;
	public GameObject FeedbackTicker;
	public GameObject Playervariables;

	void Start()
    {
		FeedbackTicker = GameObject.Find("Button - Feedback Ticker");
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
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dein Ansehen um 1 verbessert.");

		int i = (int)(15000 * Qualitaet);
		Playervariables.GetComponent<Money>().Spende(i);
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dir " + i.ToString("0") + " RM eingebracht.");
		Exponate._ExponatSellEvent.Invoke(i);

		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics((int)((Politik - 100) / 10 * Qualitaet));
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat die Politische Position deiner Hochschule verschoben.");
	}
}
