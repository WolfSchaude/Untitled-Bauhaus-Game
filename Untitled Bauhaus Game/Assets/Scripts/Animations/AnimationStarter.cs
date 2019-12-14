using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationStarter : MonoBehaviour
{
	public Animator SelfDropDown;

	public bool Collapsed;

	public void ToggleOpened()
	{
		//SelfDropDown.SetTrigger("Click");

		Collapsed = !Collapsed;
	}

	public void CloseMenu()
	{
		//if (!Collapsed)
		//{
			//SelfDropDown.SetTrigger("Click)");

			Collapsed = true;
		//}
	}

	void Start()
	{
		Collapsed = true;
	}
	void Update()
	{
		SelfDropDown.SetBool("Bool", Collapsed);
	}
}
