using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UntitledBauhausGame;

public class ExpoInventory : MonoBehaviour
{
	public GameObject inventoryWindow;
	public GameObject prefab; //Exponate Prefab
	public GameObject parent; //ScrollView Content

	public static List<GameObject> Exponat = new List<GameObject>();

	void Start()
    {
		Resources.Load("Person1");
	}

    void Update()
    {
			
	}

	public void showWindow() //Sets inventory window active
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

	public void addToInventory() //Gebunden an Exponat Done Event
	{
		Exponat.Add(Instantiate(prefab, parent.transform));
	}
}
