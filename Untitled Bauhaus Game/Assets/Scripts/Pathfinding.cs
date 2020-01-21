using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
	public Transform[] points;
	private NavMeshAgent nav;
	private int destPoint;

	public NewTimeKeeper TimeKeeperObject;

	// Start is called before the first frame update
	void Start()
    {
		nav = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (TimeKeeperObject.Mode == NewTimeKeeper.TimeMode.Pause) //Pause
		{
			//nav.speed = 0;
			//nav.acceleration = 0;
			//nav.angularSpeed = 0;
			nav.isStopped = true;

		}
		if (TimeKeeperObject.Mode == NewTimeKeeper.TimeMode.Normal) //Normal
		{
			nav.isStopped = false;

			nav.speed = 3.5f;
			nav.acceleration = 8;
			nav.angularSpeed = 120;
		}
		if (TimeKeeperObject.Mode == NewTimeKeeper.TimeMode.FastForward) //Schnell
		{
			nav.isStopped = false;

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
