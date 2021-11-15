using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SeverBVSTT.WebSockets
{
    public class NotificationsMessageHandler : WebSocketHandler
    {
        public NotificationsMessageHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        //public override Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        //{
        //    throw new NotImplementedException();
        //}
        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            string j = message;
            await SendMessageToAllAsync(message);
        }
    }
}
