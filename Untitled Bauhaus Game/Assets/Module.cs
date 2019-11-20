using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Module : MonoBehaviour
    {
        public static Module Instance = null;

        public Vector3 Node1;
        public Vector3 Node2;
        public Vector3 Node3;
        public Vector3 Node4;

        public void PlaceObject(Vector3 OtherNode)
        {
            Node3 = OtherNode;
            this.transform.position = new Vector3(Node3.x,1 ,Node3.z - 0.5f);
            Node1.x = Node3.x;
            Node1.y = Node3.y;
            Node1.z = Node3.z - 1f;
            //this.transform.SetPositionAndRotation(new Vector3(Node3.x, Node3.y, Node3.z - 1f), this.transform.rotation);
        }
    }
}
