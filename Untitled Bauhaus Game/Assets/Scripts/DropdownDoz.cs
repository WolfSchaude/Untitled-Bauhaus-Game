using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropdownDoz : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttons;
    public GameObject dropdownB;
 
	public RectTransform container;
	public bool isOpen;

	public float x;
	public float y;
	public float z;


	private Vector3 transVector;
	public void OnPointerEnter(PointerEventData eventData)
	{
		dropdownB.transform.Translate(-1 * transVector);
		Debug.Log(transVector.ToString());
		isOpen = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		dropdownB.transform.Translate(transVector);
		StartCoroutine(WaitABit());
		//isOpen = false;
	}

	void Start()
	{
        StartCoroutine(WaitUntilEndOfFrame());

		container = transform.Find("Container").GetComponent<RectTransform>();
		//isOpen = false;
	}

    IEnumerator WaitUntilEndOfFrame()
    {
        yield return new WaitForEndOfFrame();

		transVector = new Vector3(0, buttons.GetComponent<RectTransform>().rect.height * 2.1f, 0);
		//transVector = new Vector3(0, buttons.GetComponent<RectTransform>().sizeDelta.y * 2.1f, 0);
	}

	IEnumerator WaitABit()
	{
		yield return new WaitForSecondsRealtime(1);
	}

    // Update is called once per frame
    void Update()
	{
		Vector3 scale = container.localScale;
		scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
		container.localScale = scale;

		x = transVector.x;
		y = transVector.y;
		z = transVector.z;
	}
}
