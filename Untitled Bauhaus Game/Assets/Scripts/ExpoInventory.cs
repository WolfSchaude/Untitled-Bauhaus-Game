﻿using System.Collections;
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

	private Ray ray; // The ray
	private RaycastHit hit; // What we hit

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

	public void checkSellButton()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value++; //Ansehen +
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dein Ansehen um 1 verbessert.");
		var i = Random.Range(5000, 25001);
		GameObject.Find("Money Display").GetComponent<Money>().Spende(i);
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dir " + i + " RM eingebracht.");

		//Destroy(x);
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
				x.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Person1");
				break;
			case 2:
				x.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Person2");
				break;
			case 3:
				x.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Person3");
				break;
		}

		int herstellerText = Random.Range(1, 4);

		switch (herstellerText)
		{
			case 1:
				x.GetComponentsInChildren<Text>()[0].text = "Hersteller: Job Bonson";
				break;
			case 2:
				x.GetComponentsInChildren<Text>()[0].text = "Hersteller: Boomar";
				break;
			case 3:
				x.GetComponentsInChildren<Text>()[0].text = "Hersteller: Omar";
				break;
		}

		int stilText = Random.Range(1, 4);

		switch (stilText)
		{
			case 1:
				x.GetComponentsInChildren<Text>()[1].text = "Stilrichtung: KA1";
				break;
			case 2:
				x.GetComponentsInChildren<Text>()[1].text = "´Stilrichtung: KA2";
				break;
			case 3:
				x.GetComponentsInChildren<Text>()[1].text = "Stilrichtung: KA3";
				break;
		}

		int qualitätText = Random.Range(1, 5);

		switch (qualitätText)
		{
			case 1:
				x.GetComponentsInChildren<Text>()[2].text = "Qualität: Super";
				break;
			case 2:
				x.GetComponentsInChildren<Text>()[2].text = "Qualität: Beschissen";
				break;
			case 3:
				x.GetComponentsInChildren<Text>()[2].text = "Qualität: Ich kotze gleich";
				break;
			case 4:
				x.GetComponentsInChildren<Text>()[2].text = "Qualität: WOOOOOW";
				break;
		}

		x.GetComponentInChildren<Button>().onClick.AddListener(() => {checkSellButton(); Destroy(x); });

		Exponat.Add(x);

		
	}
}
