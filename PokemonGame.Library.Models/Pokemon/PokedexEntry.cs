using PokemonGame.Library.Models.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Pokemon
{
    public class PokedexEntry
    {
        private string _name;
        private Element.Type _element1;
        private Element.Type _element2;
        private StatGroup _stat;
        private MoveLearnMethodList _moveLearnMethodList;
    }
}
