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

        void Start()
        {
			moveSpeed = 5;
			rotateSpeed = 45;
			height = 10;
        }

		void Update()
        {
			transform.Translate(new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.unscaledDeltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.unscaledDeltaTime), Space.Self);

			transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.z), transform.rotation);

			transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Input.GetAxis("Rotate") * Time.unscaledDeltaTime);
		}
    }
}