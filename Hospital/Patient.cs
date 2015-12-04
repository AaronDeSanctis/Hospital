using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Patient : Person
    {
        Random rand;
        List<string> SymptomList;
        public int patientNum;
        public bool hasAppointment;
        public Patient()
        {
            SymptomList = new List<string>() { "Cough", "Bloody Stool", "Broken Bone", "Lasceration", "Tumor", "Sneezing", "Jaundice", "Diarrhea", "Constipation", "Vomiting" };
            Symptoms = new List<string>();
            rand = new Random();
            int numOfSymptoms = rand.Next(5);
            generateSymptoms(numOfSymptoms);
        }
        public void GetStats(string Name, int Age, string PhoneNumber, bool HealthIns, int PatientNum)
        {
            this.name = Name;
            this.age = Age;
            this.phoneNumber = PhoneNumber;
            this.healthIns = HealthIns;
            this.patientNum = PatientNum;
        }
        private void generateSymptoms(int NumOfSymptoms)
        {
            for (int i = 0; i < NumOfSymptoms; i++)
            {
                int index = rand.Next(SymptomList.Count);
                string symptom = SymptomList[index];
                if (Symptoms.Contains(symptom))
                {
                    continue;
                }
                else
                {
                    Symptoms.Add(symptom);
                }
            }
        }
        public int GiveRandomPatientNum()
        {
            return rand.Next(999999999);
        }
        public void ReceiveTreatments(List<Treatment> treatments)
        {
            foreach (Treatment treatment in treatments)
            {
                ApplyTreatment(treatment);
            }
        }
        private void ApplyTreatment(Treatment treatment)
        {
            Console.WriteLine(treatment.treatmentName);
            Console.WriteLine(treatment.instructions);
            Console.ReadLine();
        }
        public DateTime MakeAppointment(DateTime datetime)
        {
            return datetime;
        }
    }
}