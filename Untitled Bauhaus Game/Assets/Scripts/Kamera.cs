using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class Kamera : MonoBehaviour
    {
        float moveSpeed;
        float actmoveSpeed;
        float rotateSpeed;
        float height;
        float mDelta;

        //public GameObject BuildManager;
        //public buildingsystemmanager BuildingSystemManager;

        //private bool LongKeyDown;
        public static bool AbleToMove;

        void Start()
        {
            moveSpeed = 10;
            rotateSpeed = 90;
            height = 10;
            mDelta = 10;

            //BuildManager = GameObject.Find("buildingsystemmanager"); 
            //BuildingSystemManager = BuildManager.GetComponent<buildingsystemmanager>();

            AbleToMove = true;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                actmoveSpeed = moveSpeed * 2;
            }
            else actmoveSpeed = moveSpeed;

            Vector3 targetPos = Vector3.zero;

            if (Input.GetKey(KeyCode.Mouse2) && AbleToMove)
            {
                if (Input.mousePosition.x >= Screen.width - mDelta)
                {
                    // Move the camera
                    targetPos.x += Time.unscaledDeltaTime * actmoveSpeed;
                }
                if (Input.mousePosition.x <= 0 + mDelta)
                {
                    // Move the camera
                    targetPos.x -= Time.unscaledDeltaTime * actmoveSpeed;
                }
                if (Input.mousePosition.y >= Screen.height - mDelta)
                {
                    // Move the camera
                    targetPos.z += Time.unscaledDeltaTime * actmoveSpeed;
                }
                if (Input.mousePosition.y <= 0 + mDelta)
                {
                    // Move the camera
                    targetPos.z -= Time.unscaledDeltaTime * actmoveSpeed;
                }
            }

            if (AbleToMove)
            {
                transform.Translate(targetPos, Space.Self);

                transform.Translate(new Vector3(actmoveSpeed * Input.GetAxis("Horizontal") * Time.unscaledDeltaTime, 0f, actmoveSpeed * Input.GetAxis("Vertical") * Time.unscaledDeltaTime), Space.Self);

                transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.z), transform.rotation);

                transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Input.GetAxis("Rotate") * Time.unscaledDeltaTime);

                //Change camera height with Mouse Scroolwheel or Buttons
                var d = Input.GetAxis("Mouse ScrollWheel");
                if ((d > 0f || Input.GetKeyDown(KeyCode.Space)) && height < 25)
                {
                    height++;
                }
                else if ((d < 0f || Input.GetKeyDown(KeyCode.LeftControl))&& height > 3)
                {
                    height--;
                }

            }

            //if (Input.GetKey(KeyCode.Space))
            //{
            //    if (LongKeyDown == false)
            //    {
            //        BuildingSystemManager.PlaceWorkshop(1);
            //        LongKeyDown = true;
            //    }
            //}

            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    LongKeyDown = false;
            //}
        }

        public void ChangeCameraSpeed(float newSpeed)
        {
            moveSpeed = newSpeed;
        }
    }
}