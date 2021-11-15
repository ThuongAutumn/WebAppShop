using Microsoft.Extensions.Configuration;
using SeverBVSTT.Models;
using SeverBVSTT.WebSockets;
using System.Data.SqlClient;
using System.IO;

namespace SeverBVSTT.Models
{
    public class AppRepository
    {
        string connectionString;
        public AppRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("sql");
        }
        public WebSocketConnectionManager webSocketConnectionManager { get; set; }
        
        public AppRepository()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            IConfigurationRoot configuration = builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //IConfiguration configuration1 = builder.Add.webSocketConnectionManager;
            connectionString = configuration.GetConnectionString("sql");
        } 
        //websocket
        //SqlConnection conx1 = new SqlConnection(connectionString);
        //conx1.Open();
        //fields;
        
        // accesdata
        AccessData accessData;
        public AccessData AccessData
        {
            get
            {
                if (accessData is null)
                {
                    accessData = new AccessData(connectionString);
                }
                return accessData;
            }
        }
        // tu websocket        
        ChatRoomHandler guiThongTinKhachHang;
        public ChatRoomHandler GuiThongTinKhachHang
        {
            get
            {
                if (guiThongTinKhachHang is null)
                {
                    guiThongTinKhachHang = new ChatRoomHandler(webSocketConnectionManager);
                }
                return guiThongTinKhachHang;
            }
        }              
    }
}
