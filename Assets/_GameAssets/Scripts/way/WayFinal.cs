using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CrowdRunner.Crowd;
using CrowdRunner.Stickman;
using UnityEngine;

namespace CrowdRunner
{
    public class final : MonoBehaviour
    {
        private bool FinalFight = false;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "StickmanBlue")
            {
                FinalFight = true;
                GameObject.Find("Main Camera").GetComponent<CrowdCamera>().CameraMoveOn = true;
                GameObject.Find("Crowd Main").GetComponent<CrowdMove>().Walking = false;
            }
        }

        void Update()
        {
            if (FinalFight)
            {
                CrowdFinalFight();
            }
        }

        public void CrowdFinalFight()
        {
            GameObject.Find("RedCrowdText").GetComponent<TextMesh>().text = GetComponentsInChildren<RedEntity>().Count().ToString();
            if (GetComponentsInChildren<RedEntity>().Count() <= 0) GameObject.Find("Main Camera").GetComponent<LoseAndWin>().win();
        }
    }
}
