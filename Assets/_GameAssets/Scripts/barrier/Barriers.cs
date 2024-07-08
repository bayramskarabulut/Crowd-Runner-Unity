using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Stickman;
using UnityEngine;


namespace CrowdRunner.Barrier
{
    public enum BarriersObjType
    {
        Cylinder = 0,
        Cube = 1
    }

    public enum BarrierObjPosition
    {
        Left = 2,
        Mide = 0,
        Right = -2
    }

    public class Barriers : MonoBehaviour
    {
        //Bu açık olursa tek stickman öldürüyor.
        private bool OneHit = false;

        public void OneHitSet(bool i)
        {
            OneHit = i;
        }


        //Çarpan obje blue ise death fonksiyonu çalıştırır
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "StickmanBlue")
            {
                if(other.TryGetComponent<BlueEntity>(out BlueEntity blueEntity))
                    blueEntity.death();
                if (OneHit) Destroy(gameObject);
            }
        }
    }
}