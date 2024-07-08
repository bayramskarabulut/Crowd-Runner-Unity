using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace CrowdRunner.Barrier
{
    public class BarriersManagers : MonoBehaviour
    {
        public Material OneHitMaterial;
        public List<GameObject> BarrierObj;
        [System.Serializable]
        public class BarriersListVariable
        {
            public int Far;
            public BarrierObjPosition objPosition;
            public BarriersObjType ObjType;
            public bool OneHit;
        }
        
        

        public  List<BarriersListVariable> barriersListData = new List<BarriersListVariable>();
        private  List<GameObject> barriersList = new List<GameObject>();
        private GameObject NewBarriers;
        void OnValidate()
        {
            EditorApplication.update += BarrierGenGenerator;
        }

        public void BarrierGenGenerator()
        {  
            EditorApplication.update -= BarrierGenGenerator;

            CrowdRunner.SuportManagers.EmtiyList(barriersList, transform);
            CrowdRunner.SuportManagers.DestroyList(barriersList);

            if (transform.childCount == 0)
            {
                barriersList.Clear();
                for (int i = 0; i < barriersListData.Count; i++)
                {
                    if (Application.isEditor)
                        NewBarriers = Instantiate(BarrierObj[Convert.ToInt32(barriersListData[i].ObjType)], transform);
                    else
                        NewBarriers = PrefabUtility.InstantiatePrefab(BarrierObj[Convert.ToInt32(barriersListData[i].ObjType)], transform) as GameObject;


                    NewBarriers.name = $"Barriers_{i}";
                    NewBarriers.transform.position = new Vector3(Convert.ToInt32(barriersListData[i].objPosition), 1, -barriersListData[i].Far*4);
                    
                    if (barriersListData[i].OneHit)
                    {
                        if (NewBarriers.TryGetComponent<Barriers>(out Barriers barriers))
                            barriers.OneHitSet(barriersListData[i].OneHit);
                        if (NewBarriers.TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
                            meshRenderer.material = OneHitMaterial;
                    }

                    barriersList.Add(NewBarriers);
                }
            }
        }
    }
}