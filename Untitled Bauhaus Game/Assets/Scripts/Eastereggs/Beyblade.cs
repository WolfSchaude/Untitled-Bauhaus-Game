using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beyblade : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
		transform.RotateAround(transform.position, Vector3.right, 360 * Time.unscaledDeltaTime);
	}
}
