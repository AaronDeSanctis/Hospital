using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Treatment
    {
        public string treatmentName;
        public List<string> symptomNames;
        public string instructions;
        public Treatment(string TreatmentName, List<string> SymptomNames, string Instructions)
        {
            this.treatmentName = TreatmentName;
            this.symptomNames = SymptomNames;
            this.instructions = Instructions;
            //this.currentPatient = patient;
            //Add Patient patient and Doctor doctor to arguments in constructor
        }

        private void checkDatabase(string ICD10, Symptom symp)
        {

        }
    }
}