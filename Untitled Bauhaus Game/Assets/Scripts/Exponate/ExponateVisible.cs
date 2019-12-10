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
		if (GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter > 0)
		{
			ExponateUI.SetActive(true);
		}
		else
		{
			ExponateUI.SetActive(false);
		}
	}
}
