using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class MedProfessional : Person
    {
        //Dictionary<string, Symptom> patientSymptoms;
        public Dictionary<Patient, string> FinalSchedule;
        Dictionary<string, string> Schedule;
        public MedProfessional()
        {
            Schedule = new Dictionary<string, string>();
            FinalSchedule = new Dictionary<Patient, string>();
        }
        public void Comfort()
        {

        }
        public void Examine(Patient patient)
        {

        }
        public bool CheckFinalSchedule(Patient patient, string dateTime)
        {
            foreach (KeyValuePair<Patient, string> pair in FinalSchedule)
            {
                if (pair.Key == patient)
                {
                    if (pair.Value == dateTime)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
