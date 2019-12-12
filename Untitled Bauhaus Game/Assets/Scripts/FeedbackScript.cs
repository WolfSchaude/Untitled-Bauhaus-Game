using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackScript : MonoBehaviour
{
	public GameObject prefab;
	public GameObject parent;

	public GameObject UIToBlendIn;

	public List<GameObject> FeedbackTicks;
	public List<GameObject> TicksCount;

	public Animator TickerFieldAnimator;
	public Animator ButtonAnimator;
	public bool Collapsed;

    void Start()
    {
		FeedbackTicks = new List<GameObject>();
		Collapsed = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (FeedbackTicks.Count >= 100)
		{
			FeedbackTicks.RemoveRange(100, FeedbackTicks.Count - 100);
		}

		if(TicksCount.Count>=36)
		{
			Destroy(TicksCount[0]);
			TicksCount.Remove(TicksCount[0]);
		}
    }

	public void ToggleFeedback()
	{
		TickerFieldAnimator.SetTrigger("Click");
		ButtonAnimator.SetTrigger("Click");

		Collapsed = !Collapsed;

		if (Collapsed)
		{
			gameObject.GetComponentInChildren<Text>().text = "▲";
		}
		else
		{
			gameObject.GetComponentInChildren<Text>().text = "▼";
		}
	}

	public void CloseFeedback()
	{
		if (!Collapsed)
		{
			TickerFieldAnimator.SetTrigger("Click");
			ButtonAnimator.SetTrigger("Click");

			Collapsed = true;

			gameObject.GetComponentInChildren<Text>().text = "▲";
		}
	}

	public void NewTick(string message)
	{
		var newthing = Instantiate(prefab, parent.transform);

		newthing.GetComponentInChildren<Text>().text = message;

		FeedbackTicks.Add(newthing);
		TicksCount.Add(newthing);

		StartCoroutine(ScrollToBottom());

		if (Collapsed)
		{
			TickerFieldAnimator.SetTrigger("Click");
			ButtonAnimator.SetTrigger("Click");

			Collapsed = false;
		}
	}

	IEnumerator ScrollToBottom()
	{
		yield return new WaitForEndOfFrame();

		UIToBlendIn.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
	}
}
