using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trying to login...");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                MessageBox.Show("Do other people use this pc to use this software? If yes, We recomend not to use this feature!", "Are you sure?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
