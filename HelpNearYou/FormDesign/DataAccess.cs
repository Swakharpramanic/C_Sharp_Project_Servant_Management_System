using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace FormDesign
{
    public static class DataAccess
    {
        
    //   internal static SqlConnection Connection { get; set; }


        internal static SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-UA79V0N\SQLEXPRESS;Initial Catalog=servantfinder;Integrated Security=True");

       internal static SqlCommand Command;
       internal static SqlDataAdapter SqlAdapter;
       internal static DataSet SqlDataset = new DataSet();

       internal static void Connect()
       {
           DataAccess.Connection.Open();
       }

       internal static void Disconnect()
       {
           DataAccess.Connection.Close();
       }


     //   internal static SqlCommand Command { get; set; }
     //  internal static SqlDataAdapter SqlAdapter { get; set; }
     //   internal static DataSet SqlDataset { get; set; }

        internal static void QueryText(string query)
        {
           DataAccess.Command = new SqlCommand(query, DataAccess.Connection);
        }

        internal static DataSet ExecuteQuery(string query)
        {
           DataAccess.QueryText(query);
           DataAccess.SqlAdapter = new SqlDataAdapter(DataAccess.Command);
           DataAccess.SqlDataset = new DataSet();
           DataAccess.SqlAdapter.Fill(SqlDataset);
            return DataAccess.SqlDataset;

        }

        internal static string GenerateSaleId()
        {
            string sql = "select * from sales order by saleid desc;";
            DataAccess.SqlDataset=ExecuteQuery(sql);
            return DataAccess.SqlDataset.Tables[0].Rows[0]["saleid"].ToString();
        }

        internal static string GenerateOrderId()
        {
            string sql = "select * from orderdetail order by orderid desc;";
            DataAccess.SqlDataset = DataAccess.ExecuteQuery(sql);
            return DataAccess.SqlDataset.Tables[0].Rows[0]["orderid"].ToString();
        }

        internal static int ExecuteUpdateQuerry(string query)
        {
            DataAccess.QueryText(query);
            int row = Command.ExecuteNonQuery();
            return row;
        }
    }
    }

