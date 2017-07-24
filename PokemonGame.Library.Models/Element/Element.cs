using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public partial class Element
    {
        public enum Type
        {
            NONE,
            NORMAL,
            ROCK,
            STEEL,
            GRASS,
            FAIRY,
            POISON,
            GROUND,
            GHOST,
            FIRE,
            ELECTRIC,
            BUG,
            FLYING,
            ICE,
            FIGHTING,
            PSYCHIC,
            DARK,
            WATER,
            DRAGON
        }

        public enum Effect
        {
            WEAK,
            STRONG,
            NORMAL,
            NONE
        }

        public Effect getAdvantageEffect(Element atk, Element def) { return Effect.NORMAL; }
    }
}
