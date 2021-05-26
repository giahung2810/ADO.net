using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Data Source=GIAHUNGPC;Initial Catalog=QLSV;User ID=giahung;Password=giahung
        }
        private void Show()
        {
            string cnnstr = @"Data Source = GIAHUNGPC; Initial Catalog = QLSV; User ID = giahung; Password = giahung";
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from SV where MSSV = @M";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.Add("@M", SqlDbType.VarChar);
            cmd.Parameters["@M"].Value = textBox1.Text;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("NameSV", typeof(string)),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int)),
            });
            cnn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["MSSV"] = r["MSSV"];
                dr["NameSv"] = r["NameSV"];
                dr["Gender"] = r["Gender"];
                dr["NS"] = r["NS"];
                dr["ID_Lop"] = r["ID_Lop"];
                dt.Rows.Add(dr);
            }
            cnn.Close();

            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /* string cnnstr = @"Data Source = GIAHUNGPC; Initial Catalog = QLSV; User ID = giahung; Password = giahung";
             SqlConnection cnn = new SqlConnection(cnnstr);
             //string query = "select * from SV";
             SqlCommand cmd = new SqlCommand(textBox1.Text, cnn);

             cnn.Open();

             cmd.ExecuteNonQuery();

             cnn.Close();

             Show();*/
            //ShowDS();
            string query = "Select * from SV";
            dataGridView1.DataSource = DBHelper.Instance.GetRecords(query);
        }
        private void ShowDS()
        {
            string cnnstr = @"Data Source = GIAHUNGPC; Initial Catalog = QLSV; User ID = giahung; Password = giahung";
            SqlConnection cnn = new SqlConnection(cnnstr);

            string query = "select * from SV where MSSV = '" + textBox1.Text + "'";
            

            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cnn.Open();

            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
