using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Module : MonoBehaviour
    {
        public Vector3 Node1;
        public Vector3 Node2;
        public Vector3 Node3;
        public Vector3 Node4;
        public bool Node1Used;
        public bool Node2Used;
        public bool Node3Used;
        public bool Node4Used;
        public bool ModuleSet;

        public Vector3 TargetNodeControll1;
        public Vector3 TargetNodeControll2;
        public Vector3 TargetNodeControll3;
        public Vector3 TargetNodeControll4;

        private void Start()
        {
            Node1Used = false;
            Node2Used = false;
            Node3Used = false;
            Node4Used = false;
            Node1 = Vector3.zero;
            Node2 = Vector3.zero;
            Node3 = Vector3.zero;
            Node4 = Vector3.zero;

            TargetNodeControll1 = Vector3.zero;
            TargetNodeControll2 = Vector3.zero;
            TargetNodeControll3 = Vector3.zero;
            TargetNodeControll4 = Vector3.zero;
        }

        public void PlaceModule(Vector3 TargetNode, int OwnNode)
        {
            if (OwnNode == 1)
            {
                TargetNodeControll1 = TargetNode;

                Node1 = TargetNode;
                this.transform.position = new Vector3(Node1.x, 1, Node1.z - 0.5f);
                Node2 = new Vector3(this.transform.position.x + 0.5f, 1, this.transform.position.z);
                Node3 = new Vector3(this.transform.position.x, 1, this.transform.position.z - 0.5f);
                Node4 = new Vector3(this.transform.position.x - 0.5f, 1, this.transform.position.z);
            }
            if (OwnNode == 2)
            {
                TargetNodeControll2 = TargetNode;

                Node2 = TargetNode;
                this.transform.position = new Vector3(Node2.x - 0.5f, 1, Node2.z);
                Node1 = new Vector3(this.transform.position.x, 1, this.transform.position.z + 0.5f);
                Node3 = new Vector3(this.transform.position.x, 1, this.transform.position.z - 0.5f);
                Node4 = new Vector3(this.transform.position.x - 0.5f, 1, this.transform.position.z);
            }
            if (OwnNode == 3)
            {
                TargetNodeControll3 = TargetNode;

                Node3 = TargetNode;
                this.transform.position = new Vector3(Node3.x, 1, Node3.z + 0.5f);
                Node1 = new Vector3(this.transform.position.x, 1, this.transform.position.z + 0.5f);
                Node2 = new Vector3(this.transform.position.x + 0.5f, 1, this.transform.position.z);
                Node4 = new Vector3(this.transform.position.x - 0.5f, 1, this.transform.position.z);
            }
            if (OwnNode == 4)
            {
                TargetNodeControll4 = TargetNode;

                Node4 = TargetNode;
                this.transform.position = new Vector3(Node4.x + 0.5f, 1, Node4.z);
                Node1 = new Vector3(this.transform.position.x, 1, this.transform.position.z + 0.5f);
                Node2 = new Vector3(this.transform.position.x + 0.5f, 1, this.transform.position.z);
                Node3 = new Vector3(this.transform.position.x, 1, this.transform.position.z - 0.5f);
            }
        }
    }
}
