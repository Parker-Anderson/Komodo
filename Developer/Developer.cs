using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo
{
    
    public class Developer
    {

        
        public string DevName { get; set; }
        public int DevID { get; set; }
        public bool AccessToPluralsight { get; set; }

       

        public Developer() { }

        public Developer(string devname, int devid, bool accesstopluralsight)
        {
            DevName = devname;
            DevID = devid;
            AccessToPluralsight = accesstopluralsight;


        }

        
    }
}
