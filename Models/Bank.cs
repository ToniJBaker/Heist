using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist {
    public class Bank { //new class Bank
        public int CashOnHand {get; set;}
        public int AlarmScore {get; set;}
        public int VaultScore {get; set;}
        public int SecurityGuardScore {get; set;}
        public bool IsSecure{
            get{
            if(AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
            {
                return true;
            }
            else
            {
                return false;
            }}
        }
        
        //using a list in Bank Class to order the bank property values...I used a dictionary instead in program.cs
        // public void Report()
        // {
        //     List<KeyValuePair<string, int>> stats = new List<KeyValuePair<string, int>>();
        //     stats.Add(new KeyValuePair<string, int>("Alarm Score", AlarmScore));
        //     stats.Add(new KeyValuePair<string, int>("Vault Score", VaultScore));
        //     stats.Add(new KeyValuePair<string, int>("Security Guard Score", SecurityGuardScore));

        //     List<KeyValuePair<string, int>> orderStats = stats.OrderBy(x => x.Value).ToList();
        //     Console.WriteLine($"Most Secure:{orderStats[2].Key}");
        //     Console.WriteLine($"Least Secure:{orderStats[0].Key}");

        // }
        
         



    }


}