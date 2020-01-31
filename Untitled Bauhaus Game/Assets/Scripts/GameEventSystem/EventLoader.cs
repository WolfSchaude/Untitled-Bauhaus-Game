using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoader : MonoBehaviour
{
	private const string path = "XML_Files/XML_Events";
	private const string randompath = "XML_Files/XML_RandomEvents";

	[SerializeField] public static EventContainer ec;
	[SerializeField] public static EventContainer ec_random;


	void Awake()
    {
		ec = EventContainer.Load(path);
		ec_random = EventContainer.Load(randompath);
	}
}
