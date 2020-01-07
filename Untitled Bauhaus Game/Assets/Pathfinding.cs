using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
	public Transform[] points;
	private NavMeshAgent nav;
	private int destPoint;

	public GameObject FastForwardObject;

	// Start is called before the first frame update
	void Start()
    {
		nav = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (FastForwardObject.GetComponent<FastForward>().Mode == FastForward.TimeMode.Pause) //Pause
		{
			nav.speed = 0;
			nav.acceleration = 0;
			nav.angularSpeed = 0;
		}
		if (FastForwardObject.GetComponent<FastForward>().Mode == FastForward.TimeMode.Normal) //Normal
		{
			nav.speed = 3.5f;
			nav.acceleration = 8;
			nav.angularSpeed = 120;
		}
		if (FastForwardObject.GetComponent<FastForward>().Mode == FastForward.TimeMode.FastForward) //Schnell
		{
			nav.speed = 14f;
			nav.acceleration = 32;
			nav.angularSpeed = 480;
		}
		if (!nav.pathPending && nav.remainingDistance < 0.5f)
			GoToNextPoint();
	}
	void GoToNextPoint()
	{
		if (points.Length == 0)
		{
			return;
		}
		nav.destination = points[destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}
}
