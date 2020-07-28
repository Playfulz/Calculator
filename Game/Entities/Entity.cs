using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Game.Entities {

    public abstract class Entity {
        
        private int Appearance { get; set; }
        private int[] Stats { get; set; }
        public List<Action> Attacks { get; set; }

        public int Hp {
            get {
                return Stats[0];
            }
            set {
            }
        }
        public int Attack {
            get {
                return Stats[1];
            }
            set {
            }
        }
        public int Defense {
            get {
                return Stats[2];
            }
            set {
            }
        }
        public int Magic {
            get {
                return Stats[3];
            }
            set {
            }
        }
        public int MagicDefense {
            get {
                return Stats[4];
            }
            set {
            }
        }
        public int Speed {
            get {
                return Stats[5];
            }
            set {
            }
        }
        public int Gold {
            get {
                return Stats[6];
            }
            set {
            }
        }
        public int Xp {
            get {
                return Stats[7];
            }
            set {
            }
        }
        public int Level {
            get {
                return Stats[8];
            }
        }


        public Entity(int appearance, int[] stats) {
            Appearance = appearance;
            Stats = new int[9];
            for(int i = 0; i < stats.Length; i++) {
                Stats[i] = stats[i];
            }
            Stats[8] = (int)Math.Floor(Math.Sqrt(Stats[7] / 50));
        }
        
        public Entity(int appearance, int hp, int atk, int def, int magic, int magdef, int speed, int gold, int xp) {
            Appearance = appearance;
            Stats = new int[9];
            Stats[0] = hp;
            Stats[1] = atk;
            Stats[2] = def;
            Stats[3] = magic;
            Stats[4] = magdef;
            Stats[5] = speed;
            Stats[6] = gold;
            Stats[7] = xp;
            Stats[8] = (int)Math.Floor(Math.Sqrt(xp / 50));
        }

        public override string ToString() {
            return "" + Appearance;
        }

        public string DisplayStats() {
            string statsToString = 
            "Hp: " + Hp + "\n" +
            "Attack: " + Attack + "\n" +
            "Defense: " + Defense + "\n" +
            "Magic: " + Magic + "\n" +
            "Magic Defense: " + MagicDefense + "\n" +
            "Speed: " + Speed + "\n" +
            "Gold: " + Gold + "\n" +
            "Xp: " + Xp + "\n" +
            "Lvl: " + Level + "\n";

            return statsToString;
        }
        
    }
}