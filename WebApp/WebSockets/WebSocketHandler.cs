using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SeverBVSTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeverBVSTT.WebSockets
{
    public abstract class WebSocketHandler
    {
        public WebSocketConnectionManager WebSocketConnectionManager { get; set; }
        public WebSocketHandler(WebSocketConnectionManager webSocketConnectionManager)
        {
            WebSocketConnectionManager = webSocketConnectionManager;
        }
        public virtual async Task OnConnected(WebSocket socket, string k)
        {
            WebSocketConnectionManager.AddSocket(socket, k);
        }
        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await WebSocketConnectionManager.RemoveSocket(WebSocketConnectionManager.GetId(socket));
        }

        public async Task SendMessageAsync(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
                return;
            await socket.SendAsync(buffer: new ArraySegment<byte>(/*array: */Encoding.UTF8.GetBytes(message)/*, offset: 0, count: message.Length*/), messageType: WebSocketMessageType.Text,
                                   endOfMessage: true,
                                   cancellationToken: CancellationToken.None);
        }
        public async Task SendMessageAsync(string socketId, string message)
        {
            try
            {
                await SendMessageAsync(WebSocketConnectionManager.GetSocketById(socketId), message);
            }
            catch (Exception)
            {

            }
        }
        // gửi dữ liệu cho tất cả
        public async Task SendMessageToAllAsync(string message)
        {
            foreach (var pair in WebSocketConnectionManager.GetAll())
            {
                if (pair.Value.State == WebSocketState.Open)
                    await SendMessageAsync(pair.Value, message);
            }




            //// chạy vòng lặp
            //foreach (var pair in WebSocketConnectionManager.GetAll())
            //{
            //    if (pair.Value.State == WebSocketState.Open)
            //    await SendMessageAsync(pair.Value, message);
            //    // tạo mới, reset ma
            //    string[] ma = null;
            //    string k = "";
            //    //tạo ma
            //    k = pair.Key;
            //    ma = k.Split('-');
            //    // kiểm tra ma và key
            //    string mamoi = ma[0];
            //}
        }
        public async Task SendMessageToAll(List<MaBV> obj, MaBV obj1)
        {
            // chạy vòng lặp
            foreach (var pair in WebSocketConnectionManager.GetAll())
            {
                // tạo mới, reset ma
                string[] ma = null;
                string k = "";
                //tạo ma
                k = pair.Key;
                ma = k.Split('-');
                string output = JsonConvert.SerializeObject(obj1);
                // kiểm tra ma và key
                //if (ma[0] == obj1.BenhVien)
                //{
                //    if (pair.Value.State == WebSocketState.Open)
                //    await SendMessageAsync(pair.Value, output);
                //}
                //else 
                //{
                //    for (int i = 0; i < obj1.DSPhongKham.Count; i++)
                //    {
                //        if (ma[0] == obj1.DSPhongKham[i].MaKP)
                //        {
                //            if (pair.Value.State == WebSocketState.Open)
                //            await SendMessageAsync(pair.Value, output);
                //        }
                //    }
                //}
                //string s = "Nguyễn Văn A".Split(' ');
                // kiểm tra tất cả pair có kết nối gủi dữ liệu

                string mamoi = ma[0];
            }
        }
        public abstract Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);        
    }
}

