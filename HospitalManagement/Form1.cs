using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagement
{

    public partial class Form1 : Form
    {
        static string connectionstring =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pavilion\\Documents\\hospitalManagement.mdf;Integrated Security=True;Connect Timeout=30";


        SqlConnection myConnection  = new SqlConnection(connectionstring);
        SqlDataReader b;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            if (login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Login Successsful");
                myConnection.Close();
                Form2 form2 = new Form2(true, textBox1.Text);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Credentials");
                textBox2.Text = "";
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myConnection.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection.Close(); 
            this.Close();
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool login (String username,String password)
        {
            string com1 = "select * from LoginAccess where username = '" + username + "'";
            if (username.Substring(0, 1) == "\'" || username.Substring(0, 1) == " ") 
            {
                MessageBox.Show("Do not try to hack this!");
                return false;
            }
            reader(com1);
            if (b.Read())
            {
                if (password == (b["pass"].ToString()))
                {
                    b.Close();
                    return true;
                }
                else
                {
                    b.Close();
                    return false;
                }
            }
            else
            {
                b.Close();
                return false;
            }
        }

        private void reader (string sqCommand)
        {
            
            string string1;
            string1= sqCommand;
            SqlCommand Newcommand = new SqlCommand(string1, myConnection);
            try
            {
                b = Newcommand.ExecuteReader();
                if(b==null)
                {
                    MessageBox.Show("b is null");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("this is crap" + e.ToString());
            }
            
        }
    }
}