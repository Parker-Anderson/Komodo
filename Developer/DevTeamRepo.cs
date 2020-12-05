using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo
{
    public class DevTeamRepo
    {
         private List<DevTeam> _devTeams = new List<DevTeam>();
        

        public void CreateNewTeam(DevTeam newteam)
        {
            _devTeams.Add(newteam);

        }


        

        public List<DevTeam> GetTeamList()
        {

            return _devTeams;
        }

        //Update 

        public bool UpdateExistingTeam(int originalTeamID, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeambyID(originalTeamID);

            if (oldTeam != null)
            {
                oldTeam.TeamID = newTeam.TeamID;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddDevToTeam(int originalTeamId, Developer newDev)
        {
            DevTeam oldTeam = GetTeambyID(originalTeamId);

            oldTeam.TeamMembers.Add(newDev);
        }

        public void RemoveDevFromTeam(int originalTeamId, Developer devRemove)
        {
            DevTeam oldTeam = GetTeambyID(originalTeamId);

            oldTeam.TeamMembers.Remove(devRemove);
        }



       

        public bool RemoveTeamfromList(int Teamid)
        {
            DevTeam devteam = GetTeambyID(Teamid);

            if (devteam == null)
            {
                return false;
            }

            int initialcount = _devTeams.Count;
            _devTeams.Remove(devteam);

            if (initialcount > _devTeams.Count)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public DevTeam GetTeambyID(int teamid)
        {
            foreach (DevTeam devteam in _devTeams)
            {
                if (devteam.TeamID == teamid)
                {
                    return devteam;
                }

            }
            return null;
        }
    }
}
