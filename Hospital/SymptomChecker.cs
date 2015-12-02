using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class SymptomChecker
    {
        public Symptom checkSymptoms(string name)
        {
            while (true)
            {
                if (name == "Cough")
                {
                    Symptom cough = new Symptom(name);
                    return cough;
                }
                else if (name == "Bloody Stool")
                {
                    Symptom bloodyStool = new Symptom(name);
                    return bloodyStool;
                }
                else if (name == "Broken Bone")
                {
                    Symptom brokenBone = new Symptom(name);
                    return brokenBone;
                }
                else if (name == "Lasceration")
                {
                    Symptom lasceration = new Symptom(name);
                    return lasceration;
                }
                else if (name == "Tumor")
                {
                    Symptom tumor = new Symptom(name);
                    return tumor;
                }
                else if (name == "Sneezing")
                {
                    Symptom sneezing = new Symptom(name);
                    return sneezing;
                }
                else if (name == "Jaundice")
                {
                    Symptom jaundice = new Symptom(name);
                    return jaundice;
                }
                else if (name == "Diarrhea")
                {
                    Symptom diarrhea = new Symptom(name);
                    return diarrhea;
                }
                else if (name == "Constipation")
                {
                    Symptom constipation = new Symptom("cough");
                    return constipation;
                }
                else if (name == "Vomiting")
                {
                    Symptom vomiting = new Symptom("cough");
                    return vomiting;
                }
            }

        }
    }
}
