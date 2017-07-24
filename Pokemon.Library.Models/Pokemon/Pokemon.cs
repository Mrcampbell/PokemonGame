using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.PokemonGame
{
    public class Pokemon : IPokemon
    {
        private string _name;
        private int _level;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && value.Length < 10)
                {
                    _name = value;
                }
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (1 <= value && value <= 100)
                {
                    _level = value;
                }
            }
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "" +
                "Pokemon: " +
                "Name: " + Name +
                "Level: " + Level;
        }
    }
}
