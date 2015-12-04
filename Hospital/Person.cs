using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public abstract class Person
    {
<<<<<<< HEAD
=======
        public List<string> Symptoms;
        public string name;
        public int age;
        public DateTime DOB;
        public string phoneNumber;
        public bool healthIns;
        public bool available;
>>>>>>> b3f0720a8892b35801f71792aebc2c10a2aab978
        public void Talk(List<string> sentence)
        {
            foreach (string word in sentence)
            {
                Console.WriteLine(word);
            }
        }
        public void Listen(List<string> sentence)
        {
            List<string> response = new List<string>();
            foreach (string word in sentence)
            {
                response.Add(word);
            }
            Talk(response);
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
