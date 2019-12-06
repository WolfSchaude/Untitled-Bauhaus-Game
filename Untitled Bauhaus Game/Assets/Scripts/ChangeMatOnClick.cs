using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatOnClick : MonoBehaviour
{
	public Material StandardMat;
	public Material OnClickMat;

	public bool isSelected = false;
	private bool mouseOver = false;

	void Start()
    {

	}

    void Update()
    {

	}

	public void closeWindow()
	{
		string[] menuname = {"TestCube1", "TestCube2", "TestCube3", "TestCube4", "TestCube5"};
		for (int i = 0; i < menuname.Length; i++)
		{
			GameObject.Find(menuname[i]).GetComponent<ChangeMatOnClick>().isSelected = false;
			GameObject.Find(menuname[i]).GetComponent<MeshRenderer>().material = StandardMat;
		}
		
	}
	void OnMouseOver() //Checks if the mouse is over the object
	{
		mouseOver = true;
		if (Input.GetMouseButtonDown(0) && !GameObject.Find("TestCube1").GetComponent<ChangeMatOnClick>().isSelected && !GameObject.Find("TestCube2").GetComponent<ChangeMatOnClick>().isSelected && !GameObject.Find("TestCube3").GetComponent<ChangeMatOnClick>().isSelected && !GameObject.Find("TestCube4").GetComponent<ChangeMatOnClick>().isSelected && !GameObject.Find("TestCube5").GetComponent<ChangeMatOnClick>().isSelected)
		{
			GetComponent<MeshRenderer>().material = OnClickMat;
			isSelected = true;
		}
	}

	void OnMouseExit() //Checks if the mouse exits the object
	{
		mouseOver = false;
	}
}
