using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Kamera : MonoBehaviour
    {
		//public GameObject Modul1;
		//public GameObject bauhaushaupt;

		////public GameObject NextModule;

		//public Module Hallol;
		//public bauhausmain Hallil;

		////public Module TheSecondOne;

		//private bool Clicked;
		//private bool OneIsSpawned;

		//public Vector3 NodeTest;

		public float moveSpeed;
		public float rotateSpeed;
		public float height;

        void Start()
        {
			//Modul1 = GameObject.Find("Module");
			//bauhaushaupt = GameObject.Find("bauhausmain");

			//Hallol = Modul1.GetComponent<Module>();
			//Hallil = bauhaushaupt.GetComponent<bauhausmain>();

			//Clicked = false;
			//OneIsSpawned = false;

			moveSpeed = 5;
			rotateSpeed = 45;
			height = 10;
        }

		void Update()
        {
			//if (Input.GetKey(KeyCode.S))
			//{
			//    //this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
			//    this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x + 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 0.1f), this.gameObject.transform.rotation);
			//}

			//if (Input.GetKey(KeyCode.W))
			//{
			//    this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x - 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 0.1f), this.gameObject.transform.rotation);
			//}

			//if (Input.GetKey(KeyCode.D))
			//{
			//    this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x - 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 0.1f), this.gameObject.transform.rotation);
			//}

			//if (Input.GetKey(KeyCode.A))
			//{
			//    this.gameObject.transform.SetPositionAndRotation(new Vector3(this.gameObject.transform.position.x + 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 0.1f), this.gameObject.transform.rotation);
			//}
			var f = transform.position.y;

			transform.Translate(new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime), Space.Self);

			transform.SetPositionAndRotation(new Vector3(transform.position.x, f, transform.position.z), transform.rotation);

			//transform.Rotate(Vector3.up, rotateSpeed * Input.GetAxis("Rotate") * Time.deltaTime, Space.Self);
			transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Input.GetAxis("Rotate") * Time.deltaTime);


			//if (Input.GetKey(KeyCode.JoystickButton4))
			//{
			//	transform.Rotate(Vector3.up, -Mathf.PI / 16);
			//}

			//if (Input.GetKey(KeyCode.Escape))
			//         {
			//             Application.Quit();
			//         }

			//if (Input.GetKey(KeyCode.Space))
			//{
			//    if (Clicked == false)
			//    {
			//        NodeTest = Hallil.Node2;
			//        Hallol.PlaceModule(Hallil.Node1, 3);
			//        Clicked = true;
			//        Hallol.ModuleSet = true;
			//    }
			//    if (Clicked == true && OneIsSpawned == false)
			//    {
			//        GameObject NextModule = Instantiate(GameObject.Find("Module"));
			//        Module TheSecondOne = NextModule.GetComponent<Module>();
			//        //NodeTest = Hallol.Node4;
			//        TheSecondOne.PlaceModule(Hallol.Node2, 4);
			//        TheSecondOne.ModuleSet = true;
			//        OneIsSpawned = true;

			//        GameObject OtherModule = Instantiate(GameObject.Find("Module"));
			//        Module TheThirdOne = OtherModule.GetComponent<Module>();
			//        //NodeTest = TheSecondOne.Node4
			//        TheThirdOne.PlaceModule(Hallol.Node4, 2);
			//        TheSecondOne.ModuleSet = true;
			//    }
			//}
		}
    }
}