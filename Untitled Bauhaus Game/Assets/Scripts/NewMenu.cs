using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMenu : MonoBehaviour
{
	public GameObject MenuWindow;
	public GameObject MenuPanel;
	public Dropdown MenuDropdown;
	public Text Name;

	public int oldValue = 0;
	Vector3 menuPos;

	public bool IsClicked;

	public int activeChecker = 0;

	void Start()
	{
		IsClicked = false;
	}

	void Update()
	{
		checkActive();
		setMenu();
		activate();

		//Set UI to GameObject position
		MenuWindow.transform.position = menuPos;

		if (!IsClicked)
		{
			//MenuWindow.transform.position = Input.mousePosition + new Vector3(-400, -300, 0); //set window to mouse position
			IsClicked = true;
		}

		if (!MenuWindow.activeSelf)
		{
			IsClicked = false;
		}
	}

	public void activate()
	{
		if (GameObject.Find("TestCube1").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube2").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube3").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube4").GetComponent<ChangeMatOnClick>().isSelected || GameObject.Find("TestCube5").GetComponent<ChangeMatOnClick>().isSelected)
		{
			MenuWindow.SetActive(true);
		}
		else
		{
			MenuWindow.SetActive(false);
		}
	}

	public void checkActive()
	{
		string[] test = { "TestCube1", "TestCube2", "TestCube3", "TestCube4", "TestCube5" };
		for (int i = 0; i < test.Length; i++)
		{
			if (GameObject.Find(test[i]).GetComponent<ChangeMatOnClick>().isSelected)
			{
				activeChecker = i + 1;
				menuPos = Camera.main.WorldToScreenPoint(GameObject.Find(test[i]).transform.position); //Update Position
				break;
			}
		}
	}
	public void setMenu()
	{
		switch (activeChecker)
		{
			case 1:
				//MenuDropdown.options.Add(new Dropdown.OptionData() { text = "test" });
				//for (int x = 0; x < MenuDropdown.options.Count; x++)
				//{
				//	if (MenuDropdown.options[x].text == "test")
				//	{
				//		MenuDropdown.options.RemoveAt(x);
				//		//break;
				//	}
				//}
				Name.text = "Architekturwerkstatt";
				break;
			case 2:
				Name.text = "Malerei";
				break;
			case 3:
				Name.text = "Ausstellungsgestaltung";
				break;
			case 4:
				Name.text = "Metallwerkstatt";
				break;
			case 5:
				Name.text = "Tischlerei";
				break;
		}
	}
}
