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
        Patient patient;
        Random rand;
        List<Patient> patients;
        ExamRoom examRoom;
        Appointment makeAppointment;
        List<Treatment> Prognosis;
        string TodaysDate;
        int dayCounter = 0;

        public RunHospital()
        {
            while (true)
            {
                TodaysDate = GenerateDate();
                rand = new Random();
                patients = new List<Patient>();
                GeneratePatients(rand.Next(15) + 1);
                nurse = GenerateNurse(); doctor = GenerateDoctor();
                frontDesk = new FrontDesk(nurse, patient);
                makeAppointment = new Appointment(patient, doctor, rand.Next(2400).ToString(), "12" + rand.Next(31));
                examRoom = new ExamRoom(doctor, patient);
                Prognosis = new List<Treatment>();
                patient.ReceiveTreatments(Prognosis);
                dayCounter++;
            }

        }
        void GeneratePatients(int NumOfPatients)
        {
            for (int i = 0; i < NumOfPatients; i++)
            {
                patient = new Patient();
                patient.GetStats(GenerateString(), rand.Next(100), RandomDigits(10, 10), rand.NextDouble() >= 0.5);
                patients.Add(patient);
            }
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
