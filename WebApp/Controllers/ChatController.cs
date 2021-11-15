using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SeverBVSTT.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace SeverBVSTT.Controllers
{
    public class ChatController : BaseController
    {   // load dữ liệu//
        
        public IActionResult Index(string id)
        {            
            return View();
        }
        [Authorize(Roles = "hgsoft")]
        public IActionResult Chat_Order(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();            
        }
     
    }
}