using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

namespace TestProject
{
    public class LogManager : TestProject.AbstractSingletonManager<LogManager>
    {
        private static UnityEngine.Logger logger;

        private void Awake()
        {
            logger = new UnityEngine.Logger(new TestProject.LogHandler());
        }

        private LogManager()
        {
            Debug.Log("Instanced " + this.GetType());
        }

        public UnityEngine.Logger getLogger()
        {
            return logger;
        }
    }
}
