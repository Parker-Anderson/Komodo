﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_Repo;


namespace Komodo_ConsoleUI
{
    public class ProgramUI
    {
       private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        

        private DevRepo _devRepo = new DevRepo();


        public void Run()
        {

            Menu();

        }

        private void Menu()
        {
            SeedTeamList();
            SeedDevList();
            
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a Menu Option:\n" +
                    "1. View Developer List.\n" +
                    "2. View Team List.\n" +
                    "3. View Developers Needing PluralSight Access.\n" +
                    "4. Create New Team.\n" +
                    "5. Add Developer(s) to Team.\n" +
                    "6. Remove Developer from Team.\n" +
                    "7. Exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewDevList();
                        break;
                    case "2":
                        ViewTeamList();
                        break;
                    case "3":
                        NeedPSList();
                        break;
                    case "4":
                        CreateTeam();
                        break;
                    case "5":
                        AddDev();
                        
                        Console.WriteLine("Do you want to add another Developer? y/n:");
                        string choice = Console.ReadLine();
                        while (choice == "y")
                        {
                            AddDev();
                            Console.WriteLine("Do you want to add another Developer? y/n:");
                            string loopchoice = Console.ReadLine();
                            if(loopchoice == "y")
                            {
                                AddDev();
                            }
                            else
                            {
                                break;
                            }
                           
                      

                        }
                  
                        break;
                    case "6":
                        RemoveDev();
                        
                        break;
                    case "7":
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please Enter a Valid Selection.");
                        break;


                }
                Console.WriteLine("Press Any Key to Continue:");
                Console.ReadKey();
                Console.Clear();


            }
        }
        private void ViewDevList()
        {
            List<Developer> developers = _devRepo.GetDevList();

            foreach (Developer developer in developers)
            {
                Console.Clear();
                Console.WriteLine($"Name: {developer.DevName}\n" +
                    $"ID Number: {developer.DevID}\n" +
                    $"Access to PluralSight? {developer.AccessToPluralsight}");
            }
            
            

        }

        private void ViewTeamList()
        {
            List<DevTeam> listofTeams = _devTeamRepo.GetTeamList();
            
            foreach (DevTeam team in listofTeams)
            {
                Console.Clear();
                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                    $"Team ID: {team.TeamID}\n" +
                    $"Team Members: {team.TeamMembers}");
            }

        }

        private bool NeedPSList()
        {
            List<Developer> developers = new List<Developer>();
            Console.Clear();
            foreach (Developer developer in developers)
            {
                if (developer.AccessToPluralsight == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
            
            

        }

        private void CreateTeam()
        {
            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter the Name of the Team:");
            newTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Enter the Team ID number:");
            string teamIDString = Console.ReadLine();
            int newTeamID = int.Parse(teamIDString);
            newTeam.TeamID = newTeamID;
            Console.WriteLine("Add Team Members from Main Menu.");
            

            
        }

        private void AddDev()
        {
            Developer newDev = new Developer();

            Console.WriteLine("Enter the Name of the Developer:");
            newDev.DevName = Console.ReadLine();
            Console.WriteLine("Enter the Unique Developer ID number:");
            string devidstring = Console.ReadLine();
            int devid = int.Parse(devidstring);
            newDev.DevID = devid;
            Console.WriteLine("Does the Developer have access to PluralSight? y/n:");
            string devps = Console.ReadLine();
            newDev.DevPS = devps;


        }

        private void RemoveDev()
        {
            Console.WriteLine("Team ID number:");
            string idstring = Console.ReadLine();
            int teamid = int.Parse(idstring);
            Console.WriteLine("Developer to Remove (ID number):");
            string devidstring = Console.ReadLine();
            int devid = int.Parse(devidstring);
            _devTeamRepo.GetTeambyID(teamid);
            Developer deletedev = _devRepo.GetDevbyID(devid);
            
            _devTeamRepo.RemoveDevFromTeam(teamid, deletedev);

        }

        private void SeedDevList()
        {
            Developer john = new Developer("John", 1, true);
            Developer bob = new Developer("Bob", 2, false);
            Developer jane = new Developer("Jane", 3, false);


            _devRepo.AddDeveloper(john);
            _devRepo.AddDeveloper(bob);
            _devRepo.AddDeveloper(jane);

        }

        private void SeedTeamList()
        {
            List<Developer> developers = new List<Developer>();
            List<Developer> developers_2 = new List<Developer>();
            DevTeam team1 = new DevTeam(developers, "Red Team", 1);
            DevTeam team2 = new DevTeam(developers_2, "Blue Team", 2);


            _devTeamRepo.CreateNewTeam(team1);
            _devTeamRepo.CreateNewTeam(team2);
        }
    }

    
}
