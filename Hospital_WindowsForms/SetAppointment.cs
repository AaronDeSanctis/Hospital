using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
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
        private string[] doctorArray = new string[5];
        private List<string> previousAppts = new List<string>();

        public SetAppointment(Hospital.Patient patientObj)
        {
            InitializeComponent();
            this.patientObj = patientObj;
            doctorArray[0] = "Please Select Doctor Below.";
            doctorArray[1] = "Doctor Who";
            doctorArray[2] = "Doctor Pepper";
            doctorArray[3] = "Doctor Feelgood";
            doctorArray[4] = "Doctor John";

            foreach (string doctorName in doctorArray)
            {
                comboBox1.Items.Add(doctorName);
            }
            comboBox1.SelectedIndex = 0;

            Hospital.Calendar calendar = new Hospital.Calendar();
            Events occupiedDates = new Events();
            occupiedDates = calendar.GetEvents();
            if (occupiedDates != null)
            {
                foreach (var eventItem in occupiedDates.Items)
                {
                    string eventStr = String.Format("{0} ({1})", eventItem.Description, eventItem.Start);
                    previousAppts.Add(eventStr);
                }
            }
            if (previousAppts.Count() != 0)
            {
                foreach (string appointment in previousAppts)
                {
                    comboBox2.Items.Add(appointment);
                }
            }
            else
            {
                comboBox2.Items.Add("No appointments found.");
            }
            comboBox2.SelectedIndex = 0;

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

            // Get symptoms.
            List<string> symptomList = new List<string>();
            string symptoms = textBox1.Text;
            symptomList = symptoms.Split(',').ToList();
            patientObj.SetSymptoms(symptomList);

            // Send appointment to Google Calendar
            Hospital.Calendar calendar = new Hospital.Calendar();
            string doctorName = comboBox1.Text;
            Hospital.Doctor doctorObj = new Hospital.Doctor(doctorName, 42);
            string apptInfo = calendar.AddAppointment(apptDate, patientObj, doctorObj);
            MessageBox.Show(apptInfo);

            // Write patient to xml file.
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
            ;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
