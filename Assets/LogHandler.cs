using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class LogHandler : ILogHandler
    {

        const String LF = "¥n";

        [SerializeField]
        Text logText;

        public LogHandler()
        {
            //デバッグの場合のみ
            if (Debug.isDebugBuild)
            {
                // ログが出力されたときのイベントに画面出力を追加
                Application.logMessageReceived += (string condition, string stackTrace, LogType type) =>
                {
                    logText.text += condition + LF;
                    Debug.Log("stackTrace : " + stackTrace);
                };
            }
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="exception">Exception.</param>
        /// <param name="context">Context.</param>
        public void LogException(Exception exception, UnityEngine.Object context)
        {
            Debug.unityLogger.LogException(exception, context);
        }

        /// <summary>
        /// Logs the format.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="context">Context.</param>
        /// <param name="format">Format.</param>
        /// <param name="args">Arguments.</param>
        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            Debug.unityLogger.logHandler.LogFormat(logType, context, format, args);
        }

    }
}