using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UntitledBauhausGame;

public class Money : MonoBehaviour
{
    /*
       (Bug) FUNKTIONIERT ZWAR, "Gehalt" WIRD ABER DIREKT AM ANFANG EIN MAL AUSGEFÜHRT
    */    

    public float money = 200000;
	public float oldMoney = 0;

    public Text moneyText;

    private int lastMonth;

    void Start()
    {
        
    }

    void Update()
    {
		moneyText.text = "Geld: " + money.ToString("N") + " RM";

        //checkMonth();
    }

    public void addGehalt() //Monatliches Gehalt abhängig von der Studentenanzahl und dem Politikmeter
    {
		oldMoney = money;
		money += (GameObject.Find("Studenten Counter").GetComponent<Studenten>().StudentenAnzahl * 10) * ((float)GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel / 100);
		GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Monatliches Gehalt: + " + (money - oldMoney) + " RM.");
	}

	public void Spende(int spende)
    {
        if (spende > 0)
        {
            money += spende;
        }
    }

    public bool Bezahlen(int preis)
    {
		if (money - preis <= 0)
		{
			return false;
		}
		else
		{
			money -= preis;
			return true;
		}
		
    }

	public void Geld(int value)
	{
		money += value;
	}
}
