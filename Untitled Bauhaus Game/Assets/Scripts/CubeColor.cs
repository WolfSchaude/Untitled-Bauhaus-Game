using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame 
{
    public class CubeColor : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}