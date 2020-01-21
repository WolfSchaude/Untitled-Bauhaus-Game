﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationStarter : MonoBehaviour
{
	public Animator SelfDropDown;

	[SerializeField] private bool Collapsed;

	void Start()
	{
		Collapsed = true;
	}
	void Update()
	{
		SelfDropDown.SetBool("Bool", Collapsed);
	}

	public void ToggleOpened()
	{
		Collapsed = !Collapsed;
	}

	public void CloseMenu()
	{
		Collapsed = true;
	}

	public void OpenMenu()
	{
		Collapsed = false;
	}
}
