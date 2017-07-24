using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Move
{
    public abstract class BaseMove
    {
        private string _name;
        private Element.Type _type;
        private int _power;

        public BaseMove(string name, Element.Type type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                // TODO: Extract to single location
                if (String.IsNullOrWhiteSpace(value) || value.Length > 13)
                    throw new ArgumentException("Move name must be between 1 and 10 characters");

                _name = value;
            }
        }

        public Element.Type Type
        {
            get { return _type; }
            set
            {
                // TODO: Is there any validation?
                _type = value;
            }
        }

        public int Power
        {
            get { return _power; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Attack Power Must Be Greater than Zero");

                _power = value;
            }
        }

        public override string ToString()
        {
            string output = "";
            output += "Move: ";
            output += "\n  Name:  " + Name;
            output += "\n  Type:  " + Type;
            output += "\n  Power: " + Power;

            return output;
        }
    }
}
