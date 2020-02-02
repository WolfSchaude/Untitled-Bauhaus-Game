using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackScript : MonoBehaviour
{
	public GameObject prefab;
	public GameObject parent;

	public GameObject UIToBlendIn;

	public List<GameObject> TicksCount;

	public Animator TickerFieldAnimator;

	public bool Collapsed = false;

    void Start()
    {
		TicksCount = new List<GameObject>();
		Collapsed = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(TicksCount.Count>=36)
		{
			Destroy(TicksCount[0]);
			TicksCount.Remove(TicksCount[0]);
		}

		TickerFieldAnimator.SetBool("Bool", Collapsed);
    }

	public void ToggleFeedback()
	{
		Collapsed = !Collapsed;

		if (Collapsed)
		{
			UIToBlendIn.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
		}

		StartCoroutine(ScrollToBottom());
		StartCoroutine(WaitToChangeSymbol());
	}

	public void CloseFeedback()
	{
		Collapsed = true;

		gameObject.GetComponentInChildren<Text>().text = "▲";
	}

	public void OpenFeedback()
	{
		Collapsed = false;

		StartCoroutine(ScrollToBottom());
		StartCoroutine(WaitToChangeSymbol());
	}

	public void NewTick(string message)
	{
		var newthing = Instantiate(prefab, parent.transform);

		newthing.GetComponentInChildren<Text>().text = message;

		TicksCount.Add(newthing);

		StartCoroutine(ScrollToBottom());

		if (Collapsed)
		{
			TickerFieldAnimator.SetTrigger("Click");

			Collapsed = false;
		}
	}

	/// <summary>
	/// Coroutine used to Scroll after Generating a new Ticker Notification
	/// </summary>
	IEnumerator ScrollToBottom()
	{
		yield return new WaitForEndOfFrame();

		UIToBlendIn.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
	}
	/// <summary>
	/// Coroutine used to Scroll after switching between opened and closed
	/// </summary>
	IEnumerator ScrollToBottomSec()
	{
		yield return new WaitForSecondsRealtime(0.6f);

		UIToBlendIn.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
	}

	IEnumerator WaitToChangeSymbol()
	{
		yield return new WaitForSecondsRealtime(0.6f);

		if (Collapsed)
		{
			gameObject.GetComponentInChildren<Text>().text = "▲";
		}
		else
		{
			gameObject.GetComponentInChildren<Text>().text = "▼";
		}
	}
}
