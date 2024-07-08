using System;
using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Crowd;
using UnityEngine;



namespace CrowdRunner.Stickman
{
    public class BaseEntity : MonoBehaviour
    {
        public int Speed = 10;
        private Vector3 direction = Vector3.zero;
        public CharacterController characterController;
        
        public Transform CrowdPoint;
        
        protected virtual void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        public virtual void death()
        {
            Destroy(gameObject);
        }

        //Stickmanler bir CrowdPointi takip eder
        public void CrowdPointMove()
        {
            direction = (CrowdPoint.position - transform.position).normalized * Speed * Time.deltaTime;
            
            if (direction != Vector3.zero) characterController.Move(direction);
        }
    }
}