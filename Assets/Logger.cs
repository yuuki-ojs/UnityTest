using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class Logger : MonoBehaviour
    {
        UnityEngine.Logger logger;

        // Use this for initialization
        void Start()
        {
            logger = new UnityEngine.Logger(new TestProject.LogHandler());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
