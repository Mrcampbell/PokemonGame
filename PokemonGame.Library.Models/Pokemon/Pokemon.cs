using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Pokemon
{
    public class Pikachu : BasePokemon
    {
        public Pikachu(int level) 
            : base(
                  "Pikachu", 
                  level,
                  Element.Type.ELECTRIC,
                  Element.Type.NONE,
                  new StatGroup(35, 55, 40, 50, 50, 90)
                  ) { }
    }

    public class Charmander : BasePokemon
    {
        public Charmander(int level)
            : base(
                  "Charmander",
                  level,
                  Element.Type.FIRE,
                  Element.Type.NONE,
                  new StatGroup(35, 55, 40, 50, 50, 90)
                  )
        { }
    }

    public class Paras : BasePokemon
    {
        public Paras(int level)
            : base (
                  "Paras",
                  level,
                  Element.Type.BUG,
                  Element.Type.GRASS,
                  new StatGroup(35, 70, 55, 45, 55, 25))
        { }
    }

    public class Growlithe : BasePokemon
    {
        public Growlithe(int level)
            : base(
                  "Growlithe",
                  level,
                  Element.Type.FIRE,
                  Element.Type.NONE,
                  new StatGroup(55, 70, 45, 70, 50, 60)
                  )
        { }
    }
}
