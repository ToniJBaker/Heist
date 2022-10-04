using System;
namespace Heist {
    public interface IRobber {
        string Name {get; set;} //string property for Name
        int SkillLevel {get; set;}//int property for Skill Level
        int PercentCut {get; set;}//int property for Percent Cut
        string Specialty {get; set;} // string property for Specialty
        void PerformSkill(Bank bank); //method for performing a skill on a bank
    }
}