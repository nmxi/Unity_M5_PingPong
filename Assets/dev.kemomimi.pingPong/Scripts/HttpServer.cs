using System;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace dev.kemomimi.m5pingpong
{
    [Serializable]
    public class OnRequestEvent : UnityEvent<HttpListenerContext> { }
}

namespace dev.kemomimi.m5pingpong
{
    public class HttpServer : MonoBehaviour
    {
        private HttpListener httpListener = new HttpListener();

        public int port = 80;
        public string path = "/";

        public OnRequestEvent OnRequest;

        void Start()
        {
            httpListener.Prefixes.Add("http://*:" + port + path);
            _ = StartServer();
        }

        public async Task StartServer()
        {
            httpListener.Start();

            while (true)
            {
                var context = await httpListener.GetContextAsync();

                OnRequest.Invoke(context);
            }
        }

        void OnDestroy()
        {
            httpListener.Stop();
        }
    }
}