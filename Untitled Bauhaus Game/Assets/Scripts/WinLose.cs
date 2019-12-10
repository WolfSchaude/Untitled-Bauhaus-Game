using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{

	public Politikmeter politikmeterSkript;
	public Money moneySkript;
	public Studenten studentenSkript;

	private int PleiteThreshold = 30;
	private int PleiteCounter = 0;

	// Start is called before the first frame update
	void Start()
    {
		politikmeterSkript = GameObject.Find("Politikmeter").GetComponent<Politikmeter>();
		moneySkript = GameObject.Find("Money Display").GetComponent<Money>();
		studentenSkript = GameObject.Find("Studenten Counter").GetComponent<Studenten>();
	}

    // Update is called once per frame
    void Update()
    {
        if(politikmeterSkript.Politiklevel >= 200)
		{
			SceneManager.LoadScene("Main_Menu");
			Debug.Log("Du bist zu weit rechts");
		}
		if(politikmeterSkript.Politiklevel <= 0)
		{
			SceneManager.LoadScene("Main_Menu");
			Debug.Log("Du bist zu weit links");
		}
		if(PleiteCounter >= PleiteThreshold)
		{
			SceneManager.LoadScene("Main_Menu");
			Debug.Log("Sorry, bist pleite gegangen");
		}
		if(studentenSkript.StudentenAnzahl <= 0)
		{
			SceneManager.LoadScene("Main_Menu");
			Debug.Log("Du hast keine Studenten mehr");
		}
    }

	public void IncreasePleiteCounter()
	{
		if (moneySkript.money < 0)
		{
			PleiteCounter++;
		}
		else
		{
			PleiteCounter = 0;
		}
	}
}
