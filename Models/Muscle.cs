using System;
namespace Heist {
    public class Muscle : IRobber
    {   public string Name {get; set;} //string property for Name
        public int SkillLevel {get; set;}//int property for Skill Level
        public int PercentCut {get; set;}//int property for Percent Cut
        public string Specialty {get; set;}//string property for Specialty
        
        public void PerformSkill(Bank bank)
        {
          bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel ;
          Console.WriteLine($"{Name} is cracking the vault. Decreased the security guard muscle by {SkillLevel} points."); 
          if(bank.SecurityGuardScore <=0)
          {
            Console.WriteLine($"{Name} has taken out all the security guards!");
          }
        }
    }
}