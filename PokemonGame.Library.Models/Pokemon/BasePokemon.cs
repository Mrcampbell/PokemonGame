using PokemonGame.Library.Models.Health;
using PokemonGame.Library.Models.Move;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public abstract class BasePokemon
    {
        // for IV
        private Random random;

        private string _name;
        private int _level;

        public HealthPoints HP;

        public Element.Type ElementOne { get; set; }
        public Element.Type ElementTwo { get; set; }
        public MoveSet Moves { get; set; } 

        // Breed Specific Stat Group
        private StatGroup _base_stat_group;

        // Individual Value Stat Group
        private StatGroup _iv_stat_group;

        // Effort Value Stat Group
        private StatGroup _ev_stat_group;

        // This is the result of all the groups combined.
        // it's the reference of the stat of the pokemon in battle and in the game.
        // it is updated whenever the other stat groups are updated.
        private readonly StatGroup _live_stat_group;

        public BasePokemon(string name, int level, Element.Type e1, Element.Type e2, StatGroup baseStatGroup)
        {
            Name = name;
            Level = level;
            ElementOne = e1;
            ElementTwo = e2;

            random = new Random();

            _base_stat_group = baseStatGroup;
            _live_stat_group = new StatGroup();
            _iv_stat_group = new StatGroup();
            _ev_stat_group = new StatGroup();
            Moves = new MoveSet();

            _initializeIVStatGroup();
            _initializeEVStatGroup();
            _updateLiveStatGroup();

            // set HP max from Live Stat
            HP = new HealthPoints(Stat.HP);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) && value.Length > 10)
                {
                    throw new ArgumentException("Name is either empty or too long.");
                }
                 _name = value;

            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (value < 1 || value > 100)
                    throw new ArgumentOutOfRangeException("Level out of Range");

                _level = value;
            }
        }

        private StatGroup BaseStat
        {
            get { return _base_stat_group; }
            set
            {
                _base_stat_group = value;
                _updateLiveStatGroup();
            }
        }

        private StatGroup EVStat
        {
            get { return _ev_stat_group; }
            set
            {
                _ev_stat_group = value;
                _updateLiveStatGroup();
            }
        }

        private StatGroup IVStat
        {
            get { return _iv_stat_group; }
            set
            {
                _iv_stat_group = value;
                _updateLiveStatGroup();
            }
        }

        public StatGroup Stat
        {
            get { return _live_stat_group; }
            // no set
        }


        private void _updateLiveStatGroup()
        {
            Stat.HP = StatGroup.CalculateHp(Level, BaseStat.HP, IVStat.HP, EVStat.HP);
            Stat.Attack = StatGroup.CalculateStat(Level, BaseStat.Attack, IVStat.Attack, EVStat.Attack);
            Stat.Defense = StatGroup.CalculateStat(Level, BaseStat.Defense, IVStat.Defense, EVStat.Defense);
            Stat.SpecAttack = StatGroup.CalculateStat(Level, BaseStat.SpecAttack, IVStat.SpecAttack, EVStat.SpecAttack);
            Stat.SpecDefense = StatGroup.CalculateStat(Level, BaseStat.SpecDefense, IVStat.SpecDefense, EVStat.SpecDefense);
            Stat.Speed = StatGroup.CalculateStat(Level, BaseStat.Speed, IVStat.Speed, EVStat.Speed);
        }

        private void _initializeIVStatGroup()
        {
            Random r = new Random();

            _iv_stat_group.HP = IV_RAND();
            _iv_stat_group.Attack = IV_RAND();
            _iv_stat_group.Defense = IV_RAND();
            _iv_stat_group.SpecAttack = IV_RAND();
            _iv_stat_group.SpecDefense = IV_RAND();
            _iv_stat_group.Speed = IV_RAND();
        }

        private int IV_RAND()
        {
            return random.Next(1, 15);
        }

        private void _initializeEVStatGroup()
        {
            _ev_stat_group.HP = 1;
            _ev_stat_group.Attack = 1;
            _ev_stat_group.Defense = 1;
            _ev_stat_group.SpecAttack = 1;
            _ev_stat_group.SpecDefense = 1;
            _ev_stat_group.Speed = 1;
        }

        [Conditional("DEBUG")]
        public void SetIV(StatGroup iv)
        {
            _iv_stat_group = iv;
        }

        [Conditional("DEBUG")]
        public void SetEV(StatGroup ev)
        {
            _ev_stat_group = ev;
        }

        public override string ToString()
        {
            string output = "";
            output += "Pokemon:";
            output += "\n  Name: " + Name;
            output += "\n  Level: " + Level;
            output += "\n  Base Stat: " + BaseStat;
            output += "\n  IV Stat: " + IVStat;
            output += "\n  EV Stat: " + EVStat;
            output += "\n  Live Stat: " + Stat;
            output += "\n  Moves: " + Moves.ToString();

            return output;
        }

        public string PrintBasic()
        {
            string output = "Pokemon:";
            output += "\nName:  " + Name;
            output += "\nLevel:  " + Level;
            output += "\nHealth: " + HP;
            output += "\nStats:  " + Stat;
            output += "\nMoves:  " + Moves;
            return output;
        }
    }
}
