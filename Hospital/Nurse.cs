using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Nurse : MedProfessional
    {
        public Nurse(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
