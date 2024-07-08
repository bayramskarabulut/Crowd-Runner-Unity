using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CrowdRunner.Crowd
{
    public class RedCrowdManagers : MonoBehaviour
    {
        public int TriggerZoneSize = 8;
        [System.Serializable]
        public class RedCrowdListVariable
        {
            public int Far;
            public int CrowdNumber;
        }

        public List<RedCrowdListVariable> RedCrowdListDate = new List<RedCrowdListVariable>();
        private List<GameObject> RedCrowdList = new List<GameObject>();

        public GameObject RedStickman;
        void OnValidate()
        {
            EditorApplication.update += RedCrowdGenerator;
        }

        //Leveldeki RedCrowd oluşturuyor
        public void RedCrowdGenerator()
        {
            EditorApplication.update -= RedCrowdGenerator;

            CrowdRunner.SuportManagers.EmtiyList(RedCrowdList, transform);
            CrowdRunner.SuportManagers.DestroyList(RedCrowdList);

            if (transform.childCount == 0)
            {
                RedCrowdList.Clear();
                
                for (int i = 0; i < RedCrowdListDate.Count; i++)
                {
                    GameObject NewRedCrowd = new GameObject();
                    NewRedCrowd.transform.parent = transform;
                    NewRedCrowd.name = $"RedCrowd_{i}";
                    NewRedCrowd.transform.position = new Vector3(0, 1, -RedCrowdListDate[i].Far * 4 + transform.position.z);
                    RedCrowdList.Add(NewRedCrowd);
                    for (int j = 0; j < RedCrowdListDate[i].CrowdNumber; j++)
                    {
                        GameObject NewRedStickman = Instantiate(RedStickman, NewRedCrowd.transform);
                        NewRedStickman.transform.position += (Vector3.right * Random.Range(-1.8f, 1.8f)) + (Vector3.forward * Random.Range(-1.8f, 1.8f));
                        if (NewRedStickman.transform.GetChild(0).TryGetComponent<SphereCollider>(out SphereCollider sphereCollider))
                            sphereCollider.radius = TriggerZoneSize;
                    }
                }
            }

        }
    }
}