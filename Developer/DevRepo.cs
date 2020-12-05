using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo
{
    
    public class DevRepo

        

    {
        public List<Developer> _devList = new List<Developer>();

        




        public List<Developer> DevList { get; set; }
        
        public void AddDeveloper(Developer newdev)
        {
            _devList.Add(newdev);

        }
        
        public List<Developer> GetDevList()
        {
           
            return _devList;
        }

       
        public bool UpdateExistingDev(int originalID, Developer newDev)
        {
            Developer oldDev = GetDevbyID(originalID);

            if (oldDev != null)
            {
                oldDev.DevID = newDev.DevID;
                oldDev.DevName = newDev.DevName;
                oldDev.AccessToPluralsight = newDev
                    .AccessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }




        
        public bool RemoveDevfromList(int devid)
        {
            Developer developer = GetDevbyID(devid);

            if(developer == null)
            {
                return false;
            }

            int initialcount = _devList.Count;
            _devList.Remove(developer);

            if(initialcount > _devList.Count)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public Developer GetDevbyID(int devid)
        {
            foreach (Developer developer in _devList)
            {
                if(developer.DevID == devid)
                {
                    return developer;
                }

            }
            return null; 
        }

        public Developer NeedPluralList(bool devplural)
        {
            foreach (Developer developer in _devList)
            {
                if (developer.AccessToPluralsight == false)
                {
                    return developer;

                }
            }
            return null;
        }
    }
}
