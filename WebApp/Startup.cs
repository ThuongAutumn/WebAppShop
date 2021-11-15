using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SeverBVSTT.WebSockets;

namespace SeverBVSTT
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            //Su dung authen dang cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)                
                .AddCookie(op =>
            {
                op.LoginPath = new PathString("/auth/signin");
                op.LogoutPath = new PathString("/auth/signout");
                op.AccessDeniedPath = new PathString("/auth/denied");
                op.ExpireTimeSpan = TimeSpan.FromDays(30); // ngay hết hạng cookie
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Thêm phần mềm trung gian WebSockets
            services.AddWebSocketManager();
            services.AddSignalR();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Khai bao su dung authentication
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}")
            );
            //Thêm phần mềm trung gian WebSockets
            var wsOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(60),
                ReceiveBufferSize = 8 * 1024
            };
            //phan mem trung gian ngoai socket
            app.UseWebSockets(wsOptions); 
            app.MapWebSocketManager("/websocket", serviceProvider.GetService<ChatRoomHandler>());
            app.UseMvc();
            //dua websoket len hosting
        }
    }
}
