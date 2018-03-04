using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Experimental.UIElements;
using System.Net;

namespace TestProject
{
    public class TestConnector : MonoBehaviour
    {
        const long NOT_FOUND = 404;

        // Use this for initialization
        void Start()
        {
            // ネットワークマネージャーを付与
            //this.gameObject.AddComponent<NetworkManager>();
            Debug.Log("Start.");
            Debug.Log(HttpStatusCode.NotFound);
            Debug.Log(HttpStatusCode.NotFound.GetType());


        }

        // Update is called once per frame
        void Update()
        {
            // Zキー押下時にGETリクエストを発行
            if (Input.GetKeyDown(KeyCode.Z))
            {
                this.StartGetRequest();
            }

        }

        /// <summary>
        /// Starts the get request.
        /// </summary>
        void StartGetRequest()
        {
            StartCoroutine(this.GetRequestCoroutine());
        }

        /// <summary>
        /// Gets the request coroutine.
        /// </summary>
        /// <returns>The request coroutine.</returns>
        IEnumerator GetRequestCoroutine()
        {
            // GETリクエストを生成
            UnityWebRequest request = UnityWebRequest.Get("https://xxxx:80/xxx/xxx/xxx");
            // リクエストヘッダを指定
            request.SetRequestHeader("X_API_KEY", "c897aa8ba9cba89c");
            // リクエストを開始
            yield return request.SendWebRequest();

            // 400系か500系のエラー
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
                if (request.responseCode == NOT_FOUND)
                {
                    Debug.LogError("Error:" + NOT_FOUND + " " + request.url);
                }
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                byte[] resultsData = request.downloadHandler.data;
            }


        }

    }
}
