using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class ExamRoom
    {
        Doctor doctor;
        Patient patient;
        List<string> patientSymptoms;
        List<Symptom> RealSymptoms;
        SymptomChecker symptomChecker;
        public ExamRoom(Doctor doctor, Patient patient)
        {
            this.doctor = doctor;
            this.patient = patient;
            patientSymptoms = new List<string>();
            patientSymptoms = doctor.ExaminePatient(patient);
            symptomChecker = new SymptomChecker();
            RealSymptoms = new List<Symptom>();
        }
        void DocumentSymptoms()
        {
            foreach (string symptom in patientSymptoms)
            {
                RealSymptoms.Add(symptomChecker.checkSymptoms(symptom));
            }
        }
        public List<Treatment> Diagnose()
        {
            TreatmentChooser treatmentChooser = new TreatmentChooser(RealSymptoms);
            return treatmentChooser.ReturnTreatmentList();
        }
    }
}
