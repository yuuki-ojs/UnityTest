using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq.Expressions;
using System;
using System.Runtime.CompilerServices;

namespace TestProject
{
    public class AbstractSingletonManager<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject gObj = new GameObject("");
                    instance = gObj.AddComponent<T>();
                    instance.gameObject.transform.name = instance.GetType().Name;// typeof(T).ToString();


                    if (instance == null)
                    {
                        Debug.LogError(typeof(T) + " is nothing");
                    }
                }

                return instance;
            }
        }
    }
}
