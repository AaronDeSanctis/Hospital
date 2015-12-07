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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool submit = true;
            Hospital.Patient patientObj = new Hospital.Patient();

            // Get patient info
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                patientObj.SetFirstName(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Please fill out first name.");
                submit = false;
            }
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                patientObj.SetLastName(textBox6.Text);
            }
            else
            {
                MessageBox.Show("Please fill out last name.");
                submit = false;
            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                patientObj.SetPhoneNumber(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Please fill out telephone number.");
                submit = false;
            }
            
            patientObj.DOB = dateTimePicker1.Value;

            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                patientObj.SetAddress1(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Please fill out address.");
                submit = false;
            }
            patientObj.SetAddress2(textBox7.Text);
            if (!String.IsNullOrEmpty(textBox8.Text))
            {
                patientObj.SetCity(textBox8.Text);
            }
            else
            {
                MessageBox.Show("Please fill out city.");
                submit = false;
            }
            if (!String.IsNullOrEmpty(textBox9.Text))
            {
                patientObj.SetZipCode(textBox9.Text);
            }
            else
            {
                MessageBox.Show("Please fill out ZIP code.");
                submit = false;
            }
            if (!String.IsNullOrEmpty(textBox10.Text))
            {
                patientObj.SetSSN(textBox10.Text);
            }
            else
            {
                MessageBox.Show("Please fill out Social Security number.");
                submit = false;
            }
            if (!String.IsNullOrEmpty(textBox11.Text))
            {
                patientObj.SetEmail(textBox11.Text);
            }
            else
            {
                MessageBox.Show("Please fill out email address.");
                submit = false;
            }

            // Call next window
            if (submit)
            {
                SetAppointment setAppointment = new SetAppointment(patientObj);
                setAppointment.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}
