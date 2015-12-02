using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Insurance
    {
        private string iD;
        private string groupID;
        private string type;
        private string provider;
        public void checkInsurance() { /* Method statements here */ }

        public Insurance(string ID, string GroupID, string Type, string Provider)
        {
            this.iD = ID;
            this.groupID = GroupID;
            this.type = Type;
            this.provider = Provider;
        }
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Provider
        {
            get { return provider; }
            set { provider = value; }
        }
    }
}
