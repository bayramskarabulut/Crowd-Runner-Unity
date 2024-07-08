using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Stickman;
using UnityEngine;
using System;

namespace CrowdRunner.Crowd
{
    public class CrowdNumberOperation : MonoBehaviour
    {
        private List<GameObject> StickManList = new List<GameObject>();
        public GameObject BlueStickMan;
        public int BlueStickManSpeed = 10;
        private GameObject NewStickMan;
        public TextMesh TextNumber;
        public LoseAndWin loseAndWin;


        void Start()
        {
            //ilk başladığında stickmanleri listeye kaydediyor
            foreach(Transform i in transform)
            {
                StickManList.Add(i.gameObject);
            }
            TextNumberUpDate();
        }

        
        //Stickmanin sayısını ekrana günceliyor
        public void TextNumberUpDate()
        {
            TextNumber.text = StickManList.Count.ToString();
            if (0 >= StickManList.Count) loseAndWin.lose();
        }
        


        
        //Ölen stickmanlerin listeden siliniyor
        public void StickManListRemove(GameObject gameObject)
        {
            StickManList.Remove(gameObject);
            TextNumberUpDate();
        }


        //Kapılardan geçtiğinde stickmanin olması gereken adete yapıyor
        public void Add(int AddNumber)
        {
            if (AddNumber > 0)
            {
                
                for (int i = 0; i < AddNumber; i++)
                {
                    //NewStickMan positionı değiştirmeye çalıştığımda değişmiyor. Bende yeni bir gameobject üretip altına ekliyorum.
                    GameObject NewStartPoint = new GameObject();
                    NewStartPoint.transform.parent = transform;
                    NewStartPoint.transform.position = transform.GetChild(0).position + (Vector3.right * UnityEngine.Random.Range(-1.8f, 1.8f)) + (Vector3.forward * UnityEngine.Random.Range(-1.8f, 1.8f));
                    
                    NewStickMan = Instantiate(BlueStickMan, NewStartPoint.transform);
                    if (NewStickMan.TryGetComponent<BlueEntity>(out BlueEntity blueEntity)) 
                        blueEntity.Speed = BlueStickManSpeed;
                    StickManList.Add(NewStickMan);
                }
            }
            TextNumberUpDate();
            
        }
        public void Subtract(int SubNumber)
        {
            if (SubNumber > 0 && StickManList.Count - SubNumber > 0)
            {

                for (int i = StickManList.Count - 1; SubNumber > 0; SubNumber--,  i--)
                {
                    Destroy(StickManList[i]);
                    StickManList.RemoveAt(i);
                }
            }
            else
            {
                for (int i = StickManList.Count - 1; i > 0; i--)
                {
                    Destroy(StickManList[i]);
                    StickManList.RemoveAt(i);
                }
            }
            TextNumberUpDate();
            
        }


        public void Divide(int DivNumber)
        {
            if (DivNumber > 0) Subtract(StickManList.Count - Mathf.CeilToInt(StickManList.Count / DivNumber));
        }

        public void Multiplication(int MulNumber)
        {
            if (MulNumber > 0) Add(StickManList.Count * (MulNumber-1));
        }
    }
}