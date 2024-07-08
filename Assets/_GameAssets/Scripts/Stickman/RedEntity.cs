using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Stickman;
using UnityEngine;

namespace CrowdRunner.Stickman
{
    public class RedEntity : BaseEntity
    {
        // Crowdpoint üst objyi takip eder.
        void Start()
        {
            base.Start();
            CrowdPoint = transform.parent;
        }
        void Update()
        {
            CrowdPointMove();
        }
    }
}