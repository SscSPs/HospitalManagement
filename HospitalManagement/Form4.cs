using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagement
{
    public partial class Form4 : Form
    {
        //veriables start
        static string connectionstring =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\pavilion\\Documents\\hospitalManagement.mdf;Integrated Security=True;Connect Timeout=30";

        static string addCommand;
        string patientID;
        string idmonth;
        string idday;
        int noOfPatientsToday=0;
        string gender;
        bool gender_selected = false;
        //veriables end

        public Form4()
        {
            findpatientstoday();
            InitializeComponent();
            noOfPatientsToday++;
            patientID = genpID();
            label10.Text = patientID;
            
        }

        private string genTDate()
        {
            if (int.Parse(DateTime.Now.Month.ToString()) / 10 == 0)
                idmonth = "0" + int.Parse(DateTime.Now.Month.ToString()).ToString();
            else idmonth = int.Parse(DateTime.Now.Month.ToString()).ToString();
            if (int.Parse(DateTime.Now.Day.ToString()) / 10 == 0)
                idday = "0" + int.Parse(DateTime.Now.Day.ToString()).ToString();
            else
                idday = int.Parse(DateTime.Now.Day.ToString()).ToString();
            return DateTime.Now.Year.ToString() + idmonth + idday + "000";
        }
        private string genpID()
        {
            return (Int64.Parse(genTDate()) * 10 + (noOfPatientsToday++)).ToString();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == DateTime.Now)
                MessageBox.Show("Enter D.O.B. of the patient, not today's date");
            int years = DateTime.Now.Year - dateTimePicker1.Value.Year;
            DateTime temp = dateTimePicker1.Value;
            if (temp.AddYears(years) > DateTime.Now)
                years--;
            label9.Text = "Age: " + years.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkReq())
            {
                addCommand = "insert into patientDB values (" + (Int64.Parse(patientID)) + ",\'"
                + textBox1.Text + "\',\'" + textBox2.Text + "\',\'" + textBox3.Text + "\',\'" + //name
                 dateTimePicker1.Value.ToString().Substring(0, 10) + "\',\'" + (textBox4.Text) + "\',\'" + gender + //dob, ph.no, sex
                 "\',\'" + textBox6.Text + "\',\'" + textBox5.Text + "\')";
                addEntry();
                patientID = genpID();
                label10.Text = patientID;
            }
            else
                MessageBox.Show("Fill all the Required fields");
        }

        private bool checkReq()
        {
            bool flag = true;

            flag = isNotNull(textBox1);
            flag = flag && isNotNull(textBox3);
            flag = flag && isNotNull(textBox4);
            flag = flag && isNotNull(textBox6);
            flag = flag && gender_selected;

            return flag;
        }

        private bool isNotNull(TextBox textBoxz)
        {
            if (textBoxz.Text == null)
                return false;
            else return true;
        }

        private void addEntry()
        {
            using (SqlConnection myConnection = new SqlConnection(connectionstring))
            {
                myConnection.Open();

                using (SqlCommand cmd = new SqlCommand(addCommand, myConnection))

                if (cmd.ExecuteNonQuery()!=1)
                    MessageBox.Show("some kind of error occured, no. of rows affected is not 1");
                else
                    MessageBox.Show("Entered successfully!");

            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "m";
            gender_selected = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "f";
            gender_selected = true;
        }

        private void findpatientstoday()
        {
            Int64 todaysdate = (Int64.Parse(genTDate())*10) ;
            using (SqlConnection myConnection = new SqlConnection(connectionstring))
            {
                
                string sqCommand="select pID from patientDB where pID > " + todaysdate.ToString() ;
                myConnection.Open();

                using (SqlCommand cmd = new SqlCommand(sqCommand, myConnection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((todaysdate + noOfPatientsToday) < Int64.Parse(reader[0].ToString()))
                            noOfPatientsToday = int.Parse((Int64.Parse(reader[0].ToString()) - (todaysdate)).ToString());
                    }
                }
            }
        }

    }

}
