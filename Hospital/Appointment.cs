using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Appointment
    {
        public string appt_date;
        public float appt_time;
        public float duration;
        public string doctor;
        public string patient;
        public string room_number;
        bool full;
        public Appointment(Patient patient, Doctor doctor, string time, string date)
        {
            full = CheckMedCalendar(patient, doctor, time, date);
            if (full == false)
            {
                SetAppointment(patient, doctor, time, date);
            }
        }

        private bool CheckMedCalendar(Patient patient, Doctor doctor, string time, string date)
        {
            if (doctor.Schedule.ContainsValue(date))
            {
                int Time = Int32.Parse(time);
                if (Time >= 800 && Time <= 1700)
                {

                    if (doctor.Schedule.ContainsValue(time))
                    {
                        Time += 45;
                        time = Time.ToString();
                        full = CheckMedCalendar(patient, doctor, time, date);
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        private void SetAppointment(Patient patient, Doctor doctor, string time, string date)
        {
            //DateTime dateTime = new DateTime(2008, 6, 1, 7, 47, 0);
            string dateTime = time + date;
            doctor.FinalSchedule.Add(patient, dateTime);
        }

    }
}