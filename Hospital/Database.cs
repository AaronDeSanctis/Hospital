using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Hospital
{
    public class Database
    {
        string filePath = Path.GetFileName("xmlDC.xml");
        public void Save(Patient patient)
        {
            writePatient(filePath, patient, true);
        }
        public void Overwrite(Patient patient)
        {
            writePatient(filePath, patient, false);
        }

        public Patient Read(Patient patient)
        {
            return readPatient(filePath, patient);
        }
        private void writePatient(string filePath, Patient patient, bool append)
        {
            TextWriter writer = null;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(patient.GetType());
            writer = new StreamWriter(filePath, append);
            serializer.Serialize(writer, patient);
            if (writer != null)
                writer.Close();
        }
        private Patient readPatient(string filePath, Patient patient)
        {
            TextReader reader = null;
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(patient.GetType());
            reader = new StreamReader(filePath);
            return (Patient)serializer.Deserialize(reader);
        }
    }
}
