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
            Schedule = new Dictionary<string, string>();
        }
        private string prescribe(Patient patient)
        {
            return "Here's Your Prescription";
        }
        private string diagnosis(Patient patient)
        {
            return "Here's Your Diagnosis";
        }

    }
}