using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Crowd;
using CrowdRunner.Stickman;
using UnityEngine;

namespace CrowdRunner.Stickman
{
    public class BlueEntity : BaseEntity
    {
        // Bluelar CrowdPoint takip eder.
        protected override void Start()
        {
            base.Start();

            // burayı nasıl çözeceğimi bulamadım.
            CrowdPoint = GameObject.Find("CrowdPoint").transform;
        }

        public override void death()
        {
            if (GameObject.Find("CrowdBlue").TryGetComponent<CrowdNumberOperation>(out CrowdNumberOperation crowdNumberOperation))
                crowdNumberOperation.StickManListRemove(gameObject);
            
            base.death();
        }

        void Update()
        {
            CrowdPointMove();
        }
    }
}