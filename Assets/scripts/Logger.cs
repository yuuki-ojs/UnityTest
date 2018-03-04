using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class Logger : MonoBehaviour
    {
        UnityEngine.Logger logger;
        [SerializeField]
        float gameFrameSec = 0.0f;

        // Use this for initialization
        void Start()
        {
            logger = new UnityEngine.Logger(new TestProject.LogHandler());
        }

        // Update is called once per frame
        void Update()
        {
            gameFrameSec += Time.deltaTime;

            if(gameFrameSec > 2.0f){
                logger.Log("2秒ごとに出力");
                gameFrameSec = 0.0f;
            }
        }
    }
}
