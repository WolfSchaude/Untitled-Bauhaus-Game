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

	private bool once;

    void Start()
    {
		FeedbackTicks = new List<GameObject>();

		once = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (FeedbackTicks.Count >= 100)
		{
			FeedbackTicks.RemoveRange(100, FeedbackTicks.Count - 100);
		}
    }

	public void ToggleFeedback()
	{
		if (UIToBlendIn.activeSelf)
		{
			UIToBlendIn.SetActive(false);
			gameObject.GetComponentInChildren<Text>().text = "▲";
		}
		else
		{
			UIToBlendIn.SetActive(true);
			gameObject.GetComponentInChildren<Text>().text = "▼";
		}
	}

	public void NewTick(string message)
	{
		var newthing = Instantiate(prefab, parent.transform);

		newthing.GetComponentInChildren<Text>().text = message;

		FeedbackTicks.Add(newthing);

		//Canvas.ForceUpdateCanvases();
		//UIToBlendIn.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
		//Canvas.ForceUpdateCanvases();

		//ScrollToBottom(UIToBlendIn.GetComponent<ScrollRect>());

		StartCoroutine(ScrollToBottom());
	}

	public static void ScrollToBottom(ScrollRect scrollRect)
	{
		scrollRect.normalizedPosition = new Vector2(0, 0);
	}

	IEnumerator ScrollToBottom()
	{
		yield return new WaitForEndOfFrame();
		//scrollRect.gameObject.SetActive(true);
		UIToBlendIn.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
	}
}
