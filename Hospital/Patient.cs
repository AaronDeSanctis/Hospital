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
        public Patient()
        {
            SymptomList = new List<string>();
            rand = new Random();
            GiveRandomPatientNum();
        }
        public void GiveRandomPatientNum()
        {
            this.patientNum++;
            List<Patient> patients = new List<Patient>();
            Database db = new Database();
            //patients = db.ReadAllPatients();
            foreach(Patient patient in patients)
            {
                if (patient.patientNum == this.patientNum)
                {
                    GiveRandomPatientNum();
                }
            }
        }
        public void SetFirstName(string FirstName)
        {
            this.firstName = FirstName;
        }
        public void SetMiddleName(string MiddleName)
        {
            this.middleName = MiddleName;
        }
        public void SetLastName(string LastName)
        {
            this.lastName = LastName;
        }
        public void SetAddress1(string Address1)
        {
            address1 = Address1;
        }
        public void SetAddress2(string Address2)
        {
            address2 = Address2;
        }
        public void SetCity(string City)
        {
            city = City;
        }
        public void SetState(string State)
        {
            state = State;
        }
        public void SetZipCode(string ZipCode)
        {
            zipCode = ZipCode;
        }
        public void SetPhoneNumber(string PhoneNumber)
        {
            phoneNumber = PhoneNumber;
        }
        public void SetSSN(string SSN)
        {
            this.SSN = SSN;
        }
        public void SetEmail(string EmailAddress)
        {
            emailAddress = EmailAddress;
        }
        public void CreateInsurance(string Insurance1, string Insurance2, string Insurance3, string Insurance4)
        {
            
        }
        public void SetHeight(string Height)
        {
            height = Height;
        }
        public void SetWeight(string Weight)
        {
            weight = Weight;
        }
        public void SetDateOfBirth(string DateOfBirth)
        {
            dateOfBirth = DateOfBirth;
        }

        public string GiveName()
        {
            return firstName + "" + middleName + " " + lastName;
        }
    }
}