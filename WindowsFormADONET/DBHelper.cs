using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormADONET
{
    class DBHelper
    {
        private SqlConnection cnn;
        private static DBHelper _Instance;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string cnnstr = @"Data Source = GIAHUNGPC; Initial Catalog = QLSV; User ID = giahung; Password = giahung";
                    _Instance = new DBHelper(cnnstr);
                }
                return _Instance;
            }
            private set { }
        }
        private DBHelper(String s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExecuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();// INSERT, DELETE, UPDATE
            cnn.Close();
        }
        public DataTable GetRecords(string query)
        {
            DataTable data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            cnn.Open();
            da.Fill(data);
            cnn.Close();
            return data;
        }
    }
}
