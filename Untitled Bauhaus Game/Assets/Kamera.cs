using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Kamera : MonoBehaviour
    {
        public GameObject Modul1;
        public GameObject bauhaushaupt;

        public GameObject NextModule;

        public Module Hallol;
        public bauhausmain Hallil;

        public Module TheSecondOne;

        private bool Clicked;
        private bool OneIsSpawned;

        //public Vector3 NodeTest;

        void Start()
        {
            Modul1 = GameObject.Find("Module");
            bauhaushaupt = GameObject.Find("bauhausmain");

            Hallol = Modul1.GetComponent<Module>();
            Hallil = bauhaushaupt.GetComponent<bauhausmain>();

            Clicked = false;
            OneIsSpawned = false;
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.S))
            {
                //this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
                this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x + 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 0.1f), this.gameObject.transform.rotation);
            }

            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x - 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 0.1f), this.gameObject.transform.rotation);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x - 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 0.1f), this.gameObject.transform.rotation);
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x + 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 0.1f), this.gameObject.transform.rotation);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (Clicked == false)
                {
                    //NodeTest = Hallil.Node3;
                    Hallol.PlaceModule(Hallil.Node1, 1);
                    Clicked = true;
                    Hallol.ModuleSet = true;
                }
                if (Clicked == true && OneIsSpawned == false)
                {
                    NextModule = Instantiate(GameObject.Find("Module"));
                    TheSecondOne = NextModule.GetComponent<Module>();
                    //NodeTest = Hallol.Node4;
                    TheSecondOne.PlaceModule(Hallol.Node3, 1);
                    TheSecondOne.ModuleSet = true;
                    OneIsSpawned = true;
                }
            }
        }
    }
}