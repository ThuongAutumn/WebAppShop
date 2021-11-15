using Microsoft.AspNetCore.Http;
using SeverBVSTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SeverBVSTT.WebSockets
{
    public class ChatRoomHandler : WebSocketHandler
    {
        public ChatRoomHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {

        }      
        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            
            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            string j = message;
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await SendMessageToAllAsync(message);
        }
        public override async Task OnConnected(WebSocket socket, string k)
        {
            await base.OnConnected(socket, k);
            var SocketID = WebSocketConnectionManager.GetId(socket);
            await SendMessageToAllAsync($"{SocketID}");
        }
    }
    // so sanh
    
}
