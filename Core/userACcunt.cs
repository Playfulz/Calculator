using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stuf.Commands.Challenges;

namespace stuf.Commands
{
    public class UserAccount
    {
        public ulong ID { get; set; }
        public uint Cherries { get; set; }
        public uint XP { get; set; }
        public uint Lvl
        {
            get
            {
                return (uint)Math.Sqrt(XP / 5000);
            }
        }
        public uint Baguette { get; set; } 
        public List<Challenge> ChallengesCompleted { get; set; }
    }
}
