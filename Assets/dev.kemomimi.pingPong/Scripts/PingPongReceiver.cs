using System.Net;
using UnityEngine;

namespace dev.kemomimi.m5pingpong
{
    public class PingPongReceiver : MonoBehaviour
    {
        [SerializeField] private string message = "Success";

        [Space, SerializeField] private Animator pingPongAnimator;
        [SerializeField] private int ch;

        public void OnRequest(HttpListenerContext context)
        {
            var data = System.Text.Encoding.UTF8.GetBytes(message);
            context.Response.StatusCode = 200;
            context.Response.Close(data, false);

            var str = context.Request.RawUrl;
            str = str.Substring(1, str.Length - 1);
            //Debug.Log(str);

            if (ch == int.Parse(str))
            {
                OpenPingPong();
            }
        }

        public void OpenPingPong()
        {
            pingPongAnimator.SetBool("Open", true);
        }

        public void ClosePingPong()
        {
            pingPongAnimator.SetBool("Open", false);
        }
    }

}