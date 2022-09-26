using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("-----------------------");
            MemberQuestions();

        }
        static void MemberQuestions()
        {
            Console.WriteLine($"How difficult will it be to rob this bank? 1-100"); //print question
            int difficultyLevel = int.Parse(Console.ReadLine()); //save input int as value difficultyLevel
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

            Console.WriteLine($"Would you like to add an additional Member? y/n");
            string keepGoing = Console.ReadLine();
            if(keepGoing == "n"){
                                
                Console.WriteLine($"How many heist trial runs would you like? 1-8");
                int trialRuns = int.Parse(Console.ReadLine());
                               
                List<bool> SuccessList = new List<bool>(); //define a list to hold booleans for success or failure
                List<bool> FailureList = new List<bool>(); //define a list to hold booleans for success or failure

                for(int i =0; i < trialRuns; i++){
                int numberOfMembers = newTeam.TeamMembers.Count;
                
                // int difficultyLevel = 100;
                Random rNum = new Random();
                int luckValue = rNum.Next(-10, 10);
                int bankFinalDifficulty = luckValue + difficultyLevel; //adding luck value with the difficulty of robbing bank

                int cumulativeSkillLevel = 0;
                foreach(Member singleMember in newTeam.TeamMembers){
                    cumulativeSkillLevel +=singleMember.SkillLevel;
                }
                Console.WriteLine($"----------------------");
                Console.WriteLine($"Teams combined Skill Level is:{cumulativeSkillLevel}");
                Console.WriteLine($"Banks Difficulty Level is: {bankFinalDifficulty} ");
               
                
                if(cumulativeSkillLevel >= bankFinalDifficulty)
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
    

