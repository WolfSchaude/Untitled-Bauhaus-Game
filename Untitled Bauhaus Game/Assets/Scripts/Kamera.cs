using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Kamera : MonoBehaviour
    {
		float moveSpeed;
		float rotateSpeed;
		float height;

        public GameObject BuildManager;
        public buildingsystemmanager BuildingSystemManager;

        private bool LongKeyDown;
		bool AbleToMove;

        void Start()
        {
			moveSpeed = 5;
			rotateSpeed = 90;
			height = 10;

            BuildManager = GameObject.Find("buildingsystemmanager"); //Eigennotiz: nach knapp 6 Stunden, bei GameObject.Find den Assetnamen und nicht den Klassennamen nutzen!
            BuildingSystemManager = BuildManager.GetComponent<buildingsystemmanager>();

			AbleToMove = true;
        }

		void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = 10;
            }
            else moveSpeed = 5;

			if (AbleToMove)
			{
				transform.Translate(new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.unscaledDeltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.unscaledDeltaTime), Space.Self);

				transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.z), transform.rotation);

				transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Input.GetAxis("Rotate") * Time.unscaledDeltaTime);
			}

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (LongKeyDown == false)
                {
                    BuildingSystemManager.PlaceWorkshop(1);
                    LongKeyDown = true;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                LongKeyDown = false;
            }
        }

		public void ToggleMovement()
		{
			AbleToMove = !AbleToMove;
		}
    }
}