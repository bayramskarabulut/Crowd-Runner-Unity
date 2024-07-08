using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace CrowdRunner.Way
{    
    public class WayManager : MonoBehaviour
    {
        
        public GameObject WayPrefab; 

        public int WayFars = 0;
        public GameObject FinalGameObject;
        private List<GameObject> WayList = new List<GameObject>();
    
        void OnValidate()
        {
            EditorApplication.update += WayGenerator;
        }

        //Yol oluşturuyor.
        public void WayGenerator()
        {
            if (WayList.Count != 0 || transform.childCount == 0)
            {
                
                EditorApplication.update -= WayGenerator;
                

                if (WayFars*2 > WayList.Count)
                {
                    for (int i = WayList.Count/2; i < WayFars; i++)
                    {
                        for (int j = 0; j <= 1; j++)
                        {
                            GameObject newWay = Instantiate(WayPrefab, this.transform);
                            newWay.name = $"WayPoint_{i}_{j}";
                            newWay.transform.position = new Vector3(-2+(4*j), 0, -i * 4);
                            WayList.Add(newWay);
                        }
                    }
                }
                else
                {
                    for (int i = WayList.Count - 1; i >= WayFars*2; i--)
                    {
                        DestroyImmediate(WayList[i]);
                        WayList.RemoveAt(i);
                    }
                }
                FinalGameObject.transform.position = new Vector3(0, 2, - 4 + WayList[WayList.Count-1].transform.position.z);
            }
            else
            {
                foreach (Transform i in transform)
                    {
                        WayList.Add(i.gameObject);
                    }
            }
            
        }
    }
}