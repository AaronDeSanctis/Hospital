using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Hospital
{
    public class Database
    {
        string filePath = Path.GetFileName("xmlDB.xml");
        public void Save(Patient patient)
        {
            writePatient(filePath, patient);
        }
        public void Overwrite(Patient patient)
        {
            writePatient(filePath, patient);
        }

        public Patient Read(Patient patient)
        {
            return readPatient(filePath, patient);
        }
        private bool writePatient(string filePath, Patient patient)
        {
            try
            {
                XmlSerializer serializerObj = new XmlSerializer(typeof(Patient));
                TextWriter writeFileStream = new StreamWriter(filePath);
                serializerObj.Serialize(writeFileStream, patient);
                writeFileStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        private Patient readPatient(string filePath, Patient patient)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(Patient));
            FileStream readFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var p = (Patient)serializerObj.Deserialize(readFileStream);
            readFileStream.Close();
            return p;
        }
    }
}
