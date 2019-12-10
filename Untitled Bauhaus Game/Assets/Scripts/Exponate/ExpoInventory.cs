using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UntitledBauhausGame;

public class ExpoInventory : MonoBehaviour
{
	public GameObject FeedbackTicker;

	public GameObject inventoryWindow;
	public GameObject prefab; //Exponate Prefab
	public GameObject parent; //ScrollView Content

	private float Qualität;

	private bool IsShown;

	public Animator InventoryAnimator;

	public static List<GameObject> Exponat = new List<GameObject>();

	void Start()
    {
		Resources.Load("Person1");
		IsShown = false; 
	}

    void Update()
    {

	}

	public void showWindow() //Sets inventory window active
	{
		InventoryAnimator.SetTrigger("Click");

		IsShown = !IsShown;

		if (IsShown)
		{
			GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().bewerbungGameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zuweisenGameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().detailWindow.SetActive(false);
		}
	}

	public void CloseWindow()
	{
		if (!IsShown)
		{
			InventoryAnimator.SetTrigger("Click)");

			IsShown = !IsShown;
		}
	}

	/*
	⚠️⚠️⚠️VORSICHT HÄSSLICHER CODE AHEAD⚠️⚠️⚠️
	⚠️⚠️⚠️VORSICHT HÄSSLICHER CODE AHEAD⚠️⚠️⚠️
	⚠️⚠️⚠️VORSICHT HÄSSLICHER CODE AHEAD⚠️⚠️⚠️
	*/

	public void addToInventory() //Gebunden an Exponat Done Event
	{
		var x = Instantiate(prefab, parent.transform);

		int images = Random.Range(1, 4);
		switch(images)
		{
			case 1:
				x.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Exponat1");
				break;
			case 2:
				x.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Exponat2");
				break;
			case 3:
				x.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Exponat3");
				break;
		}
			
		int herstellerText = Random.Range(1, 25);

		x.GetComponentsInChildren<Text>()[0].text = "Hersteller: " + TeacherLoader.tb.Buffer[herstellerText].Name;


		int stilText = Random.Range(1, 4);

		switch (stilText)
		{
			case 1:
				x.GetComponentsInChildren<Text>()[1].text = "Polit. Stilrichtung: Rechts";
				break;
			case 2:
				x.GetComponentsInChildren<Text>()[1].text = "Polit. Stilrichtung: Links";
				break;
			case 3:
				x.GetComponentsInChildren<Text>()[1].text = "Polit. Stilrichtung: Neutral";
				break;
		}

		Qualität = Random.Range(0.5f, 1.5f);
		x.GetComponentsInChildren<Text>()[2].text = Qualität.ToString("0.0");
		x.GetComponentInChildren<Exponat_Memory>().Qualitaet = Qualität;
		x.GetComponentInChildren<Exponat_Memory>().FeedbackTicker = FeedbackTicker;

		x.GetComponentInChildren<Button>().onClick.AddListener(() => {Destroy(x); });

		Exponat.Add(x);
	}
}
