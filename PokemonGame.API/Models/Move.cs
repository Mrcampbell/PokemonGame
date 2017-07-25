using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGame.API.Models
{
    public class Move
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
    }
}
