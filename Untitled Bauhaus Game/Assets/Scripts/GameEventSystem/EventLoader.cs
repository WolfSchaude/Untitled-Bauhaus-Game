using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoader : MonoBehaviour
{
	private const string path = "XML_Files/XML_Events";
	private const string randompath = "XML_Files/XML_RandomEvents";

	public static EventContainer ec;
	public static RandomEventContainer rec;

	void Awake()
    {
		ec = EventContainer.Load(path);
		rec = RandomEventContainer.Load(randompath);
    }
}
