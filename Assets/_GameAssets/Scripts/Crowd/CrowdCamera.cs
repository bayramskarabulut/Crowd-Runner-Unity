using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrowdRunner.Crowd
{
    public class CrowdCamera : MonoBehaviour
    {
        public Vector3 FirstPoint = new Vector3(0, 6, 3.35f);
        public Vector3 FinalPoint = new Vector3(0, 10, 3.35f);

        public bool CameraMoveOn;
        public CrowdMove crowdMove;

        void Start()
        {

        }
        void Update()
        {
            if (CameraMoveOn)
            {
                CameraMove();
            }
        }
        
        public void CameraMove()
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, FinalPoint, Time.deltaTime);
            if (transform.localPosition == FinalPoint)
            {
                CameraMoveOn = false;
                crowdMove.Walking = true;
            }
        }
    }
}