using System;
using System.Linq;
namespace Heist {
    public class Hacker : IRobber
    {
        public string Name {get; set;}//string property for Name
        public int SkillLevel {get; set;}//int property for Skill Level
        public int PercentCut {get; set;}//int property for Percent Cut
        public string Specialty {get; set;}//string property for Specialty

        public void PerformSkill(Bank bank)
        {
          bank.AlarmScore -= SkillLevel ;
          Console.WriteLine($"{Name} is hacking the alarm System. Decreased security by {SkillLevel} points."); 
          if(bank.AlarmScore <=0)
          {
            Console.WriteLine($"{Name} has disabled the security system!");
          }
        }
        
        

        
    }
    
}