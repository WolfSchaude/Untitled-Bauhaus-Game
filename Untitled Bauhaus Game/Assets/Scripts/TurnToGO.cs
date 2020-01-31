using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToGO : MonoBehaviour
{
    [SerializeField] Transform TurnToTarget;

    private void Awake()
    {
        if (TurnToTarget == null)
        {
            TurnToTarget = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }
        
    void Update()
    {
        transform.LookAt(TurnToTarget, Vector3.down);

        var x = transform.rotation.eulerAngles;

        x.x += 180;

        transform.rotation = Quaternion.Euler(x);
    }
}
