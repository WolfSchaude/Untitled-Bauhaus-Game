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
		if (IsOpened)
		{
			if (SecondMenu != null)
			{
				SecondMenu.SetBool("InsideBool", false);
			}
			SelfDropDown.SetBool("InsideBool", false);

			IsOpened = false;
		}
		else
		{
			if (SecondMenu != null)
			{
				SecondMenu.SetBool("InsideBool", true);
			}
			SelfDropDown.SetBool("InsideBool", true);

			IsOpened = true;
		}
	}

	void Start()
	{
		IsOpened = false;
	}
	void Update()
	{
	}


}
