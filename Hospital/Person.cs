﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public abstract class Person : Iperson
    {
        public DateTime DOB;
        public int patientNum;
        public string firstName;
        public string middleName;
        public string lastName;
        public string address1;
        public string address2;
        public string dateOfBirth;
        public string state;
        public string height;
        public string weight;
        public string SSN;
        public string emailAddress;
        public string phoneNumber;
        public string zipCode;
        public string city;
        public void talk()
        {
        }
        public void Listen(List<string> sentence)
        {
            List<string> response = new List<string>();
            foreach (string word in sentence)
            {
                response.Add(word);
            }
        }
        public void Wait()
        {

        }
        //public List<string> GiveSymptoms()
        //{
        //    return Symptoms;
        //}
        //public string GiveName()
        //{
        //    return name;
        //}
        //public int GiveAge()
        //{
        //    return age;
        //}
        //public bool GiveHealthIns()
        //{
        //    return healthIns;
        //}

    }
}
