using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using CrowdRunner.Crowd;



namespace CrowdRunner.Door
{
    public class DoorManagers : MonoBehaviour
    {
        
        public DoorTriggers DoorPrefab;
        public List<DoorListVariable> DoorListData = new List<DoorListVariable>(); 
        public List<GameObject> DoorList = new List<GameObject>();
        public CrowdNumberOperation crowdNumberOperation;
        
        [System.Serializable]
        public class DoorListVariable
        {
            public int Far;
            public DoorType LDoorType;
            public int LDoorVariable;
            public DoorType RDoorType;
            public int RDoorVariable;

        }

        public GameObject DoorListGet(int i)
        {
            return DoorList[i].gameObject;
        }
        

        void OnValidate()
        {
            EditorApplication.update += DoorGenerator;
        }
        
        
        //Kapıları oluşturuyor
        public void DoorGenerator()
        {
            EditorApplication.update -= DoorGenerator;
            
            CrowdRunner.SuportManagers.EmtiyList(DoorList, transform);
            CrowdRunner.SuportManagers.DestroyList(DoorList);

            if (transform.childCount == 0)
            {
                DoorList.Clear();
                for (int i = 0; i < DoorListData.Count; i++)
                {
                    DoorTriggers newDoor = SpawnDoor($"door_{i}_L",i,null,DoorListData[i].LDoorType,DoorListData[i].LDoorVariable, -2);

                    SpawnDoor($"door_{i}_R",i,newDoor,DoorListData[i].RDoorType,DoorListData[i].RDoorVariable, 2);
                }
            }
        }

        private DoorTriggers SpawnDoor(string doorName, int i, DoorTriggers neightboor, DoorType doorType, int varilable, int offset)
        {
            DoorTriggers newDoor2 = null;
            if (Application.isPlaying)
                newDoor2 = Instantiate(DoorPrefab, this.transform);
            else
                newDoor2 = PrefabUtility.InstantiatePrefab(DoorPrefab,transform) as DoorTriggers;

            newDoor2.name = doorName;
            newDoor2.transform.position = new Vector3(offset, 0, -4 * DoorListData[i].Far);
            newDoor2.doorType = doorType;
            newDoor2.DoorVariable = varilable;
            newDoor2.DoorTextUpDate();
            newDoor2.crowdNumberOperation = crowdNumberOperation;
            if (neightboor != null)
            {
                newDoor2.neighboorDoor = neightboor;
                neightboor.neighboorDoor = newDoor2;
            }
            DoorList.Add(newDoor2.gameObject);

            return newDoor2;
        }
    }
}