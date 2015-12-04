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
        string name;
        public Doctor(string name, int age)
        {
            Schedule = new Dictionary<string, string>();
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }

        private string prescribe(Patient patient)
        {
            return "Here's Your Prescription";
        }
        private string diagnosis(Patient patient)
        {
            return "Here's Your Diagnosis";
        }


        internal string GiveName()
        {
            return this.name;
        }
    }
}