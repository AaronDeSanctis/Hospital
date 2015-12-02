using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class TreatmentChooser
    {
        List<string> symptomNameList;
        List<Treatment> treatmentList;
        public TreatmentChooser(List<Symptom> symptoms)
        {
            symptomNameList = new List<string>();
            treatmentList = new List<Treatment>();
            AddToSymptomNameList(symptoms);
            DefineTreatment();
        }

        public List<Treatment> ReturnTreatmentList()
        {
            return treatmentList;
        }
        private void AddToSymptomNameList(List<Symptom> symptoms)
        {
            foreach (Symptom symptom in symptoms)
            {
                symptomNameList.Add(symptom.name);
            }
        }
        private void DefineTreatment()
        {
            if (symptomNameList.Contains("Cough") && symptomNameList.Contains("Sneezing"))
            {
                Treatment fluShot = new Treatment("Flu Shot", symptomNameList, "Take this flu shot and rest.");
                treatmentList.Add(fluShot);
            }
            else if (symptomNameList.Contains("Bloody Stool") && symptomNameList.Contains("Constipation"))
            {
                Treatment hemorrhoids = new Treatment("Hemorrhoids", symptomNameList, "Take this flu shot and rest.");
                treatmentList.Add(hemorrhoids);
            }
            else if (symptomNameList.Contains("Broken Bone"))
            {
                Treatment cast = new Treatment("Cast", symptomNameList, "Here's a cast for your broken bone. Now take it easy. You can't do any physical exertion for at least a month.");
                treatmentList.Add(cast);
            }
            else if (symptomNameList.Contains("Lasceration"))
            {
                Treatment stitches = new Treatment("Stitches", symptomNameList, "We're going to stitch you up. Try to rest for the nest week. No running or lifting of heavy weights for at least 2 days.");
                treatmentList.Add(stitches);
            }
            else if (symptomNameList.Contains("Jaundice") && symptomNameList.Contains("Vomiting") && symptomNameList.Contains("Diarrhea") && symptomNameList.Contains("Bloody Stool"))
            {
                Treatment removeGallBladder = new Treatment("Remove Gall Bladder", symptomNameList, "Your symptoms are very serious. We're going to put you under and remove your Gall Bladder. You can take some time with your loved ones before the procedure.");
                treatmentList.Add(removeGallBladder);
            }
            else if (symptomNameList.Contains("Cough"))
            {
                Treatment coughDrops = new Treatment("Cough Drops", symptomNameList, "Take these cough drops for your cough.");
                treatmentList.Add(coughDrops);
            }
        }
    }
}
//"Cough","Bloody Stool","Broken Bone","Lasceration","Tumor","Sneezing","Jaundice","Diarrhea","Constipation","Vomiting"