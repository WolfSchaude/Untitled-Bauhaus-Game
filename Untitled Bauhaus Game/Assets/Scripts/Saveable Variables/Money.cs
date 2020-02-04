using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour, ISaveableInterface
{
	/*
       (Bug) FUNKTIONIERT ZWAR, "Gehalt" WIRD ABER DIREKT AM ANFANG EIN MAL AUSGEFÜHRT
    */
	public GameObject SaveGameKeeper;

    public float money = 200000;
	public float monthlyCosts = 0;
	private float moneyOPerMonth = 0;
	private float moneyIPerMonth = 0;
	private float oldMoney = 0;
	private float preCheatMoney = 0;
	private float pipelineMoney = 25000;

	bool isToggleOn = false;
	private bool pipelineUpdate;

    public Text moneyText;

	public Toggle cheatToggle; //CheatMenu Toggle

    private int lastMonth;

    void Start()
    {
		preCheatMoney = money;
	}

    void Update()
    {
		moneyText.text = money.ToString("N") + " RM";
		infiniteMoney();
        //checkMonth();
    }

    public void addGehalt() //Monatliches Gehalt abhängig von der Studentenanzahl und dem Politikmeter
    {
		oldMoney = money;
		money += (gameObject.GetComponent<Studenten>().StudentenAnzahl * 10) * ((float)gameObject.GetComponent<Politikmeter>().Politiklevel / 100);
		moneyIPerMonth += money - oldMoney;
		Ticker.NewTick.Invoke("Monatliche Einnahmen: + " + (money - oldMoney) + " RM.");
	}

	public float MonthlyMoneyI()
	{

		float Temp = pipelineMoney;
		pipelineMoney = moneyIPerMonth;
		return Temp;
	}

	public float MonthlyMoneyO()
	{
		float Temp = moneyOPerMonth;
		moneyOPerMonth = 0;
		return Temp;
	}

	public void Spende(float spende)
    {
        if (spende > 0)
        {
            money += spende;
			moneyIPerMonth += spende;
        }
    }

    public bool Bezahlen(int preis)
    {
		if (money - preis < 0)
		{
			return false;
		}
		else
		{
			money -= preis;
			moneyOPerMonth += preis;
			return true;
		}
		
    }

	public void Geld(int value)
	{
		money += value;
		if (value < 0)
		{
			moneyOPerMonth -= value;
		}
		else
		{
			moneyIPerMonth += value;
		}
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

	public void Save()
	{
		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentMoney = money;
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[1] = true;
	}

	public void Load(Save save)
	{
		money = save.CurrentMoney;
	}

	public void LoadStart()
	{
		preCheatMoney = money;
	}
}
