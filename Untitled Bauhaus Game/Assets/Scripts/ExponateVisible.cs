using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExponateVisible : MonoBehaviour
{
	public GameObject ExponateUI;
	public bool ExponateUIVisible;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (CreateBewerber.eingestellter1active || CreateBewerber.eingestellter2active || CreateBewerber.eingestellter3active)
		{
			Debug.Log("true");
			ExponateUI.SetActive(true);
		}
		else
		{
			Debug.Log("false");
			ExponateUI.SetActive(false);
		}
	}
}
