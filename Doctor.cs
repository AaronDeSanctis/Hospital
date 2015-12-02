using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Doctor : MedProfessional
    {    
        public Doctor(List<Symptom> Symptoms, string Name, int Age, string PhoneNumber, bool HealthIns)
        {
            this.symptoms = Symptoms;
            this.name = Name;
            this.age = Age;
            this.phoneNumber = PhoneNumber;
            this.healthIns = HealthIns;
        }
        private string prescribe(Patient patient)
        {
            return "Here's Your Prescription" + patient.name;
        }
        private string diagnosis(Patient patient)
        {
            return "Here's Your Diagnosis" + patient.name;
        }
    }
}
