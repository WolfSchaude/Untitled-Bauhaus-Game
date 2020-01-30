using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InWorldClickEvent : UnityEvent<int>
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

	void SetContent(int EventId)
	{
		if (EventId == 0)
		{
			var x = _EventScript.ThatOneRandomEvent.GetComponent<RandomEvent_Memory>().Memory;

			_EventTitle.text = x.Event_Jahr.ToString() + "." + x.Event_Monat.ToString() + "." + x.Event_Tag.ToString();
			_EventDescription.text = x.EventText;

			_EventOption1.GetComponentInChildren<Text>().text
				= x.EventOption1 + Environment.NewLine
				+ "Ansehensveränderung: " + x.Option1_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + x.Option1_Politik + Environment.NewLine
				+ "Kosten: " + x.Option1_Geld * -1 + " RM";

			_EventOption2.GetComponentInChildren<Text>().text
				= x.EventOption2 + Environment.NewLine
				+ "Ansehensveränderung: " + x.Option2_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + x.Option2_Politik + Environment.NewLine
				+ "Kosten: " + x.Option2_Geld * -1 + " RM";
		}
		else
		{
			var y = EventLoader.ec.Events[EventId];

			_EventTitle.text = y.SpecialEvents;
			_EventDescription.text = y.EventText;

			_EventOption1.GetComponentInChildren<Text>().text
				= y.EventOption1 + Environment.NewLine
				+ "Ansehensveränderung: " + y.Option1_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + y.Option1_Politik + Environment.NewLine
				+ "Kosten: " + y.Option1_Geld * -1 + " RM";

			_EventOption2.GetComponentInChildren<Text>().text
				= y.EventOption2 + Environment.NewLine
				+ "Ansehensveränderung: " + y.Option2_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + y.Option2_Politik + Environment.NewLine
				+ "Kosten: " + y.Option2_Geld * -1 + " RM";
		}
	}
}
