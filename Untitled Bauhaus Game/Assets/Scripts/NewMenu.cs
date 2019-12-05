using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMenu : MonoBehaviour
{
	public GameObject MenuWindow;
	public Text Name;

	public bool IsClicked;

	void Start()
	{
		IsClicked = false;
	}

	void Update()
    {
		if (!IsClicked)
		{
			MenuWindow.transform.position = Input.mousePosition + new Vector3(-400, -300, 0);
			IsClicked = true;
		}

		if (!MenuWindow.activeSelf)
		{
			IsClicked = false;
		}
		activate();
	}

	public void activate()
	{
		if (GameObject.Find("TestCube1").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube2").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube3").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube4").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube5").GetComponent<ChangeMatOnClick>().isSelected)
		{
			MenuWindow.SetActive(true);
			Name.text = ("Malerei");
		}
		else
		{
			MenuWindow.SetActive(false);
		}
	}
}
