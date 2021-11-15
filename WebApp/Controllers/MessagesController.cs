using Microsoft.AspNetCore.Mvc;
using SeverBVSTT.Models;
using SeverBVSTT.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeverBVSTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private ChatRoomHandler _notificationsMessageHandler { get; set; }

        public MessagesController(ChatRoomHandler notificationsMessageHandler)
        {
            _notificationsMessageHandler = notificationsMessageHandler;
        }
      
        
    }
}
