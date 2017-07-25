using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Library.Models
{
    public class Trainer
    {
        public Guid ID { get; set; }
        private string _name;
        private int _moneyCount;
    }
}
