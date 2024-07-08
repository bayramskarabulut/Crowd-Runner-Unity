using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CrowdRunner.Stickman
{
    public class BlueEntityTrigger : MonoBehaviour
    {
        //Stickman bluenun altında çalışır, red ile çarparsa kendisini ve karşısındakini siller.
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StickmanRed"))
            {
                if (other.TryGetComponent(out RedEntity redEntity))
                {
                    redEntity.death();
                }
                transform.parent.GetComponent<BlueEntity>().death();
            }
        }
    }
}