using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Kamera : MonoBehaviour
    {
		public float moveSpeed;
		public float rotateSpeed;
		public float height;

        public GameObject BuildManager;
        public buildingsystemmanager BuildingSystemManager;

        void Start()
        {
			moveSpeed = 5;
			rotateSpeed = 45;
			height = 10;

            BuildManager = GameObject.Find("buildingsystemmanager"); //Eigennotiz: nach knapp 6 Stunden, bei GameObject.Find den Assetnamen und nicht den Klassennamen nutzen!
            BuildingSystemManager = BuildManager.GetComponent<buildingsystemmanager>();
        }

		void Update()
        {
			transform.Translate(new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.unscaledDeltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.unscaledDeltaTime), Space.Self);

			transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.z), transform.rotation);

			transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Input.GetAxis("Rotate") * Time.unscaledDeltaTime);

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                BuildingSystemManager.PlaceWorkshop(1);
            }
		}
    }
}