using System;
using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Crowd;
using UnityEngine;

namespace CrowdRunner.Door
{
    public enum DoorType
    {
        add,
        subtract,
        multiplication,
        divide
    }

    public class DoorTriggers : MonoBehaviour
    {
        public DoorType doorType;
        public DoorTriggers neighboorDoor;
        public BoxCollider boxCollider;

        public TextMesh textMesh;
        public int DoorVariable;
        public CrowdNumberOperation crowdNumberOperation;

        void Start()
        {
        }

        void OnValidate()
        {
            DoorTextUpDate();
        }


        //Kapıdaki sayıyı günceller.
        public void DoorTextUpDate()
        {
            textMesh.text = DoorTypeString() + DoorVariable.ToString();
        }

        //Veride karşılık gelen sembolü dündürür.
        private string DoorTypeString()
        {
            switch (doorType)
            {
                case DoorType.add:
                    return "+";
                case DoorType.subtract:
                    return "-";
                case DoorType.multiplication:
                    return "x";
                case DoorType.divide:
                    return "÷";
            }

            return ":)";
        }

        //Kapıya çarpan objeleri konturol edip gerekli fonksuyonu çalıştırır.
        void OnCollisionEnter(Collision collision) // ONTRIGGERENTER KULLANMAK DAHA IYI OLURDU
        {
            
            if (collision.collider.CompareTag("StickmanBlue"))
            {
                boxCollider.enabled = false;
                neighboorDoor.boxCollider.enabled = false;

                switch (doorType)
                {
                    case DoorType.add:
                        crowdNumberOperation.Add(DoorVariable);
                        break;
                    case DoorType.subtract:
                        crowdNumberOperation.Subtract(DoorVariable);
                        break;
                    case DoorType.multiplication:
                        crowdNumberOperation.Multiplication(DoorVariable);
                        break;
                    case DoorType.divide:
                        crowdNumberOperation.Divide(DoorVariable);
                        break;
                }
                
            }
        }
    }
}