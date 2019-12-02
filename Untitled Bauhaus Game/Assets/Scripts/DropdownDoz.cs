﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropdownDoz : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttons;
    private GameObject dropdownB;
	private GameObject overviewB;
 
	public RectTransform container;
	public bool isOpen;

	private Vector3 transVector;
	public void OnPointerEnter(PointerEventData eventData)
	{
		dropdownB.transform.Translate(-transVector);
		overviewB.transform.Translate(-transVector);
		isOpen = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		dropdownB.transform.Translate(transVector);
		overviewB.transform.Translate(transVector);
		isOpen = false;
	}

	void Start()
	{
        StartCoroutine(WaitUntilEndOfFrame());

        dropdownB = GameObject.Find("Dropdown Gebäude");
		overviewB = GameObject.Find("Übersicht Gebäude");

		container = transform.Find("Container").GetComponent<RectTransform>();
		isOpen = false;
	}

    IEnumerator WaitUntilEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        transVector = new Vector3(0, GetComponent<RectTransform>().rect.height + (buttons.GetComponent<RectTransform>().rect.height * 2), 0);
    }

    // Update is called once per frame
    void Update()
	{
		Vector3 scale = container.localScale;
		scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
		container.localScale = scale;
	}
}
