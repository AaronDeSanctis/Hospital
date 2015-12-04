using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class FrontDesk
    {
        Doctor currentDoctor;
        Patient currentPatient;
        Database medRecords;
        List<Patient> AllPatients;
        List<Patient> patientAndMedHistory;
        Nurse currentNurse;
        public FrontDesk(Nurse nurse, Patient patient)
        {
            AllPatients = new List<Patient>();
            patientAndMedHistory = new List<Patient>();
            medRecords = new Database();
            this.currentNurse = nurse;
            this.currentPatient = patient;
            GetAllPatientsInfo();
            bool Exists = DoesPatientExist();
            if (Exists)
            {
                medRecords.Overwrite(currentPatient);
            }
            else if (!Exists)
            {
                medRecords.Save(currentPatient);
            }
        }
        private void GetAllPatientsInfo()
        {
            AllPatients.Add(medRecords.Read(currentPatient));
            foreach (Patient patient in AllPatients)
            {
                if (patient == null)
                {
                    AllPatients.Remove(patient);
                }
            }
        }
        private bool DoesPatientExist()
        {
            foreach (Patient patient in AllPatients)
            {
                if (patient.firstName == currentPatient.firstName && patient.patientNum == currentPatient.patientNum)
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangePatient(Patient patient)
        {
            currentPatient = patient;
        }
        public void ChangeDoctor(Doctor doctor)
        {
            currentDoctor = doctor;
        }
        public void ChangeNurse(Nurse nurse)
        {
            currentNurse = nurse;
        }
    }
}
