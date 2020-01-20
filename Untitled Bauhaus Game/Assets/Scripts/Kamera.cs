using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
	public class Kamera : MonoBehaviour
	{
		[SerializeField] float MaxHeight = 30;
		[SerializeField] float MinHeight = 5;

		[SerializeField] float MaxRoamSpace = 100;

		float moveSpeed = 10;
		float actmoveSpeed;
		[SerializeField] float height;

		float zoomSensitivity = 15;
		float freeLookSensitivity = 2;

		bool looking = false;

		public static bool AbleToMove;

		void Start()
		{
			height = 20;

			AbleToMove = true;
		}

		void Update()
		{
			if (AbleToMove)
			{
				#region Shift um schneller zu sein

				var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
				actmoveSpeed = fastMode ? moveSpeed * 3 : moveSpeed;

				#endregion

				#region Steuerung der Kamera mittels Mausrad gedrueckt halten und an den Rand gehen
				//Vector3 targetPos = Vector3.zero;

				//if (Input.GetKey(KeyCode.Mouse2) && AbleToMove)
				//{
				//    if (Input.mousePosition.x >= Screen.width - mDelta)
				//    {
				//        // Move the camera
				//        targetPos.x += Time.unscaledDeltaTime * actmoveSpeed;
				//    }
				//    if (Input.mousePosition.x <= 0 + mDelta)
				//    {
				//        // Move the camera
				//        targetPos.x -= Time.unscaledDeltaTime * actmoveSpeed;
				//    }
				//    if (Input.mousePosition.y >= Screen.height - mDelta)
				//    {
				//        // Move the camera
				//        targetPos.z += Time.unscaledDeltaTime * actmoveSpeed;
				//    }
				//    if (Input.mousePosition.y <= 0 + mDelta)
				//    {
				//        // Move the camera
				//        targetPos.z -= Time.unscaledDeltaTime * actmoveSpeed;
				//    }
				//    transform.Translate(targetPos, Space.Self);
				//}
				#endregion

				#region Steuerung mit WASD
				transform.Translate(new Vector3(actmoveSpeed * Input.GetAxis("Horizontal") * Time.unscaledDeltaTime, 0f, actmoveSpeed * Input.GetAxis("Vertical") * Time.unscaledDeltaTime), Space.Self);

				transform.position = ClampVector3XZ(transform.position/* + new Vector3(actmoveSpeed * Input.GetAxis("Vertical") * Time.unscaledDeltaTime, 0f, actmoveSpeed * Input.GetAxis("Horizontal") * Time.unscaledDeltaTime)*/, -MaxRoamSpace, MaxRoamSpace);

				transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.z), transform.rotation);
				#endregion

				#region Kamera Zoom 
				float axis = Input.GetAxis("Mouse ScrollWheel");

				//Zoom out => axis is negativ, Zoom in => axis is positive

				if (axis != 0)
				{
					if (axis > 0 && height > MinHeight)
					{
						var zoomSensitivity = fastMode ? this.zoomSensitivity * 3 : this.zoomSensitivity;
						transform.position = ClampVector3Y((transform.position + transform.forward * axis * zoomSensitivity), MinHeight, MaxHeight);

						height = transform.position.y;
					}
					else if (axis < 0 && height < MaxHeight)
					{
						var zoomSensitivity = fastMode ? this.zoomSensitivity * 3 : this.zoomSensitivity;
						transform.position = ClampVector3Y((transform.position + transform.forward * axis * zoomSensitivity), MinHeight, MaxHeight);

						height = transform.position.y;
					}					
				}
				#endregion

				#region Free Loking Camera
				if (looking)
				{
					float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
					float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity; //Restricted Free Look to only turn left and right, to enable full free Camera, de-comment this line and use newRotationY in the next line
					transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
				}

				if (Input.GetKeyDown(KeyCode.Mouse1))
				{
					StartLooking();
				}
				else if (Input.GetKeyUp(KeyCode.Mouse1))
				{
					StopLooking();
				}
				#endregion
			}
		}

		Vector3 ClampVector3Y(Vector3 input, float min, float max)
		{
			input.y = Mathf.Clamp(input.y, min, max);

			return input;
		}

		Vector3 ClampVector3XZ(Vector3 input, float min, float max)
		{
			input.x = Mathf.Clamp(input.x, min, max);
			input.z = Mathf.Clamp(input.z, min, max);

			return input;

		}

		public void ChangeCameraSpeed(float newSpeed)
		{
			moveSpeed = newSpeed;
		}

		void OnDisable()
		{
			StopLooking();
		}

		/// <summary>
		/// Enable free looking.
		/// </summary>
		public void StartLooking()
		{
			looking = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		/// <summary>
		/// Disable free looking.
		/// </summary>
		public void StopLooking()
		{
			looking = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}