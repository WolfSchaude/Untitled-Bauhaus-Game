using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationStarter : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler*/
{
	public Animator SecondMenu;
	public Animator SelfDropDown;

	public bool IsOpened;

	public void ToggleOpened()
	{
		SelfDropDown.SetTrigger("Click");
		if (SecondMenu != null)
		{
			SecondMenu.SetTrigger("Click)");
		}

		IsOpened = !IsOpened;
	}

	void Start()
	{
		IsOpened = false;
	}
	void Update()
	{
	}


}
