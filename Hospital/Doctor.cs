using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Doctor : MedProfessional
    {
        public Dictionary<string, string> Schedule;
        public Doctor(string name, int age)
        {
            this.name = name;
            this.age = age;
            Schedule = new Dictionary<string, string>();
        }
        private string prescribe(Patient patient)
        {
            return "Here's Your Prescription" + patient.name;
        }
        private string diagnosis(Patient patient)
        {
            return "Here's Your Diagnosis" + patient.name;
        }

        public List<string> ExaminePatient(Patient patient)
        {
            return patient.GiveSymptoms();
        }
    }
}