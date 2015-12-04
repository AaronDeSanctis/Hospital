using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public abstract class Person
    {
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
