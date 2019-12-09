using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpoInventory : MonoBehaviour
{
	public GameObject inventoryWindow;

	void Start()
    {
		inventoryWindow.SetActive(false);
    }

    void Update()
    {
        
    }

	public void showWindow() //Sets detail window active
	{
		if (!inventoryWindow.activeSelf)
		{
			inventoryWindow.SetActive(true);
			GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().bewerbungGameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zuweisenGameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().detailWindow.SetActive(false);
		}
		else
		{
			inventoryWindow.SetActive(false);
		}
	}
}
