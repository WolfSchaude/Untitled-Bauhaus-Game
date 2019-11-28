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
			ExponateUI.SetActive(true);
		}
		else
		{
			ExponateUI.SetActive(false);
		}
	}
}
