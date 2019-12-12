using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorScript : MonoBehaviour
{
	public int PolitiklevelScript;

	private float ColorLerp;

    // Start is called before the first frame update
    void Start()
    {
        
	}

    // Update is called once per frame
    void Update()
    {
		PolitiklevelScript = GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel;

		ColorLerp = (float)(PolitiklevelScript/2)/100;

		Debug.Log(ColorLerp);

		//GetComponent<MeshRenderer>().material.color = Color.Lerp(new Color(62, 42, 20), Color.red, ColorLerp);

		if (PolitiklevelScript > 0 && PolitiklevelScript < 100)
		{
			GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.white, ColorLerp*2);
		}
		if(PolitiklevelScript == 0)
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
		}

		if (PolitiklevelScript > 100 && PolitiklevelScript <= 200)
		{
			GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, new Color32(62, 42, 20, 255), (ColorLerp - 0.5f)*2);
		}
	}
}
