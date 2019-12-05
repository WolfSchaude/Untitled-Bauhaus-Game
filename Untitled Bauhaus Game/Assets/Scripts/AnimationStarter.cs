using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationStarter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Animator SecondMenu;
	public Animator SelfDropDown;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (SecondMenu != null)
		{
			SecondMenu.SetBool("InsideBool", true);
		}
		SelfDropDown.SetBool("InsideBool", true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (SecondMenu != null)
		{
			SecondMenu.SetBool("InsideBool", false);
		}
		SelfDropDown.SetBool("InsideBool", false);
	}

	void Start()
	{
	}
	void Update()
	{
	}


}
