using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrowdRunner.Crowd;

namespace CrowdRunner
{
    public class LoseAndWin : MonoBehaviour
    {
        public CrowdMove crowdMove;
        public void win()
        {
            transform.GetChild(0).gameObject.SetActive(true); 
            crowdMove.Walking = false;
        }

        public void lose()
        {
            transform.GetChild(1).gameObject.SetActive(true); 
            crowdMove.Walking = false;
        }
    }
}