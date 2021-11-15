using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeverBVSTT.WebSockets
{
    public class WebSocketConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();
        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }
        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }

        public string GetId(WebSocket socket)
        {
            // thử lấy id  socket
            string id = _sockets.FirstOrDefault(p => p.Value == socket).Key;
            return id;
        }
        public void AddSocket(WebSocket socket, string k)
        {
            // được truyen vao mot đối tượng socket có kiểu websocket;
            //string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            string sId = CreateConnectionId();
            sId = k + "-" + sId;
            while (!_sockets.TryAdd(sId, socket))
            {
                sId = CreateConnectionId();
            }
        }
        public async Task RemoveSocket(string id)
        {
            try
            {
                WebSocket socket;

                _sockets.TryRemove(id, out socket);

                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);

            }
            catch (Exception)
            {

            }
        }
        // tạo id cho khách đăng ký kết nối socket;
        private string CreateConnectionId()
        {

            // dag thu nghiem id la radom
            //Random rand = new Random();
            //long a = rand.Next();
            //long b = rand.Next();
            //long id = a * b;
            //string k = id.ToString();
            //return k;
            return Guid.NewGuid().ToString();
        }
    }
}
