using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SeverBVSTT.Models;
using SeverBVSTT.WebSockets;

namespace SeverBVSTT.Controllers
{
    public abstract class BaseController : Controller
    {
        //field
        protected AppRepository app;
        public BaseController(IConfiguration configuration)
        {
            app = new AppRepository(configuration);
        }
        public BaseController()
        {
            app = new AppRepository();
        }
        
    }
}