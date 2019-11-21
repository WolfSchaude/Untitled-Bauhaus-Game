using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Kamera : MonoBehaviour
    {
        public GameObject Modul;
        public GameObject bauhaushaupt;

        public Module Hallol;
        public bauhausmain Hallil;

        private bool Clicked;
        private bool OneIsSpawned;

        void Start()
        {
            Modul = GameObject.Find("Module");
            bauhaushaupt = GameObject.Find("bauhausmain");

            Hallol = Modul.GetComponent<Module>();
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
                    Hallol.PlaceObject(Hallil.Node1);
                    Clicked = true;
                }
                if (Clicked == true && OneIsSpawned == false)
                {
                    GameObject NextModule = Instantiate(GameObject.Find("Module"));
                    Module TheSecondOne = NextModule.GetComponent<Module>();
                    TheSecondOne.PlaceObject(Hallol.Node1);
                    OneIsSpawned = true;
                }
            }
        }
    }
}