using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Game.Entities {

    

    public class Worm : Entity {
        public Worm(int[] stats) : base(1, stats) {
            Attacks.Add(() => AttackStorage.Bite(this, null));
        }
    }

}
