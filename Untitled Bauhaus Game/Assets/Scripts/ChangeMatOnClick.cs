using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatOnClick : MonoBehaviour
{
	public Material StandardMat;
	public Material OnClickMat;

	private bool outlineShown = false;
	private bool mouseOver = false;

	void Start()
    {
		//Fetch the Material from the Renderer of the GameObject
		//StandardMat = GetComponent<Renderer>().material;
	}

    void Update()
    {
		if (Input.GetMouseButtonDown(0) && outlineShown && !mouseOver)
		{
			GetComponent<MeshRenderer>().material = StandardMat;
			outlineShown = false;
		}
	}

	void OnMouseOver()
	{
		mouseOver = true;
		if (Input.GetMouseButtonDown(0) || outlineShown)
		{
			GetComponent<MeshRenderer>().material = OnClickMat;
			outlineShown = true;
		}
	}

	void OnMouseExit()
	{
		mouseOver = false;
	}
}
