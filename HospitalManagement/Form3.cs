using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Form3 : Form
    {
        string ConnectionString =
           "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pavilion\\Documents\\hospitalManagement.mdf;Integrated Security=True;Connect Timeout=30";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void loadgrid()
        {
            dataGridView1.Rows.Clear();
            List<List<string>> pid = Reader("select* from patientDB");
            foreach (List<string> a in pid)
            {
                using (DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone())
                {
                    int i = 0;
                    foreach (string b in a)
                    {
                        row.Cells[i].Value = b;
                        i++;
                    }

                    dataGridView1.Rows.Add(row);
                }
            }

        }

        private List<List<string>> Reader(string sqCommand)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                myConnection.Open();

                using (SqlCommand cmd = new SqlCommand(sqCommand, myConnection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<List<string>> list = new List<List<string>>();

                    while (reader.Read())
                    {
                        List<string> av = new List<string>();
                        for (int i = 0; i < 9; i++)
                        {
                            av.Add(reader[i].ToString());
                        }
                        list.Add(av);
                    }

                    return list;
                }
            }
        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
    }
}
