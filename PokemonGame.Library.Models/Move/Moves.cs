using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Move
{
    public class BlankMove : BaseMove
    {
        public BlankMove() : base("BLANK", Element.Type.NONE, 0) { }
    }

    public class Tackle : BaseMove { public Tackle() : base("Tackle", Element.Type.NORMAL, 35) { } }
    public class ThunderBolt : BaseMove { public ThunderBolt() : base("ThunderBolt", Element.Type.ELECTRIC, 45) { } }
    public class Ember : BaseMove { public Ember() : base("Ember", Element.Type.FIRE, 45) { } }
    public class RockThrow : BaseMove { public RockThrow() : base("Rock Throw", Element.Type.ROCK, 45) { } }
    public class Earthquake : BaseMove { public Earthquake() : base("Earthquake", Element.Type.GROUND, 100) { } }
    public class HydroPump : BaseMove { public HydroPump() : base("HydroPump", Element.Type.WATER, 1000) { } };
}
