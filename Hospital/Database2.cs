using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections;

namespace Hospital
{
    public class NewDatabase
    {
        string filePath = Path.GetFileName("xmlDB.xml");
        private void SerializeCollection(string filename, Patient patientObj)
        {
            Patients patientDB = new Patients();
            patientDB.CollectionName = "Patients";
            patientDB.Add(patientObj);
            XmlSerializer x = new XmlSerializer(typeof(Patient));
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, patientDB);
        }

        public void Save (Patient patientObj)
        {
            SerializeCollection(filePath, patientObj);
        }



    }
    public class Patients : ICollection
    {
        public string CollectionName;
        private ArrayList patientArray = new ArrayList();

        public Patient this[int index]
        {
            get { return (Patient)patientArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            patientArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return patientArray.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return patientArray.GetEnumerator();
        }

        public void Add(Patient newPatient)
        {
            patientArray.Add(newPatient);
        }
    }
}
