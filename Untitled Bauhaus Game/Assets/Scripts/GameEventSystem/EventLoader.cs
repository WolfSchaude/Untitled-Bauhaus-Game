using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoader : MonoBehaviour
{
	private const string path = "XML_Files/XML_Events";
	public static EventContainer ec;

	void Start()
    {
		ec = EventContainer.Load(path);
    }
}
