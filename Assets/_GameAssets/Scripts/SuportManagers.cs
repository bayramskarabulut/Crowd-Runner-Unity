using System.Collections;
using System.Collections.Generic;
using CrowdRunner.Door;
using UnityEngine;

namespace CrowdRunner
{
    public class SuportManagers : MonoBehaviour
    {
        public static void EmtiyList(List<GameObject> ThisList, Transform ThisTransform)
        {
            if (ThisList.Count == 0)
            {
                foreach(Transform i in ThisTransform)
                {
                    ThisList.Add(i.gameObject);
                }
            }

        }

        public static void DestroyList(List<GameObject> ThisList)
        {
            foreach (var obj in ThisList)
            {
                if (obj != null)
                {
                    if (Application.isEditor)
                    {
                        DestroyImmediate(obj.gameObject);
                    }
                    else
                    {
                        Destroy(obj.gameObject);
                    }
                }
            }
        }
    }
}