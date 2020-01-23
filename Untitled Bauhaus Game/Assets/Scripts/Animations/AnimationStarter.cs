using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AnimChangeEvent : UnityEvent<bool>
{ }

public class AnimationStarter : MonoBehaviour
{
	/// <summary>
	/// The Animator which Animations should get triggered
	/// </summary>
	[SerializeField] Animator SelfDropDown;

	/// <summary>
	/// Bool for saving the Animationstate of the object
	/// </summary>
	[SerializeField] public bool Collapsed { get; private set; }

	public AnimChangeEvent BoolChange;

	private void Awake()
	{
		if (BoolChange == null)
		{
			BoolChange = new AnimChangeEvent();
		}
	}

	void Start()
	{
		Collapsed = true;

		SelfDropDown.SetBool("Bool", Collapsed);
		BoolChange.Invoke(Collapsed);
	}
	void Update()
	{
		//SelfDropDown.SetBool("Bool", Collapsed);
	}

	/// <summary>
	/// Toggles the openeing Status between openend/closed
	/// </summary>
	public void ToggleOpened()
	{
		Collapsed = !Collapsed;

		SelfDropDown.SetBool("Bool", Collapsed);
		BoolChange.Invoke(Collapsed);
	}

	/// <summary>
	/// Forces the Menu to close, if it isn't already
	/// </summary>
	public void CloseMenu()
	{
		Collapsed = true;

		SelfDropDown.SetBool("Bool", Collapsed);
		BoolChange.Invoke(Collapsed);
	}

	/// <summary>
	/// Forces the Menu to open, if it isn't already
	/// </summary>
	public void OpenMenu()
	{
		Collapsed = false;

		SelfDropDown.SetBool("Bool", Collapsed);
		BoolChange.Invoke(Collapsed);
	}
}
