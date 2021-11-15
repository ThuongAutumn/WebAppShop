using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
//using Oracle.ManagedDataAccess.Types;
using Microsoft.Extensions.Configuration;
using System.IO;
using SeverBVSTT.Models;
using System.Data.SqlClient;

namespace SeverBVSTT.Models
{
    public class AccessData : BaseRepository
    {
        public AccessData(string connectionString) : base(connectionString)
        {
        }       
        //    string sConn;
        SqlTransaction trans;
        SqlConnection con;
        SqlCommand cmd;

        //    OracleDataReader datard;
        SqlDataAdapter destx;
        SqlConnection conx;

        SqlCommand cmdx;        
        DataSet dsx = null;

        SqlTransaction trans_sv2;
        SqlConnection con_sv2;
        public string sConn_sv2 = "";
        string service_name_sv2 = "hgsoft_sv2";

        SqlTransaction trans_sv3;
        SqlConnection con_sv3;
        public string sConn_sv3 = "";
        string service_name_sv3 = "hgsoft_sv3";
        
        public void Begin_transaction()
        {
            //GoiChuoiKN();
            con = new SqlConnection(connectionString);
            con.Open();
            trans = con.BeginTransaction();            
        }
        //    // xac nhận với data
        public void Commit_transaction()
        {
            trans.Commit();
            con.Close();
            con.Dispose();
            cmd.Dispose();
            trans.Dispose();
        }
        //Lỗi xác nhận với data
        public void RollBack_transaction()
        {
            trans.Rollback();
            con.Close();
            con.Dispose();
            cmd.Dispose();
            trans.Dispose();            
        }
        

        public DataSet get_data(string sql)
        {            
            if (dsx != null)
            {
                dsx.Dispose();
                dsx = null;
            }
            dsx = new DataSet();

            if (conx == null || conx.State != ConnectionState.Open)
            {
                conx = new SqlConnection(connectionString);
                conx.Open();
            }
            cmdx = new SqlCommand(sql, conx);
            cmdx.CommandType = CommandType.Text;
            destx = new SqlDataAdapter(cmdx);
            dsx = new DataSet();
            //MessageBox.Show(sql);
            destx.Fill(dsx);
            cmdx.Dispose();
            conx.Close();
            conx.Dispose();
            return dsx;
        }     
        
        public void get_data_close_conecc()
        {
            cmdx.Dispose();
            conx.Close();
            conx.Dispose();
        }
        public void GayLoi()
        {
            int i = 1;
            int k = i / 0;
        }
       
    }
}

