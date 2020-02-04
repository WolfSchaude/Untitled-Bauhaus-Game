using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class InWorldClickEvent : UnityEvent<Event>
{
}

public class InWorldEvent : MonoBehaviour
{
	/// <summary>
	/// Public static Event called be the clickable InWorldEvents to open and update the bigger event overview
	/// </summary>
	public static InWorldClickEvent _InWorldClickEvent;

	#region References to the UI Elements, which shall be updated
	/// <summary>
	/// The description Text field of the window
	/// </summary>
	[SerializeField] Text _EventDescription;
	/// <summary>
	/// The Button which selects option 1
	/// </summary>
	[SerializeField] Text _EventOption1;
	/// <summary>
	/// The button which selects option 2
	/// </summary>
	[SerializeField] Text _EventOption2;

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

	void SetContent(Event eventValues)
	{
		print(eventValues + " " + eventValues.EventText);

		_EventDescription.text = eventValues.EventText;

		_EventOption1.text
			= eventValues.EventOption1 + Environment.NewLine
			+ "Ansehensveränderung: " + eventValues.Option1_Ansehen + Environment.NewLine
			+ "Politische Tragweite: " + eventValues.Option1_Politik + Environment.NewLine
			+ "Kosten: " + eventValues.Option1_Geld * -1 + " RM";

		_EventOption2.text
			= eventValues.EventOption2 + Environment.NewLine
			+ "Ansehensveränderung: " + eventValues.Option2_Ansehen + Environment.NewLine
			+ "Politische Tragweite: " + eventValues.Option2_Politik + Environment.NewLine
			+ "Kosten: " + eventValues.Option2_Geld * -1 + " RM";
	}
}
