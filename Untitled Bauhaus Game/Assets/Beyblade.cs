using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beyblade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//InvokeRepeating("Morph", 2, 3);
	}

    // Update is called once per frame
    void Update()
    {
		transform.RotateAround(transform.position, Vector3.up, 360 * Time.unscaledDeltaTime);
		//transform.RotateAround(transform.localPosition, Vector3.forward, 90 * Time.deltaTime);
	}

	void Morph()
	{
		transform.localScale = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f));
	}
}
