using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToGO : MonoBehaviour
{
    [SerializeField] Transform TurnToTarget;

    void Update()
    {
        Vector3 lookPoint = transform.position - TurnToTarget.position;
        lookPoint.y = TurnToTarget.position.y;
        transform.LookAt(lookPoint);

        //transform.LookAt(TurnToTarget);
    }
}
