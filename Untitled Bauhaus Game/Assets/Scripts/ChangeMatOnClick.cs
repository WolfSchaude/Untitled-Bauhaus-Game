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
		if (Input.GetMouseButtonDown(0) && !mouseOver)
		{
			GetComponent<MeshRenderer>().material = StandardMat;
			isSelected = false;
		}
	}

	void OnMouseOver() //Checks if the mouse is over the object
	{
		mouseOver = true;
		if (Input.GetMouseButtonDown(0))
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
