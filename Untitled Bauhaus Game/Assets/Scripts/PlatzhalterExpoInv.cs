using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatzhalterExpoInv : MonoBehaviour
{
    public void SelfDestruct()
    {
        Debug.Log("I'll know initiate self destruction..... 3, 2, 1, bleeeeeeeeeeeeeeeeeeeppp!");
        Destroy(gameObject);
    }
}
