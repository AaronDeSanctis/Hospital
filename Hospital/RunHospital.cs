using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class RunHospital
    {
        FrontDesk frontDesk;
        Doctor doctor;
        Nurse nurse;
        Random rand;
        List<Patient> patients;
        ExamRoom examRoom;
        Appointment makeAppointment;
        List<Treatment> Prognosis;
        List<Patient> formerPatients;
        string TodaysDate;
        int dayCounter = 0;
        int Iterator;

        public RunHospital()
        {
            formerPatients = new List<Patient>();
            patients = new List<Patient>();
            rand = new Random();
            Prognosis = new List<Treatment>();
            while (true)
            {
                TodaysDate = GenerateDate();
                nurse = GenerateNurse(); doctor = GenerateDoctor();
                foreach (Patient patient in patients)
                {
                    frontDesk = new FrontDesk(nurse, patient);
                    makeAppointment = new Appointment(patient, doctor, rand.Next(2400).ToString(), "12" + rand.Next(31));
                    examRoom = new ExamRoom(doctor, patient);
                    PatientsToFormer(patient);
                }
                dayCounter++;
            }

        }

        private int GeneratePatientNum()
        {
            return Iterator++;
        }

        private void PatientsToFormer(Patient patient)
        {
            patients.Remove(patient);
            formerPatients.Add(patient);
        }
        private void FormerToPatients(Patient patient)
        {
            patients.Add(patient);
            formerPatients.Remove(patient);
        }
        string GenerateDate()
        {
            return "12" + dayCounter;
        }
        Doctor GenerateDoctor()
        {
            return doctor = new Doctor(GenerateString(), rand.Next(100));
        }
        Nurse GenerateNurse()
        {
            return nurse = new Nurse(GenerateString(), rand.Next(100));
        }
        string RandomDigits(int length, int MaxNum)
        {
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, rand.Next(MaxNum).ToString());
            return s;
        }
        string GenerateString()
        {
            Byte length = (Byte)(rand.Next(8));
            var bytes = new byte[length];
            rand.NextBytes(bytes);
            return Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "");
        }
        void MakeAppointment()
        {

        }
    }
}
