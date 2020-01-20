using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponat_Memory : MonoBehaviour
{
	public float Qualitaet;
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

	public void checkSellButton()
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(1); //Ansehen +
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dein Ansehen um 1 verbessert.");

		var i = 15000 * Qualitaet;
		Playervariables.GetComponent<Money>().Spende(i);
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dir " + i.ToString("0") + " RM eingebracht.");
	}
}
