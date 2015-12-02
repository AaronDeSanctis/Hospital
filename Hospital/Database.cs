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
        string filePath = Path.GetFileName("xmlDC.xml");
        filePath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
        //string filePath2 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        filePath = filePath + "xmlDC.xml";

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
        private void writePatient(string filePath, Patient patient)
        {
            try
            {
                XmlSerializer serializerObj = new XmlSerializer(typeof(Patient));
                TextWriter writeFileStream = new StreamWriter(filePath);
                serializerObj.Serialize(writeFileStream, patient);
                writeFileStream.Close();
            }
            catch
            {
                return false;
            }
            
        }
        private Patient readPatient(string filePath, Patient patient)
        {
            try
            {
                XmlSerializer serializerObj = new XmlSerializer(typeof(Patient));
                FileStream readFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var patient = (Patient)serializerObj.Deserialize(readFileStream);
                readFileStream.Close();
                return patient;
            }
            catch
            {
                return false;
            }
        }
    }
}
