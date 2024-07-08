using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CrowdRunner.Stickman
{
    public class RedEntityTrigger : MonoBehaviour
    {
        
        void OnTriggerStay(Collider other)
        {
            //Redin alt obj çalışıyor, Blue çarpıyor ise fokus noktasını blue üzerin getiriyor.
            if (other.CompareTag("StickmanBlue"))
            {
                transform.parent.parent.position = other.transform.position;
            }
        }
    }
}