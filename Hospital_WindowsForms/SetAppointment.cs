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
    public partial class SetAppointment : Form
    {
        Hospital.Patient patientObj = new Hospital.Patient();
        Hospital.Doctor[] doctorArray = new Hospital.Doctor[3];

        public SetAppointment(Hospital.Patient patientObj)
        {
            InitializeComponent();
            this.patientObj = patientObj;
            doctorArray[0] = new Hospital.Doctor("Who", 900);
            doctorArray[1] = new Hospital.Doctor("Pepper", 130);
            doctorArray[2] = new Hospital.Doctor("John", 75);

            foreach (Hospital.Doctor d in doctorArray)
            {
                comboBox1.Items.Add(d.ToString());
            }
            comboBox1.SelectedIndex = 0; 
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get selected date and time.
            DateTime apptDate = new DateTime();
            apptDate = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;

            // Send appointment to Google Calendar
            Hospital.Calendar calendar = new Hospital.Calendar();
            string doctorName = comboBox1.SelectedItem.ToString();
            Hospital.Doctor doctorObj = new Hospital.Doctor(doctorName, 42);
            string apptInfo = calendar.AddAppointment(apptDate, patientObj, doctorObj);
            MessageBox.Show(apptInfo);

            // Write patient to database
            Hospital.Database DB = new Hospital.Database();
            DB.Save(patientObj);
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ;
        }


        private void SetAppointment_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
