using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo
{
    public class DevTeam
    {
        public List<Developer> TeamMembers { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }


        public DevTeam() { }

        public DevTeam(List<Developer> teammembers, string teamname, int teamid )
        {
            TeamMembers = teammembers;
            TeamName = teamname;
            TeamID = teamid;


        }
    }

    


}
