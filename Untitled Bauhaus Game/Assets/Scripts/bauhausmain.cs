using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class bauhausmain : MonoBehaviour
    {
        public static bauhausmain Instance = null;

        public Vector3 Node1;
        public Vector3 Node2;
        public Vector3 Node3;

        void Start()
        {
            Node1.x = this.gameObject.transform.position.x;
            Node1.y = this.gameObject.transform.position.y - 0.75f;
            Node1.z = this.gameObject.transform.position.z - 0.75f;
        }
    }
}
