using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UntitledBauhausGame;

public class ExpoInventory : MonoBehaviour
{
	public GameObject inventoryWindow;
	public GameObject prefab; //Exponate Prefab
	public GameObject parent; //ScrollView Content

	public static List<GameObject> Exponat = new List<GameObject>();

	void Start()
    {

		inventoryWindow.SetActive(false);
	}

    void Update()
    {
		if (Exponate.isExponatDone)
		{
			Exponat.Add(Instantiate(prefab, parent.transform));
		}
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
