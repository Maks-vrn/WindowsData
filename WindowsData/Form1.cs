using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }
        private void LoadData()
        {
            string connectString = "Data Source =LAPTOP-VA67JA14; Initial Catalog =master;" +
                "Integrated Security=true;";

            SqlConnection con = new SqlConnection(connectString);

            con.Open();
            string filePath = "C:\\SQLQuery1";

            using(StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[]value = line.Split(',');
                    SqlCommand cmd = new SqlCommand("INSERT INTO my Table (Column1,Column2,Column3) VALUE (@val1,@val2,@val3)",con);
                    cmd.Parameters.AddWithValue("@val1", value[0]);
                    cmd.Parameters.AddWithValue("@val2", value[1]);
                    cmd.Parameters.AddWithValue("@val3", value[2]);
                    cmd.ExecuteNonQuery();
                }
            }
            con.Close();
            }
        }
    }

