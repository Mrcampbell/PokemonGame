using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public class StatGroup
    {
        private int _hp;
        private int _atk;
        private int _def;
        private int _spec_atk;
        private int _spec_def;
        private int _speed;

        public StatGroup() { }

        public StatGroup(int hp, int atk, int def, int specAtk, int specDef, int speed)
        {
            HP = hp;
            Attack = atk;
            Defense = def;
            SpecAttack = specAtk;
            SpecDefense = specDef;
            Speed = speed;
        }

        private int _validate(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("Stat index must be above zero");
        
            else
                return n;
        }

        public int HP          { get { return _hp;       } set { _hp       = _validate(value); } }
        public int Attack      { get { return _atk;      } set { _atk      = _validate(value); } }
        public int Defense     { get { return _def;      } set { _def      = _validate(value); } }
        public int SpecAttack  { get { return _spec_atk; } set { _spec_atk = _validate(value); } }
        public int SpecDefense { get { return _spec_def; } set { _spec_def = _validate(value); } }
        public int Speed       { get { return _speed;    } set { _speed    = _validate(value); } }

        // TODO: Fill out StatGroup IsValid
        public bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// This method follows the Gen I and Gen II stat calculation model. 
        /// http://bulbapedia.bulbagarden.net/wiki/File:StatExampleHPGen2.png
        /// </summary>
        public static int CalculateStat(int level, int baseStat, int ivStat, int evStat)
        {
            double a = (baseStat + ivStat) * 2;
            double b = Math.Floor(
                Math.Ceiling(Math.Sqrt(evStat) / 4)
                    );
            double c = (a + b) * level;

            return (int)Math.Floor(c / 100) + 5;
        }

        public static int CalculateHp(int level, int baseHp, int ivHp, int evHp)
        {
            return CalculateStat(level, baseHp, ivHp, evHp) + 5 + level;
        }

        public override string ToString()
        {
            string output = "";
            output += "Stat Group:";
            output += "\n  HP:    " + HP;
            output += "\n  ATK:   " + Attack;
            output += "\n  DEF:   " + Defense;
            output += "\n  SpATK: " + SpecAttack;
            output += "\n  SpDEF: " + SpecDefense;
            output += "\n  SPEED: " + Speed;

            return output;
        }
    }
}
