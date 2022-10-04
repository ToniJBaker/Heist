using System;
namespace Heist {
public class LockSpecialist : IRobber
    {
        public string Name {get; set;}//string property for Name
        public int SkillLevel {get; set;}//int property for Skill Level
        public int PercentCut {get; set;}//int property for Percent Cut
        public string Specialty {get; set;}//string property for Specialty

        public void PerformSkill(Bank bank)
        {
          bank.VaultScore = bank.VaultScore - SkillLevel ;
          Console.WriteLine($"{Name} is cracking the vault. Decreased the vault security by {SkillLevel} points."); 
          if(bank.VaultScore <=0)
          {
            Console.WriteLine($"{Name} has opened the Vault!");
          }
        }
    }
}