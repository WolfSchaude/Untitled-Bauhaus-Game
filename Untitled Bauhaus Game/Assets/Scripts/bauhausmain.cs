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
        public Vector3 Node4;
        public bool Node1Used;
        public bool Node2Used;
        public bool Node4Used;

        void Start()
        {
            Node1Used = false;
            Node2Used = false;
            Node4Used = false;

            Node1.x = this.gameObject.transform.position.x;
            Node1.y = this.gameObject.transform.position.y - 0.75f;
            Node1.z = this.gameObject.transform.position.z - 0.75f;

            Node2.x = this.gameObject.transform.position.x - 0.5f;
            Node2.y = this.gameObject.transform.position.y - 0.75f;
            Node2.z = this.gameObject.transform.position.z - 0.25f;

            Node4.x = this.gameObject.transform.position.x + 0.5f;
            Node4.y = this.gameObject.transform.position.y - 0.75f;
            Node4.z = this.gameObject.transform.position.z - 0.25f;
        }
    }
}
