using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InWorldClickEvent : UnityEvent<Event>
{
}

public class InWorldEvent : MonoBehaviour
{
	/// <summary>
	/// Public static Event called be the clickable InWorldEvents to open and update the bigger event overview
	/// </summary>
	public static InWorldClickEvent _InWorldClickEvent;

	/// <summary>
	/// The EventScript, needed to gain access to the random Event, for now
	/// </summary>
	[SerializeField] EventScript _EventScript;

	#region References to the UI Elements, which shall be updated
	/// <summary>
	/// The title Text field of the window
	/// </summary>
	[SerializeField] Text _EventTitle;
	/// <summary>
	/// The description Text field of the window
	/// </summary>
	[SerializeField] Text _EventDescription;
	/// <summary>
	/// The Button which selects option 1
	/// </summary>
	[SerializeField] Button _EventOption1;
	/// <summary>
	/// The button which selects option 2
	/// </summary>
	[SerializeField] Button _EventOption2;

	#endregion
	private void Awake()
	{
		if (_InWorldClickEvent == null)
		{
			_InWorldClickEvent = new InWorldClickEvent();
		}
		_InWorldClickEvent.AddListener((x) => { SetContent(x); });
	}

	void SetContent(Event eventValues)
	{
		_EventTitle.text = "ID: " + eventValues.ID.ToString();
		_EventDescription.text = eventValues.EventText;

		_EventOption1.GetComponentInChildren<Text>().text
			= eventValues.EventOption1 + Environment.NewLine
			+ "Ansehensveränderung: " + eventValues.Option1_Ansehen + Environment.NewLine
			+ "Politische Tragweite: " + eventValues.Option1_Politik + Environment.NewLine
			+ "Kosten: " + eventValues.Option1_Geld * -1 + " RM";

		_EventOption2.GetComponentInChildren<Text>().text
			= eventValues.EventOption2 + Environment.NewLine
			+ "Ansehensveränderung: " + eventValues.Option2_Ansehen + Environment.NewLine
			+ "Politische Tragweite: " + eventValues.Option2_Politik + Environment.NewLine
			+ "Kosten: " + eventValues.Option2_Geld * -1 + " RM";
	}
}
