using System;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Form2 : Form
    {
        string username = null;
        public Form2(bool havepara = false, string name = "NULL")
        {
            InitializeComponent();
            if (havepara)
            {
                username = name;
                label1.Text = "Welcome, " + username;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form);
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }
        /*public static void Loadpanel(bool isRecords)
        {
            if(isRecords)
            {
                Form4 form = new Form4();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(form);
                form.Show();
            }
            else
            {
                ;
            }
        }
         */
    }
}
