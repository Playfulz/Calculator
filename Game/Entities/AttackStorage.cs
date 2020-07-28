using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Game.Entities {

    public class AttackStorage {

        public static void Bite(Entity current, Entity other) {
            other.Hp -= 1 + current.Attack;
        }
        
    }











}