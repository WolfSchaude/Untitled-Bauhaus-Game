using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{

	public Politikmeter politikmeterSkript;
    // Start is called before the first frame update
    void Start()
    {
		politikmeterSkript = GameObject.Find("Politikmeter").GetComponent<Politikmeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(politikmeterSkript.Politiklevel >= 200)
		{
			Application.Quit();
			Debug.Log("Bruh exit");
		}
		if(politikmeterSkript.Politiklevel <= 0)
		{
			Application.Quit();
			Debug.Log("also bruh exit");
		}
    }
}
