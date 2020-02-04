using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class InWorldClickEvent : UnityEvent<InWorldEvent_Memory>
{
}

public class InWorldEvent : MonoBehaviour
{
	/// <summary>
	/// Public static Event called be the clickable InWorldEvents to open and update the bigger event overview
	/// </summary>
	[SerializeField] public static InWorldClickEvent _InWorldClickEvent;

	#region References to the UI Elements, which shall be updated
	/// <summary>
	/// The description Text field of the window
	/// </summary>
	[SerializeField] Text eventDescription;
	/// <summary>
	/// The Button which selects option 1
	/// </summary>
	[SerializeField] Text eventOption1;
	/// <summary>
	/// The button which selects option 2
	/// </summary>
	[SerializeField] Text eventOption2;
	/// <summary>
	/// The InWorldEvent_Memory Component of _lastCalledEventObject
	/// </summary>
	InWorldEvent_Memory _inWorldEvent_Memory;
	#endregion

	private void Awake()
	{
		if (_InWorldClickEvent == null)
		{
			_InWorldClickEvent = new InWorldClickEvent();
		}
		_InWorldClickEvent.RemoveAllListeners();
		_InWorldClickEvent.AddListener(SetContent);
	}

	void SetContent(InWorldEvent_Memory eventValues)
	{
		_inWorldEvent_Memory = eventValues;

		eventDescription.text = _inWorldEvent_Memory.Memory.EventText;

		if (_inWorldEvent_Memory.Memory.SpecialEvents.Contains("Exponat:"))
		{
			eventOption1.text = "";
			eventOption2.text = "";
		}
		else
		{
			eventOption1.text
				= _inWorldEvent_Memory.Memory.EventOption1 + Environment.NewLine
				+ "Ansehensveränderung: " + _inWorldEvent_Memory.Memory.Option1_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + _inWorldEvent_Memory.Memory.Option1_Politik + Environment.NewLine
				+ "Kosten: " + _inWorldEvent_Memory.Memory.Option1_Geld * -1 + " RM";

			eventOption2.text
				= _inWorldEvent_Memory.Memory.EventOption2 + Environment.NewLine
				+ "Ansehensveränderung: " + _inWorldEvent_Memory.Memory.Option2_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + _inWorldEvent_Memory.Memory.Option2_Politik + Environment.NewLine
				+ "Kosten: " + _inWorldEvent_Memory.Memory.Option2_Geld * -1 + " RM";
		}
	}

	public void SetOption1()
	{
		_inWorldEvent_Memory.OptionSet = InWorldEvent_Memory.Selection.Option1;
	}
	public void SetOption2()
	{
		_inWorldEvent_Memory.OptionSet = InWorldEvent_Memory.Selection.Option2;
	} 
}
