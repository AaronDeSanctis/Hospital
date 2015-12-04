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
        
        public SetAppointment(Hospital.Patient patientObj)
        {
            InitializeComponent();
            
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
            DateTime appt = new DateTime();
            Hospital.Calendar calendar = new Hospital.Calendar();
            appt = monthCalendar1.SelectionRange.Start;
            Hospital.Database db = new Hospital.Database();
            //calendar.
            //db.
            MessageBox.Show(appt.ToString());
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}
