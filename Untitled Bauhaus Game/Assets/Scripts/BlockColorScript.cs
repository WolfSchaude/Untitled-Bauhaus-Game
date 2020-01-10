using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorScript : MonoBehaviour
{
	public Politikmeter PolitikmeterScript;

	private float ColorLerp;

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
		ColorLerp = (float)(PolitikmeterScript.Politiklevel / 2)/100;

		//GetComponent<MeshRenderer>().material.color = Color.Lerp(new Color(62, 42, 20), Color.red, ColorLerp);

		if (PolitikmeterScript.Politiklevel > 0 && PolitikmeterScript.Politiklevel < 100)
		{
			GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.white, ColorLerp*2);
		}
		if(PolitikmeterScript.Politiklevel == 0)
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
		}

		if (PolitikmeterScript.Politiklevel > 100 && PolitikmeterScript.Politiklevel <= 200)
		{
			GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, new Color32(108, 71, 15, 255), (ColorLerp - 0.5f)*2);
		}
	}
}
