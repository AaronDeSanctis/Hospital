using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Value = System.DateTime.Now.AddYears(-20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hospital.Patient patientObj = new Hospital.Patient();
            patientObj.name = textBox1.Text;
            patientObj.phoneNumber = textBox3.Text;
            patientObj.DOB = dateTimePicker1.Value;
            MessageBox.Show(patientObj.name + "\n" + patientObj.DOB.ToString());
            SetAppointment setAppointment = new SetAppointment(patientObj);
            setAppointment.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}
