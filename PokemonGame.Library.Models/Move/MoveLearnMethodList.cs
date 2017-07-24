using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models.Move
{
    public class MoveLearnMethodList
    {
        private List<BaseMove> _learnedByEgg;
        private List<BaseMove> _learnedByLevelUp;
        private List<BaseMove> _learnedByMachine;
        private List<BaseMove> _learnedByTutor;
    }
}
