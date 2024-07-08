using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrowdRunner.Crowd
{
    public class CrowdMove : MonoBehaviour
    {
        public float Speed = 3;

        public bool Walking = true;
        public Transform CrowdPointT;

        private Vector3 direction = Vector3.zero;

        void Start()
        {
            //CrowdPointT = GameObject.Find("CrowdPoint").transform;
        }

        void Update()
        {
            if (Walking) CrowdMoveandWalking();
        }

        public void CrowdMoveandWalking()
        {
            direction = new Vector3(0, 0, -Speed) * Time.deltaTime;
            transform.position += direction;

            //Parmak ile konturol için
            if (Input.touchCount > 0)
            {
                Touch finger = Input.GetTouch(0);
                if (finger.phase == TouchPhase.Moved || finger.phase == TouchPhase.Began || finger.phase == TouchPhase.Stationary)
                {
                    CrowdPointT.position = new Vector3(-((finger.position.x / Screen.width) * 8) + 4, CrowdPointT.position.y, CrowdPointT.position.z);
                }
            }
            //Mouse ile konturol için
            else
            {
                CrowdPointT.position = new Vector3(-((Input.mousePosition.x / Screen.width) * 8) + 4,
                    CrowdPointT.position.y, CrowdPointT.position.z);
            }
        }
    }
}