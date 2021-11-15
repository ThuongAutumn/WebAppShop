using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SeverBVSTT.Models;

namespace SeverBVSTT.Controllers
{
    public class HomeController : BaseController
    {        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(MaBV obj)
        {
            if (ModelState.IsValid)
            {
                obj.Ma = obj.Ma.Replace(" ", "");
                string matkhau = GoiJson("pass1");
                string str = GoiJson("user");
                string[] arrListStr = str.Split('-');
                
                if (obj.Ma == matkhau)
                {
                    int i = 0;
                    foreach (var item in arrListStr)
                    {
                        if (arrListStr[i] == obj.User)
                        {

                            long Id = Helper.RandomLong();
                            ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Id.ToString()));// id phân biệt
                            claims.AddClaim(new Claim(ClaimTypes.Name, obj.User));// mã bệnh viện
                            claims.AddClaim(new Claim(ClaimTypes.Role, "hgsoft"));// phân quyền
                            AuthenticationProperties properties = new AuthenticationProperties
                            {
                                AllowRefresh = true,
                                IsPersistent = obj.Remember,
                            };
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims), properties);
                            return Json("1");
                        }
                        i = i + 1;
                    }
                    return Json("0");
                }
                else{
                    return Json("0");
                }
            }
            else{
                return Json("2");
            }

        }
        //await _notificationsMessageHandler.SendMessageToAll(obj, b);
        public IActionResult SignOut()
        {//Dang xuat yeu cau cookie thoat 
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        // Thông tin động json//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GoiJson(string key)
        {
            string GiaTri;
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            GiaTri = configuration.GetConnectionString(key);
            return GiaTri;
        }
    }
}