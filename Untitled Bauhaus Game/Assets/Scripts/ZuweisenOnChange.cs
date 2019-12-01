using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuweisenOnChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnChange()
	{
		switch (Convert.ToInt32(this.GetComponent<Dropdown>()))
		{
			case 0:
				Debug.Log("nicht zugewiesen");
				break;
			case 1:
				Debug.Log("Ist der Architekturwerkstatt zugewiesen");
				break;
			case 2:
				Debug.Log("Ist der Malerei zugewiesen");
				break;
			case 3:
				Debug.Log("Ist der Ausstellungsgestaltung zugewiesen");
				break;
			case 4:
				Debug.Log("Ist der Metallwerkstatt zugewiesen");
				break;
			case 5:
				Debug.Log("Ist der Tischlerei zugewiesen");
				break;
			case 6:
				Debug.Log("Ist dem Lehrsaal zugewiesen");
				break;
			case 7:
				Debug.Log("Ist dem Wohnheim zugewiesen");
				break;
			default:
				Debug.Log("Nicht zugewiesen");
				break;
		}
	}
}
