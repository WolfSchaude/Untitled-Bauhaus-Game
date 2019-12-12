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
	private float oldMoney = 0;
	private float preCheatMoney = 0;

	bool isToggleOn = false;

    public Text moneyText;

	public Toggle cheatToggle; //CheatMenu Toggle

    private int lastMonth;

    void Start()
    {
		preCheatMoney = money;
	}

    void Update()
    {
		moneyText.text = "Geld: " + money.ToString("N") + " RM";
		infiniteMoney();
        //checkMonth();
    }

    public void addGehalt() //Monatliches Gehalt abhängig von der Studentenanzahl und dem Politikmeter
    {
			oldMoney = money;
			money += (GameObject.Find("Studenten Counter").GetComponent<Studenten>().StudentenAnzahl * 10) * ((float)GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel / 100);
			GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick("Monatliche Einnahmen: + " + (money - oldMoney) + " RM.");
	}

	public void Spende(float spende)
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

	public void infiniteMoney()
	{
		if (cheatToggle.isOn)
		{
			if (isToggleOn)
			{
				preCheatMoney = money;
			}
			isToggleOn = false;
			moneyText.text = "Geld: ∞";
			money = 1000000;
		}
		else
		{
			if (!isToggleOn)
			{
				money = preCheatMoney;
			}
			isToggleOn = true;
		}
	}
}
