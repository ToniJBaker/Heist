using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bankToRob = new Bank() //new bank
            {  
                CashOnHand = new Random().Next(50000, 1000001),
                AlarmScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
            };
            Dictionary<string, int> BankScores = new Dictionary<string, int>();//dictionary of key/value pairs for Bank properties
                BankScores.Add("AlarmScore", bankToRob.AlarmScore);
                BankScores.Add("VaultScore", bankToRob.VaultScore);
                BankScores.Add("SecurityGuardScore", bankToRob.SecurityGuardScore);
            
            var sortedByVal = //query statement to order Bank values
            (from score in BankScores
            orderby score.Value descending
            select score).ToList();

            // Console.WriteLine($"Most Secure:{sortedByVal[0].Key}"); //placed below
            // Console.WriteLine($"Least Secure: {sortedByVal[2].Key}");
            
            Hacker gabe = new Hacker()//new crew member
            {
                Name = "Gabe",
                Specialty = "Hacker",
                SkillLevel = 80,
                PercentCut = 13
            };
            Hacker becca = new Hacker() //new crew member
            {
                Name = "Becca",
                Specialty = "Hacker",
                SkillLevel = 80,
                PercentCut = 15
            };
            LockSpecialist shawn = new LockSpecialist() //new crew member
            {
                Name = "Shawn",
                Specialty = "Lock Specialist",
                SkillLevel = 67,
                PercentCut = 18
            };
            LockSpecialist chantell = new LockSpecialist() //new crew member
            {
                Name = "Chantell",
                Specialty = "Lock Specialist",
                SkillLevel = 76,
                PercentCut = 6
            };
            Muscle josh = new Muscle() //new crew member
            {
                Name = "Josh",
                Specialty = "Muscle",
                SkillLevel = 75,
                PercentCut = 22
            };
            Muscle toni = new Muscle() //new crew member
            {
                Name = "Toni",
                Specialty = "Muscle",
                SkillLevel = 62,
                PercentCut = 18
            };
            
            List<IRobber> possibleTeam = new List<IRobber>() //Rolodex List with possible Crew
            {
                gabe, becca, shawn, chantell, josh, toni
            };
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("-----------------------");
            
          
        while(true){
            Console.WriteLine($"There are {possibleTeam.Count} robbers to choose from.");//# in hard coded crew
            Console.WriteLine($"Add a new crew member. Enter a name here.");
            string name = Console.ReadLine();
            // if(string.IsNullOrWhiteSpace(name))// or name = "" //possible way to break loop
            // {
            //     break;
            // }
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"What is {name}'s specialty?");
            Console.WriteLine($"Select (1) for- Hacker (Disable alarms?)");
            Console.WriteLine($"Select (2) for- Muscle (Disarm guards?)");
            Console.WriteLine($"Select (3) for- Lock Specialist (Crack vaults?)");
            string specialty = Console.ReadLine();
            
            bool Loop= true;
            while(Loop){
            switch (specialty)    
            {
                case "1":
                specialty = "Hacker";
                Loop = false;
                break;
                
                case "2":
                specialty = "Muscle";
                Loop = false;
                break;
                
                case "3":
                specialty = "Lock Specialist";
                Loop = false;
                break;

                default:
                break;
                };
            }
        
        
            
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"Between 1-100, what is {name}'s skill level?");//user adds skill level
            int skill = int.Parse(Console.ReadLine());
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"What percent cut will {name} demand?");//user adds percent cut
            int percent = int.Parse(Console.ReadLine());
            Console.WriteLine($"-------------------------");

            if( specialty  == "Hacker")//constructor to assign user input to either a Hacker, Lock Specialist or Muscle...
            {
                 Hacker newMember = new Hacker()
                {
                    Name =name,
                    SkillLevel = skill,
                    PercentCut = percent,
                    Specialty = specialty
                };
                possibleTeam.Add(newMember);
            }
            
            else if( specialty == "Muscle")
            {
                Muscle newMember = new Muscle()
                {
                    Name =name,
                    SkillLevel = skill,
                    PercentCut = percent,
                    Specialty = specialty
                };
                possibleTeam.Add(newMember);
            }
            
            else if( specialty == "Lock Specialist")
            {
                LockSpecialist newMember = new LockSpecialist()
                {
                    Name =name,
                    SkillLevel = skill,
                    PercentCut = percent,
                    Specialty = specialty
                };
                possibleTeam.Add(newMember);
            }
            Console.WriteLine($"Do you need to add another possible Crew Member? (y/n)");
           string moreCrewMembers = Console.ReadLine();
           if(moreCrewMembers == "n"){
            Console.WriteLine($"Most Secure:{sortedByVal[0].Key},{sortedByVal[0].Value} "); //display most secure bank security feature
            Console.WriteLine($"Least Secure: {sortedByVal[2].Key}, {sortedByVal[2].Value}");//display least secure bank security feature
            Console.WriteLine($"-------------------------");

            Console.WriteLine($"Time to assemble your crew:");
            break;
            }
        }
            
            
            List<IRobber> Crew = new List<IRobber>(); //new Crew list for user to add team members
            int currentCutCapacity = 0;
        while(true){ 
           Console.WriteLine($"Possible Crew Members are:");           
           for(int i=0; i < possibleTeam.Count; i++)
           {
            if(!Crew.Contains(possibleTeam[i]) && currentCutCapacity + possibleTeam[i].PercentCut < 90){
            Console.WriteLine($"Operative #{i + 1}-{possibleTeam[i].Name}: Specialty is {possibleTeam[i].Specialty}, Skill Level is {possibleTeam[i].SkillLevel}, Cut is {possibleTeam[i].PercentCut}%.");}
           }
          
           Console.WriteLine($"Which Crew member would you like to add to your team?");
            string selection = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(selection))// or selection = ""
            {
                break;
            }
            Crew.Add(possibleTeam[int.Parse(selection) - 1]);
            currentCutCapacity = Crew.Sum(x => x.PercentCut);
            Crew.ForEach(x => Console.WriteLine(x.Name));
            Console.WriteLine(currentCutCapacity);
        }

            Console.WriteLine($"Let the Heist Begin");
            Crew.ForEach(member => member.PerformSkill(bankToRob));       
            if(bankToRob.IsSecure)
            {
                Console.WriteLine($"Your Heist was a Failure!");
            }
            else
            {
                Console.WriteLine($"Congratulations, your Heist was a success!");
                
                int totalTake = bankToRob.CashOnHand;

                Crew.ForEach(member => {
                    Console.WriteLine($"{member.Name} took home {bankToRob.CashOnHand/member.PercentCut}");
                    totalTake -= (bankToRob.CashOnHand * member.PercentCut) / 100;
                });
                Console.WriteLine($"We made {totalTake} profit on this Heist!");
                
            }
        
           
           
           
           
        //    possibleTeam.ForEach(x => Console.WriteLine($"{x.Name}: Specialty-{x.Specialty}, Skill Level-{x.SkillLevel}, Cut-{x.PercentCut}%,"));
        //    break;}
        //   }

            
            // BuildTeam(); //call method to build a team- Heist Part 1
        }
        
        
        
        static void BuildTeam()
        {
            Console.WriteLine($"How difficult will it be to rob this bank? 1-100"); //print question
            int difficultyLevel = int.Parse(Console.ReadLine()); //save input int as value difficultyLevel of robbing the bank
            Console.WriteLine($"Lets Add Team Members...");//print comment
            Team newTeam = new Team();  //construct new Team
            
            while(true){
            
            Console.WriteLine($"What is your team member first and last name?"); //prompt add team member name
            string name = Console.ReadLine();
                
            Console.WriteLine($"What is you team member's Skill Level between 1(low)-100(high)?");//prompt add team member Skill Level
            int skill = int.Parse(Console.ReadLine());  //or Convert.ToInt32
            
            
            double courage = 0;
            while(true)
            {
                Console.WriteLine($"What is you team member's Courage Factor between 0.0(low)-2.0(high)?");//prompt add team member Courage Factor
                courage = double.Parse(Console.ReadLine());//or Convert.ToDouble
                if(courage >= 0 && courage <= 2)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            Member heistBuddy = new Member(){
                Name = name,
                SkillLevel = skill,
                CourageFactor = courage
            };
            
            newTeam.TeamMembers.Add(heistBuddy);
            
            
            // foreach(Member singleMember in newTeam.TeamMembers)
            // {
            //     singleMember.MemberInfo();
            // }

            Console.WriteLine($"Would you like to add an additional Member? y/n"); //prompt would you like to add a team member?
            string keepGoing = Console.ReadLine();
            if(keepGoing == "n"){
                //collecting the number of trial runs from the user                
                Console.WriteLine($"How many heist trial runs would you like? 1-8");
                int trialRuns = int.Parse(Console.ReadLine());
                               
                List<bool> SuccessList = new List<bool>(); //define a list to hold booleans for success 
                List<bool> FailureList = new List<bool>(); //define a list to hold booleans for failure

                for(int i =0; i < trialRuns; i++){
                int numberOfMembers = newTeam.TeamMembers.Count;
                
                // int difficultyLevel = 100;
                Random rNum = new Random();
                int luckValue = rNum.Next(-10, 10);
                int bankFinalDifficulty = luckValue + difficultyLevel; //adding luck value with the difficulty of robbing bank

                int cumulativeSkillLevel = 0; //adding skill levels of team members
                foreach(Member singleMember in newTeam.TeamMembers){
                    cumulativeSkillLevel +=singleMember.SkillLevel;
                }
                //or int teamSkill = newTeam.Sum(newTeam.TeamMembers = > newTeam.TeamMembers.SkillLevel);
                Console.WriteLine($"----------------------");
                Console.WriteLine($"Teams combined Skill Level is:{cumulativeSkillLevel}");
                Console.WriteLine($"Banks Difficulty Level is: {bankFinalDifficulty} ");
               
                
                if(cumulativeSkillLevel >= bankFinalDifficulty) //team skill is greater than difficulty of robbing the bank
                {
                    Console.WriteLine($"You will be successful! ");
                    SuccessList.Add(true);
                }
                else
                {
                    Console.WriteLine($"Foreseen Failure! ");
                    FailureList.Add(false);
                }
                
                };
                
                {
                    Console.WriteLine($"-----------------");
                    Console.WriteLine($"Trial Successes: {SuccessList.Count}");
                    Console.WriteLine($"Trial Failures: {FailureList.Count}");
                }

                
            //     Console.WriteLine($"Your {numberOfMembers} Team Members are:");
            //     foreach(Member singleMember in newTeam.TeamMembers)
            // {
            //     singleMember.MemberInfo();
            // }
                break;
            }
        }
    }
 
    }
}
    

