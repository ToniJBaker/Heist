using System;
using System.Collections.Generic;

namespace Heist
{
    public class Member //new class Member
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public double CourageFactor {get; set;}

        public void MemberInfo(){
            Console.WriteLine($"---------------------");
            Console.WriteLine($"{Name}: Skill Level:{SkillLevel}, Courage Factor:{CourageFactor}");
        }
        
    }


}