using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
	public TimeMode Mode;

	public Sprite Normal;

	public Sprite Selected;

	public enum TimeMode
	{
		Pause, Normal, FastForward
	}


    void Start()
    {
		SetPause();
	}

    void Update()
    {

    }

	public void SetPause()
	{
		Mode = TimeMode.Pause;

		gameObject.GetComponentsInChildren<Image>()[1].sprite = Selected;
		gameObject.GetComponentsInChildren<Image>()[2].sprite = Normal;
		gameObject.GetComponentsInChildren<Image>()[3].sprite = Normal;
	}

	public void SetNormal()
	{
		Mode = TimeMode.Normal;

		gameObject.GetComponentsInChildren<Image>()[1].sprite = Normal;
		gameObject.GetComponentsInChildren<Image>()[2].sprite = Selected;
		gameObject.GetComponentsInChildren<Image>()[3].sprite = Normal;
	}

	public void SetFastforward()
	{
		Mode = TimeMode.FastForward;

		gameObject.GetComponentsInChildren<Image>()[1].sprite = Normal;
		gameObject.GetComponentsInChildren<Image>()[2].sprite = Normal;
		gameObject.GetComponentsInChildren<Image>()[3].sprite = Selected;
	}
}
